import { Component, Input, OnInit, Output  } from "@angular/core";
import { FormGroup }  from "@angular/forms";

import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService }    from "../../services/question-control.service";
import { ProgressBarService } from "../../services/progress-bar.service";

@Component({
    selector: "question-groups",
    templateUrl: "./js/app/components/quoteapply/question-groups.component.html"
})
export class QuestionGroupsComponent implements OnInit {
    @Input() questionGroups: QuestionGroup[];
    @Input() form: FormGroup;

    constructor(private progressBarService: ProgressBarService, private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        for (let questionGroup of this.questionGroups) {
            this.qcs.addFormControls(this.form, questionGroup.questions);
        }
    }

    isValid(questionGroup: QuestionGroup): boolean {
        let isValid = true;
        if (!questionGroup.isVisible) {
            // If group is not visible mark the group completed.
            questionGroup.isCompleted = true;
        }

        for (let entry of questionGroup.questions) {
            // If control is not visible make the group valid and completed
            let control = this.form.controls[entry.key];

            if (!control.valid && this.isControlVisible(entry)) {
                questionGroup.isCompleted = false;

                if (!control.pristine) {
                    isValid = false;
                    break;
                }
            } else {
                questionGroup.isCompleted = true;
            }
        }
        this.calculateCompletedPercentage();
        return isValid;
    }

    isGroupVisible(questionGroup: QuestionGroup): boolean {
        if (!questionGroup.basedOnKey || !questionGroup.basedOnValues) {
           return questionGroup.isVisible = true;
        }
        let control = this.form.controls[questionGroup.basedOnKey];
        for (let basedOnValue of questionGroup.basedOnValues) {
            if (control.value === basedOnValue) {
                return questionGroup.isVisible = true;
            }
        }
        return questionGroup.isVisible = false;
    }

    // Only used for children Dobs
    isControlVisible(question: Question<any>): boolean {
        if (!question.basedOnKey) {
            return question.isVisible = true;
        }
        const control = this.form.controls[question.basedOnKey];
        return question.isVisible = +control.value >= question.basedOnValue;
    }

    calculateCompletedPercentage() {
        let visibleQuestionGroups = this.questionGroups.filter(x => x.isVisible);
        this.progressBarService.setCompletedPercentage(visibleQuestionGroups.filter(x => x.isCompleted).length,visibleQuestionGroups.length);
    }
}
