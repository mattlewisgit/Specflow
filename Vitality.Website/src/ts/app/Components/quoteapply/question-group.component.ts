import { Component, Input, OnInit, Output  } from "@angular/core";
import { FormGroup }  from "@angular/forms";

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
        this.qcs.addFormControls(this.form, this.questionGroup);
    }

    isGroupHidden(questionGroup: QuestionGroup): boolean {
        if (!questionGroup.basedOnKey || !questionGroup.basedOnValues) {
           return questionGroup.isHidden = false;
        }
        let control = this.form.controls[questionGroup.basedOnKey];
        for (let basedOnValue of questionGroup.basedOnValues) {
            if (control.value === basedOnValue) {
                return questionGroup.isHidden = false;
            }
        }
        return questionGroup.isHidden = true;
    }

    // Only used for children Dobs
    isControlHidden(question: Question<any>): boolean {
        if (!question.basedOnKey) {
            return question.isHidden = false;
        }
        const control = this.form.controls[question.basedOnKey];
        return question.isHidden = +control.value < question.basedOnValue;
    }
}
