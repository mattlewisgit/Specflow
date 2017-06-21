import { Component, Inject, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";

import { QuoteApplyService } from "../../services/quoteapply.service";
import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService }    from "../../services/question-control.service";
import { WindowRef } from "./../windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply/quoteapply-form.component.html"
})
export class QuoteApplyFormComponent implements OnInit {
    quoteApplyForm: FormGroup;
    payload: string;
    childDobLastLabel: string;
    childDobSeperatorLabel: string;
    questionGroups: QuestionGroup[];
    submitted: boolean;
    child5Option: any;
    childrenQuestionGroupKey = "childrenDobGroup";
    noOfChildrenKey = "noOfChildren";
    child1DobKey = "child1Dob";
    childrenQuestionGroup : QuestionGroup;
    noOfChildrenQuestion: Question<any>;
    noOfChildrenLabel: string;
    child1DobQuestion: Question<any>;
    child1DobLabel: string;

    constructor(
        private fb: FormBuilder,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }


    ngOnInit(): void {
        this.questionGroups = this.winRef.nativeWindow.angularData.questionGroups;
        this.childDobLastLabel = this.winRef.nativeWindow.angularData.childDobLastLabel;
        this.childDobSeperatorLabel = this.winRef.nativeWindow.angularData.childDobSeperatorLabel;

        this.childrenQuestionGroup = this.getQuestionGroup(this.childrenQuestionGroupKey);
        this.noOfChildrenQuestion = this.getQuestion(this.noOfChildrenKey, this.childrenQuestionGroup);
        this.noOfChildrenLabel = this.noOfChildrenQuestion.label;
        this.child1DobQuestion = this.getQuestion(this.child1DobKey, this.childrenQuestionGroup);
        this.child1DobLabel = this.child1DobQuestion.label;

        this.addChildrenDobQuestions();

        //Make no of child label to  empty
        this.noOfChildrenQuestion.label = "";

        this.quoteApplyForm = new FormGroup({});

        this.quoteApplyForm.valueChanges.subscribe(data => {
            // If Partner is included only allow 4 children
            if (data.membersToInsure === "mepartnerchildren" && this.noOfChildrenQuestion.relatedData.length === 5) {
                let lastItemIndex = this.noOfChildrenQuestion.relatedData.length - 1;
                this.child5Option = this.noOfChildrenQuestion.relatedData[lastItemIndex];
                this.noOfChildrenQuestion.relatedData.pop();
            }
            else if (data.membersToInsure === "mechildren" && this.noOfChildrenQuestion.relatedData.length < 5) {
                this.noOfChildrenQuestion.relatedData.push({
                    key: this.child5Option.key,
                    value: this.child5Option.value
                });
            };

            //// handles children Labels
            let noOfChildren: number = data.noOfChildren;
            //Do not use ===
            if (noOfChildren == 1) {
                this.noOfChildrenQuestion.label = null;
                this.child1DobQuestion.label = this.child1DobLabel;
            } else {
                this.noOfChildrenQuestion.label = this.noOfChildrenLabel;
                this.child1DobQuestion.label = null;
            }
            for (let i = 2; i <= noOfChildren; i++) {
                let currentchildDobQuestion = this.getQuestion(`child${i}Dob`, this.childrenQuestionGroup);
                if (i == noOfChildren) {
                    currentchildDobQuestion.label = this.childDobLastLabel;
                } else {
                    currentchildDobQuestion.label = this.childDobSeperatorLabel;
                }
            }
        });
    }

    getQuestion(key: string, questionGroup: QuestionGroup): Question<any> {
        return questionGroup.questions.filter(x => x.key === key)[0];
    }

    getQuestionGroup(key: string) {
        return this.questionGroups.filter(x => x.key === key)[0];
    }

    addChildrenDobQuestions(): void {
        for (let i = 2; i < 6; i++) {
            let childDobToAdd = Object.apply({}, this.child1DobQuestion);
            childDobToAdd.value = null;
            childDobToAdd.basedOnKey = this.noOfChildrenKey;
            childDobToAdd.basedOnValue = i;
            childDobToAdd.key = `child${i}DateOfBirth`;
            childDobToAdd.label = ",";
            childDobToAdd.placeholder = this.child1DobQuestion.placeholder;
            childDobToAdd.validators = this.child1DobQuestion.validators;
            childDobToAdd.controlType = this.child1DobQuestion.controlType;
            this.childrenQuestionGroup.questions.push(childDobToAdd);
        }
    }

    apply(isValid: boolean): void {
        //Do it only when isvalid
        this.submitted = true;
        this.payload = JSON.stringify(this.quoteApplyForm.value);
    }
}
