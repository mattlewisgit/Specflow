import { Component, Inject, OnDestroy, Input, OnInit }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { CallbackService } from "../../services/callback.service";
import { DobControlService } from "../../services/dob-control.service";
import { GlobalConstants } from "../../constants/global-constants";
import { QuoteApplyConstants } from "../../constants/quoteapply-constants";
import { QuestionControlService } from "../../services/question-control.service";
import { QuestionGroup } from "../../models/question-group";
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
    private postcodeAsyncValidationSubscription: Subscription;
    questionGroups: QuestionGroup[];
    renderingData: {};
    private submitSubscription: Subscription;

    constructor(
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

        /*TODO:
        if (this.ang.Name === "buynow") {
            getapplication();
            
            let billinhgPostcode = getQuestionGroup();
            let childrenquestions = this.getQuestionGroup()
        }*/

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

    ngOnDestroy(): void {
        if (this.postcodeAsyncValidationSubscription) {
            this.postcodeAsyncValidationSubscription.unsubscribe();
        }
    }
}
