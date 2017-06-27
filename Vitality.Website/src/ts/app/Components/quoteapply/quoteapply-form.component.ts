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
    callToActionText: string;
    payload: string;
    questionGroups: QuestionGroup[];
    completedPercentage: number;
    submitted: boolean;
    isAllCompleted = false;
    childrenQuestionGroupKey = "childrenDobGroup";

    constructor(
        private fb: FormBuilder,
        private dobControlService: DobControlService,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.questionGroups = this.winRef.nativeWindow.angularData.questionGroups;
        this.callToActionText = this.winRef.nativeWindow.angularData.callToActionText;
        let childrenQuestionGroup = this.getQuestionGroup(this.childrenQuestionGroupKey);

        this.dobControlService.initialize({
            childrenQuestionGroup: childrenQuestionGroup,
            childDobLastLabel: this.winRef.nativeWindow.angularData.childDobLastLabel,
            childDobSeperatorLabel: this.winRef.nativeWindow.angularData.childDobSeperatorLabel
        });

        this.quoteApplyForm = new FormGroup({});

        this.quoteApplyForm.valueChanges.subscribe(data => {
            this.calculateCompletedPercentage();
        });
    }

    calculateCompletedPercentage() {
        let visibleQuestionGroups = this.questionGroups.filter(x => x.isVisible);
        this.completedPercentage = (visibleQuestionGroups.filter(x => x.isCompleted).length / visibleQuestionGroups.length) * 100;
        this.isAllCompleted = this.completedPercentage === 11.11111111111111;
        console.log(this.completedPercentage);
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
