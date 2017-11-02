﻿import { Component, Input, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";

import { QuestionGroup } from "../../models/question-group";
import { Question } from "../../models/question";
import { QuestionControlService } from "../../services/question-control.service";
import { PostcodeService } from "../../services/postcode.service";

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

    constructor(private questionControlService: QuestionControlService, private postcodeService: PostcodeService) {
    }

    ngOnInit(): void {
        this.questionControlService.addFormControls(this.form, this.questionGroup);
        this.hideManualAddressfields(true);
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

    triggerFieldAction(action: string) {
        switch (action) {
            case "postcodeSearch":
                this.findAddress(this.form.controls["billingPostcode"].value);
                break;
            case "showManualAddress":
                this.showManualAddress();
                break;
            case "addressChanged":
                this.showManualAddress();
                setTimeout(() => this.questionControlService.updateAddressEmitter.emit(this.form.controls["selectBillingAddress"].value), 0);
               
                break;
        }
    }

    findAddress(postcode: string) {
        this.postcodeService.updatePostcodeEmitter.emit(postcode);
    }

    showManualAddress() {
        this.hideManualAddressfields(false);
    }

    hideManualAddressfields(hideFields: boolean) {
        try {
            console.log("show");
            this.questionGroup.questions.filter(x => x.key === "address1")[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === "address2")[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === "address3")[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === "address4")[0].isHidden = hideFields;
            this.questionGroup.questions.filter(x => x.key === "postcode")[0].isHidden = hideFields;
        } catch (ex) {
            return;
        }
    }

}
