import { Component, Inject, Input, OnInit }      from "@angular/core";
import { WindowRef } from "./../windowref";
import { Subscription } from "rxjs/Subscription";
import { ProgressBarService } from "../../services/progress-bar.service";
import { TellFormService } from "../../services/tell-form.service";

@Component({
    selector: "quote-apply-footer",
    templateUrl: "./js/app/components/quoteapply/quote-apply-footer.component.html"
})
export class QuoteApplyFooterComponent implements OnInit {
    callToActionText: string;
    completedPercentage = 0;
    isAllCompleted = false;
    enableProgressBar = false;
    private completedPercentageSubscription: Subscription;

    constructor(
        private progressBarService: ProgressBarService,
        private tellFormService: TellFormService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        const quoteFooterData = this.winRef.nativeWindow.angularData.quoteApplyFooter;
        this.callToActionText = quoteFooterData.callToActionText;
        this.enableProgressBar = quoteFooterData.enableProgressBar;
        this.completedPercentageSubscription = this.progressBarService.onCompletedPercentageChange()
            .subscribe((data: number) => {
                this.completedPercentage = data;
                this.isAllCompleted = this.completedPercentage === 100;
            });
    }

    submit(): void {
        this.tellFormService.submitEmitter.emit(true);
    }
}
