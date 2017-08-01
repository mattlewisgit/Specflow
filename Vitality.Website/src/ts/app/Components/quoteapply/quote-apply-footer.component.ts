import { Component, Input, OnInit, ChangeDetectorRef }      from "@angular/core";
import { WindowRef } from "./../windowref";
import { Subscription } from "rxjs/Subscription";
import { FooterBarService } from "../../services/footer-bar.service";

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
        private ref: ChangeDetectorRef,
        private footerBarService: FooterBarService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        const quoteFooterData = this.winRef.nativeWindow.angularData.quoteApplyFooter;
        this.callToActionText = quoteFooterData.callToActionText;
        this.enableProgressBar = quoteFooterData.enableProgressBar;
        this.completedPercentageSubscription = this.footerBarService.onCompletedPercentageChange()
            .subscribe((data: number) => {
                if (this.completedPercentage !== data) {
                    this.completedPercentage = data;
                    this.isAllCompleted = this.completedPercentage === 100;
                    this.ref.detectChanges();
                }
            });
    }

    submit(): void {
        this.footerBarService.submitEmitter.emit(true);
    }
}
