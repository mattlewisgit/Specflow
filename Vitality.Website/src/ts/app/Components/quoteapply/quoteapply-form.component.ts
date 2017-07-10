import { Component, DoCheck, Inject, OnDestroy, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { QuoteApplyService } from "../../services/quoteapply.service";
import { DobControlService } from "../../services/dob-control.service";
import { QuestionControlService } from "../../services/question-control.service";
import { PostcodeService } from "../../services/postcode.service";
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
    renderingData: {};
    okBtnHelpText: string;
    payload: string;
    questionGroups: QuestionGroup[];
    completedPercentage: number;
    private postcodeAsyncValidationSubscription: Subscription;
    submitted: boolean;
    isAllCompleted = false;
    childrenQuestionGroupKey = "childrenDobGroup";

    constructor(
        private postcodeService: PostcodeService,
        private fb: FormBuilder,
        private dobControlService: DobControlService,
        private questionControlService: QuestionControlService,
        private quoteApplyService: QuoteApplyService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        let angularData = this.winRef.nativeWindow.angularData;
        this.questionGroups = angularData.questionGroups;
        this.callToActionText = angularData.callToActionText;
        this.renderingData = { okBtnText: angularData.okBtnText, okBtnHelpText: angularData.okBtnHelpText };
        let childrenQuestionGroup = this.getQuestionGroup(this.childrenQuestionGroupKey);
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
                    var questionGroup = this.getQuestionGroup("postcodeGroup");
                    questionGroup.isInvalid = false;
                    questionGroup.isCompleted = true;
                    this.calculateCompletedPercentage();
                }
            });
    }

    calculateCompletedPercentage() {
        let visibleQuestionGroups = this.questionGroups.filter(x => !x.isHidden);
        this.completedPercentage = (visibleQuestionGroups.filter(x => x.isCompleted).length / visibleQuestionGroups.length) * 100;
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
