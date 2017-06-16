import { Injectable }   from "@angular/core";

import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ValidationService } from "../services/validation.service";
import { PostcodeService } from "../services/postcode.service";
import {FieldValidator } from "./field-validator";
import {Question } from "./question";

@Injectable()
export class QuestionControlService {
    constructor(
        private postcodeService: PostcodeService
    ) { }


    addFormControls(form: FormGroup, questions: Question<any>[]) {
        questions.forEach(question => {
            if (question.key === "postcode") {
                question.onValueChange = this.lookupPostcode;
            }

            let formControl = new FormControl(question.value || "", this.getValidators(question.validators));
            if (question.onValueChange) {
                formControl.valueChanges.subscribe(data=> question.onValueChange(formControl,this.postcodeService));
            }
            form.addControl(question.key, formControl);
        });
    }

    lookupPostcode(control: FormControl, postcodeService: PostcodeService): void{
        if (control.valid) {
            postcodeService.setFeedSettings("http://api.postcodes.io/postcodes/");
            let postcodeLookupResponse = postcodeService.lookupPostcode(control.value).then(data => {                console.log(data);            });
        }
    }

    private handleError(error: any): void {
        throw error.message || error;
    }

    getValidators(validators: FieldValidator[]) {
        let constructedValidators: any[] = [];
        for (let entry of validators) {
            constructedValidators.push(ValidationService.getValidator(entry.validatorName, entry.parameters));
        }
        return constructedValidators;
    }
}
