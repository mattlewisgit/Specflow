import { Component, Inject, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";

import { QuoteApplyService } from "../services/quoteapply.service";
import { QuestionGroup }     from "../dynamic-form/question-group";
import { Question }     from "../dynamic-form/question";
import { QuestionControlService }    from "../dynamic-form/question-control.service";
import { WindowRef } from "./windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply-formtemplate.html"})
export class QuoteApplyFormComponent implements OnInit {
    quoteApplyForm: FormGroup;
    payload: string;
    viewModel: any;
    questionGroups: QuestionGroup[];
    submitted: boolean;

    constructor(
        private fb: FormBuilder,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) { }


    ngOnInit(): void {
        console.log(this.winRef.nativeWindow.angularData);
        this.questionGroups = this.winRef.nativeWindow.angularData.questionGroups;
        this.quoteApplyForm = new FormGroup({});
    }

    apply(isValid: boolean): void {
        if (isValid) {
            this.submitted = true;
            this.payload = JSON.stringify(this.quoteApplyForm.value);
        }
    }
}
