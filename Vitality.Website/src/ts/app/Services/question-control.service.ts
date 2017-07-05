import { Injectable }   from "@angular/core";

import { FormControl, FormGroup, Validators } from "@angular/forms";
import { DobControlService } from "../services/dob-control.service";
import { ValidationService } from "../services/validation.service";
import { FieldValidator } from "../models/field-validator";
import { QuestionGroup } from "../models/question-group";

@Injectable()
export class QuestionControlService {
    private questionGroups : QuestionGroup[];
    constructor(
        private dobControlService: DobControlService,
        private validationService: ValidationService
    ) {
    }
    setQuestionGroups(questionGroups:QuestionGroup[]) {
        this.questionGroups = questionGroups;
    }

    addFormControls(form: FormGroup, questionGroup: QuestionGroup) {
        // if it is based on another control make it hidden to starts with
        if (questionGroup.basedOnKey) {
            questionGroup.isHidden = true;
        }
        questionGroup.questions.forEach(question => {
            let formControl = new FormControl(question.value || "",
                this.getValidators(question.validators.filter(x => !x.isAsync)),
                this.getAsyncValidators(question.validators.filter(x => x.isAsync)));
            if (question.key === "noOfChildren") {
                formControl.valueChanges.subscribe(data => {
                    this.dobControlService.noOfKidsChanged(data);
                    this.isValid(data, form, questionGroup);
                });
            } else if (question.key === "membersToInsure") {
                formControl.valueChanges.subscribe(data => {
                    this.dobControlService.membersToInsureChanged(data);
                    this.isValid(data, form, questionGroup);
                });
            }
            else {
                formControl.valueChanges.subscribe(data => this.isValid(data, form, questionGroup));
            }
            form.addControl(question.key, formControl);
        });
    }

    isValid(value:any, form: FormGroup, questionGroup: QuestionGroup): void {
        questionGroup.isInvalid = false;
        if (questionGroup.isHidden) {
            // If group is not visible mark the group completed.
            questionGroup.isCompleted = true;
        }

        for (let entry of questionGroup.questions) {
            this.handleHiddenGroups(entry.key, value);
            // If control is not visible make the group valid and completed
            let control = form.controls[entry.key];
            if (!control.valid && !entry.isHidden) {
                questionGroup.isCompleted = false;
                if (!control.pristine) {
                    questionGroup.isInvalid = true;
                    break;
                }
            } else {
                questionGroup.isCompleted = true;
            }
        }
    }


    handleHiddenGroups(key: string, value: any): void {
        //Get all the questionGroups based on current group
        let conditionalGroups = this.questionGroups.filter(x => x.basedOnKey === key);
        for (let cqg of conditionalGroups) {
            if (cqg.basedOnValues.indexOf(value) > -1) {
                cqg.isHidden = false;
            } else {
                cqg.isHidden = true;
            }
        }
    }

    private handleError(error: any): void {
        throw error.message || error;
    }

    getValidators(validators: FieldValidator[]) {
        return validators.map(v => this.validationService.getValidator(v.validatorName, v.parameters));
    }

    getAsyncValidators(validators: FieldValidator[]) {
        return validators.map(v => this.validationService.getAsyncValidator(v.validatorName, v.parameters));
    }
}
