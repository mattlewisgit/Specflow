import { Component, Inject, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";

import { QuoteApplyService } from "../services/quoteapply.service";
import { ValidationService } from "../services/validation.service";
import { QuestionGroup }     from "../dynamic-form/question-group";
import { Question }     from "../dynamic-form/question";
import { QuestionControlService }    from "../dynamic-form/question-control.service";
import { WindowRef } from "./windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply-formtemplate.html"})
export class QuoteApplyFormComponent implements OnInit {
    quoteApplyForm: FormGroup;
    payLoad: string;
    viewModel: any;
    questionGroups: QuestionGroup[];
    submitted: boolean;

    constructor(
        private fb: FormBuilder,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) { }


    ngOnInit(): void {
        this.questionGroups = [
            new QuestionGroup(
                {
                    label: "My name is",
                    validationMessage: "Please enter a valid name",
                    questions: [
                        new Question({
                            value: "mr",
                            key: "title",
                            label: "Title",
                            controlType: "dropdown",
                            relatedData: [
                                { key: 'mr', value: 'Mr' },
                                { key: 'miss', value: 'Miss' },
                                { key: 'mrs', value: 'Mrs' }
                            ]
                        }),
                        new Question({
                            key: "firstName",
                            label: "First Name",
                            validations: ["required"],
                            controlType: "text"
                        }),
                        new Question({
                            key: "lastName",
                            label: "Last Name",
                            validations: ["required"],
                            controlType: "text"
                        })
                    ]

                })
        ];
        this.quoteApplyForm = new FormGroup({});
    }

    apply(isValid: boolean): void {
        if (isValid) {
            this.submitted = true;
            this.payLoad = JSON.stringify(this.quoteApplyForm.value);
        }
    }
}
