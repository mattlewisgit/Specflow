import { EventEmitter, Injectable }   from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

import { CallbackService } from "../services/callback.service";
import { DobControlService } from "../services/dob-control.service";
import { FieldValidator } from "../models/field-validator";

import { QuoteApplyConstants } from "../constants/quoteapply-constants";
import { QuestionGroup } from "../models/question-group";
import { ValidationService } from "../services/validation.service";


@Injectable()
export class QuestionControlService {
    private questionGroups: QuestionGroup[];
    multiSelectOptionsEmitter= new EventEmitter<boolean>();

    constructor(
        private callbackService: CallbackService,
        private dobControlService: DobControlService,
        private validationService: ValidationService
    ) {
    }

    updateAddressEmitter = new EventEmitter<number>();
    onUpdateAddress() {
        console.log("emmit");
        return this.updateAddressEmitter;
    }

    setQuestionGroups(questionGroups: QuestionGroup[]) {
        this.questionGroups = questionGroups;
    }

    addFormControls(form: FormGroup, questionGroup: QuestionGroup) {
        // if it is based on another control make it hidden to starts with
        if (questionGroup.basedOnKey) {
            questionGroup.isHidden = true;
        }
        questionGroup.questions.forEach(question => {
            const formControl = new FormControl(question.value || "",
                this.getValidators(question.validators.filter(x => !x.isAsync)),
                this.getAsyncValidators(question.validators.filter(x => x.isAsync)));

            questionGroup.isCompleted = this.isNotRequiredAndEmpty(question.value, question.validators);
            questionGroup.ignoreForPercentage = questionGroup.isCompleted;
            formControl.valueChanges.subscribe(data => {
                switch(question.key) {
                    case QuoteApplyConstants.keys.noOfChildren:
                        this.dobControlService.noOfKidsChanged(data);
                        break;
                    case QuoteApplyConstants.keys.membersToInsure:
                        this.dobControlService.membersToInsureChanged(data);
                        break;
                    case QuoteApplyConstants.keys.callbackDate:
                        const callBackTimeQuestion = questionGroup.questions
                            .filter(x => x.key === QuoteApplyConstants.keys.callbackTime)[0];
                        callBackTimeQuestion.relatedData = [];
                        if (form.controls[QuoteApplyConstants.keys.callbackDate].valid) {
                            this.callbackService
                                .populateRanges(data, callBackTimeQuestion);
                        }
                        break;
                }
                this.isValid(data, form, questionGroup);
            });
            form.addControl(question.key, formControl);
        });
    }

    isValid(value:any, form: FormGroup, questionGroup: QuestionGroup): void {
        questionGroup.isInvalid = false;
        // If group is not visible mark the group completed.
        questionGroup.isCompleted = questionGroup.isHidden;

        for (let entry of questionGroup.questions) {
            this.handleHiddenGroups(entry.key, value);
            // If control is not visible or no validators make the group valid and completed
            const control = form.controls[entry.key];
            questionGroup.isCompleted = control.valid || entry.isHidden || this.isNotRequiredAndEmpty(value, entry.validators);
            if (!questionGroup.isCompleted) {
                questionGroup.isInvalid = !control.pristine;
                break;
            }
        }
    }

    handleHiddenGroups(key: string, value: any): void {
        //Get all the questionGroups based on current group
        const conditionalGroups = this.questionGroups.filter(x => x.basedOnKey === key);
        for (let cqg of conditionalGroups) {
            cqg.isHidden = cqg.basedOnValues.indexOf(value) < 0;
        }
    }

    private isNotRequiredAndEmpty(value: any, validators: FieldValidator[]) {
        return !value &&
            (validators.length === 0 || validators.filter(x => x.validatorName === "required").length === 0);
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
