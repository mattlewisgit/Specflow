import { Component, Input, OnInit  } from "@angular/core";
import { FormGroup }  from "@angular/forms";

import { GlobalConstants } from "../../constants/global-constants";

import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService }    from "../../services/question-control.service";

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

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup);
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

        const maxSelectionsValidator = question.validators
            .filter(x => x.validatorName === GlobalConstants.validators.maxSelectionsValidator)[0];
        if (maxSelectionsValidator != null) {
            console.log(question.value);
            if (question.value.length > maxSelectionsValidator.parameters.maxNumber) {
                maxSelectionsValidator.parameters.maxNumberExceeded = true;
                this.removeOption(selectedValue, question);
                event.target.checked = false;
            } else {
                maxSelectionsValidator.parameters.maxNumberExceeded = false;
            }
        }
    }

    removeOption(selectedValue: string, question: Question<any>): void {
        const index = question.value.indexOf(selectedValue, 0);
        if (index > -1) {
            question.value.splice(index, 1);
        }
    }
}
