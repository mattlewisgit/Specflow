import { Component, Input, OnInit, ChangeDetectorRef }      from "@angular/core";
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

    constructor(
        private quoteService: QuoteService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.quoteResultData = this.winRef.nativeWindow.angularData.quoteResult;
        console.log(this.quoteResultData);
        console.log(this.quoteService.quoteApplication);
    }

    getBenefitOption(benefitId: string, benefitOptions: BenefitOption[]): BenefitOption {
        console.log(benefitId + benefitOptions);
        return benefitOptions.filter(x => x.benefitId === benefitId)[0];
    }
}
