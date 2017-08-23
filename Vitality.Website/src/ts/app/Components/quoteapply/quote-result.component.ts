import { Component, Input, OnInit, ChangeDetectorRef }      from "@angular/core";
import { WindowRef } from "./../windowref";
import { Subscription } from "rxjs/Subscription";

@Component({
    selector: "quote-result",
    templateUrl: "./js/app/components/quoteapply/quote-result.component.html"
})
export class QuoteResultComponent implements OnInit {
    quoteResultData: any;
    constructor(
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.quoteResultData = this.winRef.nativeWindow.angularData.quoteResult;
        console.log(this.quoteResultData);
    }
}
