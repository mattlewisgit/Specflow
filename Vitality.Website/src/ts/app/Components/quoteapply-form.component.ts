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
    childDobLastLabel: string;
    childDobSeperatorLabel: string;
    questionGroups: QuestionGroup[];
    submitted: boolean;
    kid5Option: any;
    membersToInsureKey = "membersToInsure";
    noOfKidsKey = "noOfKids";
    noOfKidsQuestion: Question<any>;
    noOfKidsLabel: string;
    kid1DobQuestion: Question<any>;
    kid1DobLabel: string;

    constructor(
        private fb: FormBuilder,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }


    ngOnInit(): void {
        this.questionGroups = this.winRef.nativeWindow.angularData.questionGroups;
        this.childDobLastLabel = this.winRef.nativeWindow.angularData.childDobLastLabel;
        this.childDobSeperatorLabel = this.winRef.nativeWindow.angularData.childDobSeperatorLabel;

        this.noOfKidsQuestion = this.getKidsQuestion(this.noOfKidsKey);
        this.noOfKidsLabel = this.noOfKidsQuestion.label;
        this.kid1DobQuestion = this.getKidsQuestion("kid1DateOfBirth");
        this.kid1DobLabel = this.kid1DobQuestion.label;
        this.noOfKidsQuestion.label = "";

        //Make no of kid label to  empty
        this.quoteApplyForm = new FormGroup({});

        this.quoteApplyForm.valueChanges.subscribe(data => {
            // If Partner is included only allow 4 kids
            if (data.membersToInsure === "mepartnerkids") {
                let nofKidsQuestion = this.getKidsQuestion(this.noOfKidsKey);
                let lastItemIndex = nofKidsQuestion.relatedData.length - 1;
                this.kid5Option = nofKidsQuestion.relatedData[lastItemIndex];
                nofKidsQuestion.relatedData.pop();
            }
            else if (data.membersToInsure === "mekids") {
                // If kids without partner allow 5 kids
                let nofKidsQuestion = this.getKidsQuestion(this.noOfKidsKey);
                if (nofKidsQuestion.relatedData.length < 5) {
                    nofKidsQuestion.relatedData.push({ key: this.kid5Option.key, value: this.kid5Option.value });
                }
            };
            //// handles kids Labels
            let noOfKids: number = data.noOfKids;
            //Do not use ===
            if (noOfKids == 1) {
                this.noOfKidsQuestion.label = null;
                this.kid1DobQuestion.label = this.kid1DobLabel;
            } else {
                this.noOfKidsQuestion.label = this.noOfKidsLabel;
                this.kid1DobQuestion.label = null;
            }
            for (let i = 2; i <= data.noOfKids; i++) {
                let currentKidDobQuestion = this.getKidsQuestion(`kid${i}DateOfBirth`);
                if (i == noOfKids) {
                    currentKidDobQuestion.label = this.childDobLastLabel;
                } else {
                    currentKidDobQuestion.label = this.childDobSeperatorLabel;
                }
            }
        });
    }

    getKidsQuestion(key :string): Question<any> {
        let kidsDobQuestionGroup = this.questionGroups.filter(x => x.basedOnKey === this.membersToInsureKey);
        for (let entry of kidsDobQuestionGroup) {
            let noOfKidsQuestion = entry.questions.filter(x => x.key === key)[0];
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
