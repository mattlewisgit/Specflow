import { Injectable }   from "@angular/core";

import { FormControl } from "@angular/forms";
import { QuestionGroup } from "../models/question-group";
import { Question } from "../models/question";

@Injectable()
export class DobControlService {
    noOfChildrenKey = "noOfChildren";
    child1DobKey = "child1Dob";
    noOfChildrenQuestion: Question<any>;
    child1DobQuestion: Question<any>;
    noOfChildrenLabel: string;
    child1DobLabel: string;
    childDobLastLabel: string;
    childDobSeperatorLabel : string;

    initialize(options: {
        childDobLastLabel: string,
        childDobSeperatorLabel: string,
        noOfChildrenQuestion: Question<any>,
        child1DobQuestion: Question<any>})
    {
        this.childDobLastLabel = options.childDobLastLabel;
        this.childDobSeperatorLabel = options.childDobSeperatorLabel;
        this.noOfChildrenQuestion = options.noOfChildrenQuestion;
        this.noOfChildrenLabel = this.noOfChildrenQuestion.label;
        // Default to empty label
        this.noOfChildrenLabel = "";
        this.child1DobQuestion = options.child1DobQuestion;
        this.child1DobLabel = this.child1DobQuestion.label;
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
}
