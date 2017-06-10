import { Injectable }   from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

import {Question } from "./question";

@Injectable()
export class QuestionControlService {

    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            form.addControl(question.key, new FormControl(question.value || "", Validators.required));
        });
    }
}
