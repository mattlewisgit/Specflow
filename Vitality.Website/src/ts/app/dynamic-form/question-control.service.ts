import { Injectable }   from "@angular/core";

import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ValidationService } from "../services/validation.service";
import {FieldValidator } from "./field-validator";
import {Question } from "./question";

@Injectable()
export class QuestionControlService {
    constructor(
        private validationService: ValidationService
    ) { }

    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            let formControl = new FormControl(question.value || "", this.getValidators(question.validators));
            //if (question.onValueChange) {
            //    formControl.valueChanges.subscribe(data=> question.onValueChange(formControl,this.postcodeService));
            //}
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
