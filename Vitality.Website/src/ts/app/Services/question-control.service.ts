import { Injectable }   from "@angular/core";

import { FormControl, FormGroup, Validators } from "@angular/forms";
import { DobControlService } from "../services/dob-control.service";
import { ValidationService } from "../services/validation.service";
import {FieldValidator } from "../models/field-validator";
import {Question } from "../models/question";

@Injectable()
export class QuestionControlService {
    constructor(
        private dobControlService: DobControlService,
        private validationService: ValidationService
    ) { }

    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            let formControl = new FormControl(question.value || "", this.getValidators(question.validators.filter(x => !x.isAsync)), this.getAsyncValidators(question.validators.filter(x => x.isAsync)));
            if (question.key === "noOfChildren") {
             formControl.valueChanges.subscribe(data=> this.dobControlService.noOfKidsChanged(data));
            }
            else if (question.key === "membersToInsure") {
                formControl.valueChanges.subscribe(data => this.dobControlService.membersToInsureChanged(data));
            }

            form.addControl(question.key, formControl);
        });
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
