import { Component, Input, OnInit }      from "@angular/core";
import { WindowRef } from "./../windowref";
import { Subscription } from "rxjs/Subscription";
import { QuoteService } from "../../services/quote.service";

import { BenefitOption } from "../..//models/quote/benefit-option";

@Component({
    selector: "quote-result",
    templateUrl: "./js/app/components/quoteapply/quote-result.component.html"
})
export class QuoteResultComponent implements OnInit {
    quoteResultData: any;
    quotes: any[] = [];

    constructor(
        private quoteService: QuoteService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.quoteResultData = this.winRef.nativeWindow.angularData.quoteResult;
        this.quoteService.callRtpe(this.quoteResultData)
            .then((data: any) => {
                this.quotes = data.Quotes;
            });
    }

    getQuotePrice(externalIdentifier: string): number {
        const quote = this.quotes.filter(x => x.ExternalQuoteIdentifier === externalIdentifier)[0];
        if (quote) {
            return quote.PolicyGrossPremium;
        }
        return 0;
    }
}
