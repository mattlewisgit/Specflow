import { Component, Inject, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";

import { QuoteApplyService } from "../../services/quoteapply.service";
import { DobControlService } from "../../services/dob-control.service";
import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { WindowRef } from "./../windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply/quoteapply-form.component.html"
})
export class QuoteApplyFormComponent implements OnInit {
    quoteApplyForm: FormGroup;
    payload: string;
    questionGroups: QuestionGroup[];
    submitted: boolean;
    child5Option: any;
    childrenQuestionGroupKey = "childrenDobGroup";
    noOfChildrenKey = "noOfChildren";
    child1DobKey = "child1Dob";
    childrenQuestionGroup : QuestionGroup;
    noOfChildrenQuestion: Question<any>;
    child1DobQuestion: Question<any>;

    constructor(
        private fb: FormBuilder,
        private dobControlService: DobControlService,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.questionGroups = this.winRef.nativeWindow.angularData.questionGroups;

        this.childrenQuestionGroup = this.getQuestionGroup(this.childrenQuestionGroupKey);
        this.noOfChildrenQuestion = this.getQuestion(this.noOfChildrenKey, this.childrenQuestionGroup);
        this.child1DobQuestion = this.getQuestion(this.child1DobKey, this.childrenQuestionGroup);

        this.dobControlService.initialize({
            childrenQuestionGroup: this.childrenQuestionGroup,
            noOfChildrenQuestion: this.noOfChildrenQuestion,
            child1DobQuestion: this.child1DobQuestion,
            childDobLastLabel: this.winRef.nativeWindow.angularData.childDobLastLabel,
            childDobSeperatorLabel: this.winRef.nativeWindow.angularData.childDobSeperatorLabel
        });

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
        });
    }

    getQuestion(key: string, questionGroup: QuestionGroup): Question<any> {
        return questionGroup.questions.filter(x => x.key === key)[0];
    }

    getQuestionGroup(key: string) {
        return this.questionGroups.filter(x => x.key === key)[0];
    }

    apply(isValid: boolean): void {
        //Do it only when isvalid
        this.submitted = true;
        this.payload = JSON.stringify(this.quoteApplyForm.value);
    }
}
