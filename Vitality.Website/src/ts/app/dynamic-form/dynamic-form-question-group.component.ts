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
}
