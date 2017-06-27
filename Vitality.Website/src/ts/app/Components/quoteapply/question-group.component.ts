import { Component, Input, OnInit } from "@angular/core";
import { FormGroup }        from "@angular/forms";

import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService }    from "../../services/question-control.service";

@Component({
    selector: "question-group",
    templateUrl: "./js/app/components/quoteapply/question-group.component.html"
})
export class QuestionGroupComponent implements OnInit {
    @Input() questionGroup: QuestionGroup;
    @Input() form: FormGroup;

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup.questions);
    }

    get isValid() {
        if (!this.questionGroup.isVisible) {
            // If group is not visible make the group valid and completed
            return this.questionGroup.isCompleted = true;
        }
        for (let entry of this.questionGroup.questions) {
            // If control is not visible make the group valid and completed
            let control = this.form.controls[entry.key];
            if (!control.valid && this.isControlVisible(entry)) {
                this.questionGroup.isCompleted = false;
                if (!control.pristine) {
                    return false;
                }
            } else {
                this.questionGroup.isCompleted = true;
            }
        }
        return true;
    }

    isGroupVisible(): boolean {
        if (!this.questionGroup.basedOnKey || !this.questionGroup.basedOnValues) {
           return this.questionGroup.isVisible = true;
        }
        let control = this.form.controls[this.questionGroup.basedOnKey];
        for (let basedOnValue of this.questionGroup.basedOnValues) {
            if (control.value === basedOnValue) {
                return this.questionGroup.isVisible = true;
            }
        }
        return this.questionGroup.isVisible = false;
    }


    // Only used for children Dobs
    isControlVisible(question: Question<any>): boolean {
        if (!question.basedOnKey) {
            return question.isVisible = true;
        }
        const control = this.form.controls[question.basedOnKey];
        return question.isVisible = +control.value >= question.basedOnValue;
    }
}
