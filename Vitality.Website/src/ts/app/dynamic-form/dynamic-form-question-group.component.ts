import { Component, Input, OnInit } from "@angular/core";
import { FormGroup }        from "@angular/forms";

import { Question }     from "./question";
import { QuestionGroup }     from "./question-group";
import { QuestionControlService }    from "./question-control.service";

@Component({
    selector: "df-question-group",
    templateUrl: "./js/app/dynamic-form/dynamic-form-question-group.component.html"
})
export class DynamicFormQuestionGroupComponent implements OnInit {
    @Input() questionGroup: QuestionGroup;
    @Input() form: FormGroup;
    @Input()
    noOfKidsKey = "noOfKids";
    membersToInsureKey = "membersToInsure";
    kid1DateOfBirthKey = "kid1DateOfBirth";

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.addChildrenBirthDayQuestions();
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

    addChildrenBirthDayQuestions(): void {
        if (this.questionGroup.basedOnKey === this.membersToInsureKey) {
            let kid1DobQuestion = this.questionGroup.questions.filter(x => x.key === this.kid1DateOfBirthKey)[0];
            if (kid1DobQuestion != null) {
                for (let i = 2; i < 6; i++) {
                    let kidDobToAdd = Object.apply({}, kid1DobQuestion);
                    kidDobToAdd.value =null;
                    kidDobToAdd.basedOnKey = this.noOfKidsKey;
                    kidDobToAdd.basedOnValue = i;
                    kidDobToAdd.key = `kid${i}DateOfBirth`;
                    kidDobToAdd.label = ",";
                    kidDobToAdd.placeholder = kid1DobQuestion.placeholder;
                    kidDobToAdd.validators = kid1DobQuestion.validators;
                    kidDobToAdd.controlType = kid1DobQuestion.controlType;
                    this.questionGroup.questions.push(kidDobToAdd);
                }
            }
        }
    }

    makeVisible(basedOnKey: string, basedOnValues: string[]): boolean {
        if (!basedOnKey || !basedOnValues) {
            return true;
        }
        let control = this.form.controls[basedOnKey];
        for (let basedOnValue of basedOnValues) {
            if (control.value === basedOnValue) {
                return true;
            }
        }
        return false;
    }


    // Only used for children Dobs
    makeControlVisible(basedOnKey: string, basedOnValue: number): boolean {
        if (!basedOnKey) {
            return true;
        }
        const control = this.form.controls[basedOnKey];
        if (+control.value >= basedOnValue) {
            return true;
        }
        return false;
    }
}
