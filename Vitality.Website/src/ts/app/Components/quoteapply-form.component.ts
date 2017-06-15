import { Component, Inject, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";

import { QuoteApplyService } from "../services/quoteapply.service";
import { QuestionGroup }     from "../dynamic-form/question-group";
import { Question }     from "../dynamic-form/question";
import { QuestionControlService }    from "../dynamic-form/question-control.service";
import { WindowRef } from "./windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply-formtemplate.html"
})
export class QuoteApplyFormComponent implements OnInit {
    quoteApplyForm: FormGroup;
    payload: string;
    viewModel: any;
    questionGroups: QuestionGroup[];
    submitted: boolean;
    kid5Option: any;
    membersToInsureKey = "membersToInsure";

    constructor(
        private fb: FormBuilder,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }


    ngOnInit(): void {
        this.questionGroups = this.winRef.nativeWindow.angularData.questionGroups;
        this.quoteApplyForm = new FormGroup({});

        this.quoteApplyForm.valueChanges.subscribe(data => {
            // If Partner is included only allow 4 kids
            if (data.membersToInsure === "mepartnerkids") {
                let nofKidsQuestion = this.getNoOfKidsQuestion();
                let lastItemIndex = nofKidsQuestion.relatedData.length - 1;
                this.kid5Option = nofKidsQuestion.relatedData[lastItemIndex];
                nofKidsQuestion.relatedData.pop();
            } else if (data.membersToInsure === "mekids") {
                // If kids without partner allow 5 kids
                let nofKidsQuestion = this.getNoOfKidsQuestion();
                nofKidsQuestion.relatedData.push(this.kid5Option);
            };
        });
    }

    getNoOfKidsQuestion(): Question<any> {
        let kidsDobQuestionGroup = this.questionGroups.filter(x => x.basedOnKey === this.membersToInsureKey);
        for (let entry of kidsDobQuestionGroup) {
            let noOfKidsQuestion = entry.questions.filter(x => x.key === "noOfKids")[0];
            if (noOfKidsQuestion != null) {
                return noOfKidsQuestion;
            }
        }
        return null;
    }

    apply(isValid: boolean): void {

        //Do it only when isvalid later
        this.submitted = true;
        this.payload = JSON.stringify(this.quoteApplyForm.value);
    }
}
