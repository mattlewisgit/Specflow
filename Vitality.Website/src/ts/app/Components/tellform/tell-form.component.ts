import { Component, Inject, OnDestroy, Input, OnInit }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { CallMeBackService } from "../../services/call-me-back.service";
import { DobControlService } from "../../services/dob-control.service";
import { QuoteApplyConstants } from "../../constants/quoteapply-constants";
import { QuoteApplyService } from "../../services/quoteapply.service";
import { QuestionControlService } from "../../services/question-control.service";
import { QuestionGroup } from "../../models/question-group";
import { PostcodeService } from "../../services/postcode.service";
import { WindowRef } from "./../windowref";

@Component({
    selector: "tell-form",
    templateUrl: "./js/app/components/tellform/tell-form.component.html"
})
export class TellFormComponent implements OnInit, OnDestroy {
    callToActionText: string;
    completedPercentage: number;
    isAllCompleted = false;
    tellForm: FormGroup;
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

        if (childrenQuestionGroup) {
            this.dobControlService.initialize({
                childrenQuestionGroup: childrenQuestionGroup,
                childDobLastLabel: angularData.additionalData.childDobLastLabel,
                childDobSeperatorLabel: angularData.additionalData.childDobSeperatorLabel
            });
        }

        this.tellForm = new FormGroup({});
        this.tellForm.valueChanges.subscribe(data => {
            this.calculateCompletedPercentage();
        });

        this.postcodeAsyncValidationSubscription = this.postcodeService.onPostcodeAsyncValidation()
            .subscribe((data: boolean) => {
                if (data) {
                    let questionGroup = this.getQuestionGroup(QuoteApplyConstants.keys.postcodeQuestionGroup);
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
        this.quoteApplyService.apply(this.tellForm.value);
    }

    ngOnDestroy(): void {
        if (this.postcodeAsyncValidationSubscription) {
            this.postcodeAsyncValidationSubscription.unsubscribe();
        }
    }
}
