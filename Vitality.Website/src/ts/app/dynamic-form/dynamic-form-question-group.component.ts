import { Component, Input, OnInit } from "@angular/core";
import { FormGroup }        from "@angular/forms";

import { QuestionGroup }     from "./question-group";
import { QuestionControlService }    from "./question-control.service";

@Component({
    selector: "df-question-group",
    templateUrl: "./js/app/dynamic-form/dynamic-form-question-group.component.html"
})
export class DynamicFormQuestionGroupComponent implements OnInit {
    @Input() questionGroup: QuestionGroup;
    @Input() form: FormGroup;

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        console.log(this.questionGroup);
        this.qcs.addFormControls(this.form, this.questionGroup.questions);
    }

    get isValid() {
        for (let entry of this.questionGroup.questions) {
            let control = this.form.controls[entry.key];
            if (!control.valid && !control.pristine) {
                return false;
            }
        }
        return true;
    }

    makeVisible(basedOnKey: string, basedOnValues: string[]): boolean {
        if (!basedOnKey || !basedOnValues) {
            return true;
        }
        console.log(basedOnValues);
        let control = this.form.controls[basedOnKey];
        for (let basedOnValue of basedOnValues) {
            if (control.value === basedOnValue) {
                return true;
            }
        }
        return false;
    }
}
