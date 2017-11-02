import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { CallbackService } from "../../services/callback.service";
import { DobControlService } from "../../services/dob-control.service";
import { QuoteService } from "../../services/quote.service";
import { GlobalConstants } from "../../constants/global-constants";
import { QuoteApplyConstants } from "../../constants/quoteapply-constants";
import { QuestionControlService } from "../../services/question-control.service";
import { QuestionGroup } from "../../models/question-group";
import { Address } from "../../models/address";
import { PostcodeService } from "../../services/postcode.service";
import { FooterBarService } from "../../services/footer-bar.service";
import { TellFormService } from "../../services/tell-form.service";
import { WindowRef } from "./../windowref";

@Component({
    selector: "tell-form",
    templateUrl: "./js/app/components/tellform/tell-form.component.html"
})
export class TellFormComponent implements OnInit, OnDestroy {
    tellForm: FormGroup;
    postAction: string;
    redirectTo: string;
    referenceId: string;
    quoteApplication: any;
    private postcodeAsyncValidationSubscription: Subscription;
    private updatePostcodeSubscription: Subscription;
    private updateAddressSubscription: Subscription;
    questionGroups: QuestionGroup[];
    address: Address[];
    renderingData: {};
    private submitSubscription: Subscription;

    constructor(
        private quoteService: QuoteService,
        private callbackService: CallbackService,
        private dobControlService: DobControlService,
        private fb: FormBuilder,
        private postcodeService: PostcodeService,
        private questionControlService: QuestionControlService,
        private footerBarService: FooterBarService,
        private tellFormService: TellFormService,
        private winRef: WindowRef) {
        this.referenceId = GlobalConstants.strings.empty;
    }

    ngOnInit(): void {
        const angularData = this.winRef.nativeWindow.angularData;
        this.questionGroups = angularData.questionGroups;
        this.postAction = angularData.postAction;
        this.redirectTo = angularData.redirectTo;
        this.referenceId = angularData.referenceId;
        this.renderingData = { okBtnText: angularData.okBtnText, okBtnHelpText: angularData.okBtnHelpText };
        const childrenQuestionGroup = this.getQuestionGroup(QuoteApplyConstants.keys.childrenQuestionGroup);
        this.questionControlService.setQuestionGroups(this.questionGroups);

        if (childrenQuestionGroup) {
            this.dobControlService.initialize({
                childrenQuestionGroup: childrenQuestionGroup,
                additionalData: angularData.additionalData
            });
        }

        if (this.getQuestionGroup(QuoteApplyConstants.keys.callbackTimeQuestionGroup)) {
            this.callbackService.initialize(angularData.additionalData);
        }

        this.quoteService.getQuoteApplication(this.referenceId)
            .then((data: any) => {
                this.quoteApplication = data;
                this.getQuestionGroup("billingPostcodeGroup").questions.filter(x => x.key === "billingPostcode")[0].value = data.Postcode.toUpperCase();

                this.updatePostcode(this.quoteApplication.Postcode);
            });

        this.tellForm = new FormGroup({});
        this.tellForm.valueChanges.subscribe(data => {
            this.calculateCompletedPercentage();
        });

        this.postcodeAsyncValidationSubscription = this.postcodeService.onPostcodeAsyncValidation()
            .subscribe((data: boolean) => {
                if (data) {
                    const questionGroup = this.getQuestionGroup(QuoteApplyConstants.keys.postcodeQuestionGroup);
                    questionGroup.isInvalid = false;
                    questionGroup.isCompleted = true;
                    this.calculateCompletedPercentage();
                }
            });

        this.updatePostcodeSubscription = this.postcodeService.onUpdatePostcode()
            .subscribe((data: string) => {
                this.updatePostcode(data);
            });

        this.updateAddressSubscription = this.questionControlService.onUpdateAddress()
            .subscribe((data: number) => {
                this.updateAddress(data);
            });


        this.submitSubscription = this.footerBarService.onSubmitClicked()
            .subscribe((data: boolean) => {
                if (data) {
                    this.tellForm.value.referenceId = this.referenceId;
                    this.tellFormService.submit(`${this.postAction}`, this.tellForm.value)
                        .then((data: string) => {
                            this.referenceId = data;
                            this.winRef.nativeWindow.location.href = `${this.redirectTo}${this.referenceId}`;
                        });
                }
            });
    }

    calculateCompletedPercentage() {
        const requiredQuestionGroups = this.questionGroups.filter(x => !x.isHidden && !x.ignoreForPercentage);
        this.footerBarService.completedPercentageEmitter
            .emit((requiredQuestionGroups.filter(x => x.isCompleted).length /
                requiredQuestionGroups.length) *
            100);
    }

    getQuestionGroup(key: string) {
        return this.questionGroups.filter(x => x.key === key)[0];
    }

    updatePostcode(postcode: string) {
        this.postcodeService.initialize("address/lookup/", "CustomerDetails");

        let postcodes: any = [];

        this.postcodeService.lookupPostcode(postcode)
            .then(
            (data: any) => {
                this.address = data.Addresses;
                let i = 0;
                data.Addresses.forEach((item: any) => {
                    postcodes.push({
                        key: i,
                        value: item.AddressLine1 + (item.AddressLine2.length > 0 ? ", " + item.AddressLine2 : "")
                    });
                    i++;
                });
            });
        this.getQuestionGroup("billingPostcodeGroup").questions.filter(x => x.key === "selectBillingAddress")[0].relatedData = postcodes;
    }

    updateAddress(index: number) {
        if (this.address[index] !== undefined) {
            this.tellForm.controls["address1"].setValue(this.address[index].AddressLine1);
            this.tellForm.controls["address2"].setValue(this.address[index].AddressLine2);
            this.tellForm.controls["address3"].setValue(this.address[index].AddressLine4);
            this.tellForm.controls["address4"].setValue(this.address[index].Region);
            this.tellForm.controls["postcode"].setValue(this.address[index].PostCode);
        } else {
            this.tellForm.controls["address1"].setValue("");
            this.tellForm.controls["address2"].setValue("");
            this.tellForm.controls["address3"].setValue("");
            this.tellForm.controls["address4"].setValue("");
            this.tellForm.controls["postcode"].setValue("");
        }
    }

    ngOnDestroy(): void {
        if (this.postcodeAsyncValidationSubscription) {
            this.postcodeAsyncValidationSubscription.unsubscribe();
        }
    }
}
