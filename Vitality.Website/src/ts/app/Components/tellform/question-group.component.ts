import { Component, Input, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";

import { QuestionGroup } from "../../models/question-group";
import { Question } from "../../models/question";
import { QuestionControlService } from "../../services/question-control.service";
import { PostcodeService } from "../../services/postcode.service";
import { GlobalConstants } from "../../constants/global-constants";
import { QuoteApplyConstants } from "../../constants/quoteapply-constants";

@Component({
    selector: "question-group",
    templateUrl: "./js/app/components/tellform/question-group.component.html"
})
export class QuestionGroupComponent implements OnInit {
    @Input()
    questionGroup: QuestionGroup;
    @Input()
    form: FormGroup;
    @Input()
    renderingData: {};
    @Input()
    formName: string;

    constructor(private questionControlService: QuestionControlService,
        private postcodeService: PostcodeService) {
    }

    ngOnInit(): void {
        this.questionControlService.addFormControls(this.form, this.questionGroup);
        if (this.formName === GlobalConstants.formNames.quotePaymentDetails) {
            this.hideManualAddressfields(true);
        };
    }

    storeSelectedCheckboxValues(event: any, selectedValue: string, question: Question<any>): void {
        question.value = question.value || new Array<string>();
        const checked = event.target.checked;
        // Add/Remove checkbox value from array
        if (checked) {
            question.value.push(selectedValue);
        } else {
            this.removeOption(selectedValue, question);
        }
        this.questionControlService.multiSelectOptionsEmitter.emit(question.value.length >= this.questionGroup.basedOnValues[0]);
    }

    removeOption(selectedValue: string, question: Question<any>): void {
        const index = question.value.indexOf(selectedValue, 0);
        if (index > -1) {
            question.value.splice(index, 1);
        }
    }

    findAddress(postcode: string) {
        this.postcodeService.updatePostcodeEmitter.emit(postcode);
    }

    triggerFieldAction(action: string) {
        switch (action) {
            case "postcodeSearch":
                this.findAddress((this.questionGroup.questions.filter(x => x.key === QuoteApplyConstants.fieldNames.billingPostcode)[0]).value);
                break;
            case "showManualAddress":
                this.showManualAddress();
                break;
            case "addressChanged":
                this.showManualAddress();
                setTimeout(() => this.questionControlService.updateAddressEmitter.emit(this.form.controls[QuoteApplyConstants.fieldNames.selectBillingAddress].value), 0);
                break;
        }
    }

    showManualAddress() {
        this.hideManualAddressfields(false);
    }

    hideManualAddressfields(hideFields: boolean) {
        try {
            this.questionGroup.questions.filter(x => x.key === QuoteApplyConstants.fieldNames.address1)[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === QuoteApplyConstants.fieldNames.address2)[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === QuoteApplyConstants.fieldNames.address3)[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === QuoteApplyConstants.fieldNames.address4)[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === QuoteApplyConstants.fieldNames.postcode)[0].isHidden = hideFields;
        } catch (ex) {
            return;
        }
    }

}
