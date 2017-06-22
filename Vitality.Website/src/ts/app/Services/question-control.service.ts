import { Injectable }   from "@angular/core";

import { FormControl, FormGroup, Validators } from "@angular/forms";
import { DobControlService } from "../services/dob-control.service";
import { ValidationService } from "../services/validation.service";
import {FieldValidator } from "../models/field-validator";
import {Question } from "../models/question";

@Injectable()
export class QuestionControlService {
    constructor(
        private dobControlService : DobControlService,
        private validationService: ValidationService
    ) { }

    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            let formControl = new FormControl(question.value || "", this.getValidators(question.validators));
            if (question.key === "noOfChildren") {
             formControl.valueChanges.subscribe(data=> this.dobControlService.noOfKidsChanged(data, questions));
            }
            form.addControl(question.key, formControl);
        });
    }

    private handleError(error: any): void {
        throw error.message || error;
    }

    getValidators(validators: FieldValidator[]) {
        let constructedValidators: any[] = [];
        for (let entry of validators) {
            constructedValidators.push(this.validationService.getValidator(entry.validatorName, entry.parameters));
        }
        return constructedValidators;
    }
}
