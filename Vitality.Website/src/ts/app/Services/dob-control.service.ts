import { Injectable }   from "@angular/core";

import { FormControl } from "@angular/forms";
import { QuestionGroup } from "../models/question-group";
import { Question } from "../models/question";

@Injectable()
export class DobControlService {
    noOfChildrenKey = "noOfChildren";
    child1DobKey = "child1Dob";
    childrenQuestionGroup: QuestionGroup;
    noOfChildrenQuestion: Question<any>;
    child1DobQuestion: Question<any>;
    child5Option: { key: string, value: string };
    noOfChildrenLabel: string;
    child1DobLabel: string;
    childDobLastLabel: string;
    childDobSeperatorLabel : string;

    initialize(options: {
        childrenQuestionGroup: QuestionGroup,
        childDobLastLabel: string,
        childDobSeperatorLabel: string})
    {
        this.childrenQuestionGroup = options.childrenQuestionGroup;

        this.child1DobQuestion = this.getQuestion(this.child1DobKey, this.childrenQuestionGroup);
        this.child1DobLabel = this.child1DobQuestion.label;

        this.noOfChildrenQuestion = this.getQuestion(this.noOfChildrenKey, this.childrenQuestionGroup);
        this.noOfChildrenLabel = this.noOfChildrenQuestion.label;
        // Default to empty label
        this.noOfChildrenQuestion.label = "";

        this.childDobLastLabel = options.childDobLastLabel;
        this.childDobSeperatorLabel = options.childDobSeperatorLabel;

        this.addChildrenDobQuestions();
    }

    membersToInsureChanged(membersToInsure: string) {
        // If Partner is included only allow 4 children
        if (membersToInsure === "mepartnerchildren" && this.noOfChildrenQuestion.relatedData.length === 5) {
            let lastItemIndex = this.noOfChildrenQuestion.relatedData.length - 1;
            this.child5Option = this.noOfChildrenQuestion.relatedData[lastItemIndex];
            this.noOfChildrenQuestion.relatedData.pop();
        } else if (membersToInsure === "mechildren" && this.noOfChildrenQuestion.relatedData.length < 5) {
            this.noOfChildrenQuestion.relatedData.push({
                key: this.child5Option.key,
                value: this.child5Option.value
            });
        }
    }

    noOfKidsChanged(noOfChildren: number) {
        //Do not use ===
        if (noOfChildren == 1) {
            this.noOfChildrenQuestion.label = null;
            this.child1DobQuestion.label = this.child1DobLabel;
        } else if (noOfChildren > 1) {
            this.noOfChildrenQuestion.label = this.noOfChildrenLabel;
            this.child1DobQuestion.label = null;
        } else {
            this.noOfChildrenQuestion.label = null;
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
        this.handleDobQuestionVisibility(noOfChildren);
    }

    handleDobQuestionVisibility(noOfChildren: number) {
        this.childrenQuestionGroup.questions.forEach((question, index) => {
            if (index <= noOfChildren) {
                question.isHidden = false;
            } else {
                question.isHidden = true;
            }
        });
    }

    addChildrenDobQuestions(): void {
        this.child1DobQuestion.basedOnKey = this.noOfChildrenQuestion.key;
        this.child1DobQuestion.isHidden = true;
        this.child1DobQuestion.basedOnValue = 1;
        for (let i = 2; i < 6; i++) {
            let childDobToAdd = Object.apply({}, this.child1DobQuestion);
            childDobToAdd.value = null;
            childDobToAdd.basedOnKey = this.noOfChildrenQuestion.key;
            childDobToAdd.basedOnValue = i;
            childDobToAdd.key = `child${i}Dob`;
            childDobToAdd.label = ",";
            childDobToAdd.placeholder = this.child1DobQuestion.placeholder;
            childDobToAdd.validators = this.child1DobQuestion.validators;
            childDobToAdd.controlType = this.child1DobQuestion.controlType;
            childDobToAdd.isHidden = true;
            this.childrenQuestionGroup.questions.push(childDobToAdd);
        }
    }

    getQuestion(key: string, questionGroup: QuestionGroup): Question<any> {
        return questionGroup.questions.filter(x => x.key === key)[0];
    }
}
