import { Injectable, Component, Input, OnChanges } from "@angular/core";
import { WindowRef } from "../../components/windowref";

import { QuoteApplyConstants } from "../../constants/quoteapply-constants";

@Component({
    selector: "permutation-button",
    templateUrl: "./js/app/components/quoteapply/permutation-button.component.html"
})
export class PermutationButtonComponent implements OnChanges {
    @Input()
    alternativeCallToAction: string;
    @Input()
    alternativeCallToActionText: string;
    @Input()
    callToAction: string;
    @Input()
    callToActionText: string;
    @Input()
    optionCode: string;

    isBuyNow: boolean;

    constructor(
        private winRef: WindowRef) {
    }

    ngOnChanges(): void {
        this.isBuyNow = this.optionCode === QuoteApplyConstants.keys.moratorium;
    }

    handleAction(): void {
        if (this.isBuyNow) {
            this.winRef.nativeWindow.location.href = this.callToAction;
        } else
        {
            this.winRef.nativeWindow.location.href = this.alternativeCallToAction;
        }
    }
}
