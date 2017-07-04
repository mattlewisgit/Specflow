import { Component, DoCheck, Inject, OnDestroy, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { QuoteApplyService } from "../../services/quoteapply.service";
import { ProgressBarService } from "../../services/progress-bar.service";
import { DobControlService } from "../../services/dob-control.service";
import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { WindowRef } from "./../windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply/quoteapply-form.component.html"
})
export class QuoteApplyFormComponent implements OnInit, OnDestroy{
    quoteApplyForm: FormGroup;
    callToActionText: string;
    payload: string;
    questionGroups: QuestionGroup[];
    completedPercentage: number;
    private completedPercentageSubscription: Subscription;
    submitted: boolean;
    isAllCompleted = false;
    childrenQuestionGroupKey = "childrenDobGroup";

    constructor(
        private fb: FormBuilder,
        private dobControlService: DobControlService,
        private progressBarService : ProgressBarService,
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
        this.completedPercentage = this.progressBarService.getCompletedPercentage();

        this.completedPercentageSubscription = this.progressBarService.onCompletedPercentageChange()
            .subscribe((percentage: number) => {
                this.completedPercentage = percentage;
            });
    }

    getQuestionGroup(key: string) {
        return this.questionGroups.filter(x => x.key === key)[0];
    }

    apply(isValid: boolean): void {
        //Do it only when isvalid
        this.submitted = true;
        this.quoteApplyService.apply(this.quoteApplyForm.value);
    }

    ngOnDestroy(): void {
        if (this.completedPercentageSubscription) {
            this.completedPercentageSubscription.unsubscribe();
        }
    }
}
