import { Injectable }   from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

import { ValidationService } from "../services/validation.service";
import {Question } from "./question";

@Injectable()
export class QuestionControlService {

    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            form.addControl(question.key, new FormControl(question.value || "", this.getValidators(question.validations)));
        });
    }

    getValidators(validations: string[]) {
        let validators: any[] = [];
        for (let entry of validations) {
                validators.push(ValidationService.getValidator(entry));
        }
        return validators;
    }
}
