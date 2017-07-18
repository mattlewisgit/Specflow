import { Component, Inject, OnDestroy, Input, OnInit }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { DobControlService } from "../../services/dob-control.service";
import { QuoteApplyConstants } from "../../constants/quoteapply-constants";
import { QuoteApplyService } from "../../services/quoteapply.service";
import { QuestionControlService } from "../../services/question-control.service";
import { QuestionGroup } from "../../models/question-group";
import { PostcodeService } from "../../services/postcode.service";
import { WindowRef } from "./../windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply/quoteapply-form.component.html"
})
export class QuoteApplyFormComponent implements OnInit, OnDestroy {
    callToActionText: string;
    completedPercentage: number;
    isAllCompleted = false;
    quoteApplyForm: FormGroup;
    okBtnHelpText: string;
    payload: string;
    private postcodeAsyncValidationSubscription: Subscription;
    questionGroups: QuestionGroup[];
    renderingData: {};
    submitted: boolean;

    constructor(
        private dobControlService: DobControlService,
        private fb: FormBuilder,
        private postcodeService: PostcodeService,
        private questionControlService: QuestionControlService,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        const angularData = this.winRef.nativeWindow.angularData;
        this.questionGroups = angularData.questionGroups;
        this.callToActionText = angularData.callToActionText;
        this.renderingData = { okBtnText: angularData.okBtnText, okBtnHelpText: angularData.okBtnHelpText };
        const childrenQuestionGroup = this.getQuestionGroup(QuoteApplyConstants.keys.childrenQuestionGroup);
        this.questionControlService.setQuestionGroups(this.questionGroups);

        this.dobControlService.initialize({
            childrenQuestionGroup: childrenQuestionGroup,
            childDobLastLabel: angularData.childDobLastLabel,
            childDobSeperatorLabel: angularData.childDobSeperatorLabel
        });

        this.quoteApplyForm = new FormGroup({});
        this.quoteApplyForm.valueChanges.subscribe(data => {
            this.calculateCompletedPercentage();
        });

        this.postcodeAsyncValidationSubscription = this.postcodeService.onPostcodeAsyncValidation()
            .subscribe((data: boolean) => {
                if (data) {
                    var questionGroup = this.getQuestionGroup(QuoteApplyConstants.keys.postcodeQuestionGroup);
                    questionGroup.isInvalid = false;
                    questionGroup.isCompleted = true;
                    this.calculateCompletedPercentage();
                }
            });
    }

    calculateCompletedPercentage() {
        const visibleQuestionGroups = this.questionGroups.filter(x => !x.isHidden);
        this.completedPercentage = (visibleQuestionGroups.filter(x => x.isCompleted).length /
                visibleQuestionGroups.length) *
            100;
        this.isAllCompleted = this.completedPercentage === 100;
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
        if (this.postcodeAsyncValidationSubscription) {
            this.postcodeAsyncValidationSubscription.unsubscribe();
        }
    }
}
