import { Injectable }   from "@angular/core";

import { FormControl } from "@angular/forms";
import { Question } from "../models/question";
import { QuestionGroup } from "../models/question-group";
import { GlobalConstants } from "../constants/global-constants";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";

@Injectable()
export class DobControlService {
    child1DobQuestion: Question<any>;
    child5Option: { key: string, value: string };
    child1DobLabel: string;
    childDobLastLabel: string;
    childrenQuestionGroup: QuestionGroup;
    childDobSeperatorLabel: string;
    noOfChildrenLabel: string;
    noOfChildrenQuestion: Question<any>;

    initialize(options: {
        childrenQuestionGroup: QuestionGroup,
        additionalData: any})
    {
        this.childrenQuestionGroup = options.childrenQuestionGroup;

        this.child1DobQuestion = this.getQuestion(QuoteApplyConstants.keys.child1Dob, this.childrenQuestionGroup);
        this.child1DobLabel = this.child1DobQuestion.label;

        this.noOfChildrenQuestion = this.getQuestion(QuoteApplyConstants.keys.noOfChildren, this.childrenQuestionGroup);
        this.noOfChildrenLabel = this.noOfChildrenQuestion.label;
        // Default to empty label
        this.noOfChildrenQuestion.label = GlobalConstants.strings.empty;

        this.childDobLastLabel = options.additionalData.childDobLastLabel;
        this.childDobSeperatorLabel = options.additionalData.childDobSeperatorLabel;

        this.addChildrenDobQuestions();
    }

    membersToInsureChanged(membersToInsure: string) {
        // If Partner is included only allow 4 children
        // TODO drive maximum number of children from Sitecore - Janaka
        if (membersToInsure === QuoteApplyConstants.values.mePartnerChildren && this.noOfChildrenQuestion.relatedData.length === 5) {
            const lastItemIndex = this.noOfChildrenQuestion.relatedData.length - 1;
            this.child5Option = this.noOfChildrenQuestion.relatedData[lastItemIndex];
            this.noOfChildrenQuestion.relatedData.pop();
        } else if (membersToInsure === QuoteApplyConstants.values.meChildren && this.noOfChildrenQuestion.relatedData.length < 5) {
            this.noOfChildrenQuestion.relatedData.push({
                key: this.child5Option.key,
                value: this.child5Option.value
            });
        }
    }

    noOfKidsChanged(noOfChildren: number) {
        //Do not use ===
        if (noOfChildren == 1) {
            this.child1DobQuestion.label = this.child1DobLabel;
        } else if (noOfChildren > 1) {
            this.child1DobQuestion.label = this.noOfChildrenLabel;
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
            childDobToAdd.label = this.childDobSeperatorLabel;
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
