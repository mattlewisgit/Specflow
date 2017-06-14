import { Injectable }   from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

import { ValidationService } from "../services/validation.service";
import {FieldValidator } from "./field-validator";
import {Question } from "./question";

@Injectable()
export class QuestionControlService {

    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            form.addControl(question.key, new FormControl(question.value || "", this.getValidators(question.validators)));
        });
    }

    getValidators(validators: FieldValidator[]) {
        let constructedValidators: any[] = [];
        for (let entry of validators) {
            constructedValidators.push(ValidationService.getValidator(entry.validatorName, entry.parameters));
        }
        return constructedValidators;
    }
}
