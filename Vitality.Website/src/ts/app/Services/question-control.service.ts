import { Injectable }   from "@angular/core";
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

    constructor(
        private callbackService: CallbackService,
        private dobControlService: DobControlService,
        private validationService: ValidationService
    ) {
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

            if (question.controlType === "multiselect") {
                console.log('in multiselect');
                var maxSelectionsValidator = question.validators.filter(x => x.validatorName === "maxSelectionsValidator")[0];
                if (maxSelectionsValidator != null) {
                    console.log('got validator');
                    let selectedValuesCount = question.selectedValues ? question.selectedValues.length : 0;
                    maxSelectionsValidator.parameters['selectedCheckboxes'] = selectedValuesCount;
                    // TODO: maxselectionsexceeded undefined here so can't set limit for validation
                    console.log('limit: ' + maxSelectionsValidator.parameters['maxSelectionsExceeded'] + ' current: ' + selectedValuesCount);
                }
            }

            // TODO: attempt to debug params
            //question.validators.forEach(v => (v.parameters as Array<any>).forEach(p => console.log('param: ' + p.toString())));
            //question.validators.forEach(v => console.log('params ' + v.parameters.toString()));
            

            const formControl = new FormControl(question.value || "",
                this.getValidators(question.validators.filter(x => !x.isAsync)),
                this.getAsyncValidators(question.validators.filter(x => x.isAsync)));

            formControl.valueChanges.subscribe(data => {
                switch(question.key) {
                    case QuoteApplyConstants.keys.noOfChildren:
                        this.dobControlService.noOfKidsChanged(data);
                        break;
                    case QuoteApplyConstants.keys.membersToInsure:
                        this.dobControlService.membersToInsureChanged(data);
                        break;
                    case QuoteApplyConstants.keys.callbackDate:
                        // TODO: re-add these lines, probably need to rename variable as its causing me issues
                        //let question = questionGroup.questions
                      //      .filter(x => x.key === QuoteApplyConstants.keys.callbackTime)[0];
                        //question.relatedData = [];
                        if (form.controls[QuoteApplyConstants.keys.callbackDate].valid) {
                            this.callbackService
                                .populateRanges(data, question);
                        }
                        break;
                    case QuoteApplyConstants.keys.featuresAndBenefitsGroup:
                        // TODO: have access to selectedvalues here, but do we need to do anything?
                        console.log('switch2:' + question.selectedValues);
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
            // If control is not visible make the group valid and completed
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
        return !value && validators.filter(x => x.validatorName === "required").length ===0;
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
