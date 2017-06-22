import { Injectable }   from "@angular/core";

import { FormControl } from "@angular/forms";
import { QuestionGroup } from "../models/question-group";
import { Question } from "../models/question";

@Injectable()
export class DobControlService {
    childrenQuestionGroup: QuestionGroup;
    noOfChildrenQuestion: Question<any>;
    child1DobQuestion: Question<any>;
    noOfChildrenLabel: string;
    child1DobLabel: string;
    childDobLastLabel: string;
    childDobSeperatorLabel : string;

    initialize(options: {
        childrenQuestionGroup: QuestionGroup,
        child1DobQuestion: Question<any>,
        noOfChildrenQuestion: Question<any>,
        childDobLastLabel: string,
        childDobSeperatorLabel: string})
    {
        this.childrenQuestionGroup = options.childrenQuestionGroup;

        this.child1DobQuestion = options.child1DobQuestion;
        this.child1DobLabel = this.child1DobQuestion.label;

        this.noOfChildrenQuestion = options.noOfChildrenQuestion;
        this.noOfChildrenLabel = this.noOfChildrenQuestion.label;
        // Default to empty label
        this.noOfChildrenQuestion.label = "";

        this.childDobLastLabel = options.childDobLastLabel;
        this.childDobSeperatorLabel = options.childDobSeperatorLabel;

        this.addChildrenDobQuestions();
    }

    noOfKidsChanged(noOfChildren: number,
        questions: Question<any>[]) {
        //Do not use ===
        if (noOfChildren == 1) {
            this.noOfChildrenQuestion.label = null;
            this.child1DobQuestion.label = this.child1DobLabel;
        } else {
            this.noOfChildrenQuestion.label = this.noOfChildrenLabel;
            this.child1DobQuestion.label = null;
        }
        for (let i = 2; i <= noOfChildren; i++) {
            let currentchildDobQuestion = questions.filter(x => x.key === `child${i}Dob`)[0];
            if (i == noOfChildren) {
                currentchildDobQuestion.label = this.childDobLastLabel;
            } else {
                currentchildDobQuestion.label = this.childDobSeperatorLabel;
            }
        }
    }

    addChildrenDobQuestions(): void {
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
            this.childrenQuestionGroup.questions.push(childDobToAdd);
        }
    }
}
