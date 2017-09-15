import { Component, Input, OnInit } from "@angular/core";
import { WindowRef } from "./../windowref";
import { Subscription } from "rxjs/Subscription";

import { QuoteApplyConstants } from "../../constants/quoteapply-constants";

import { ErrorService } from "../../services/error.service";
import { QuoteService } from "../../services/quote.service";

import { BenefitOption } from "../..//models/quote/benefit-option";

@Component({
    selector: "quote-result",
    templateUrl: "./js/app/components/quoteapply/quote-result.component.html"
})
export class QuoteResultComponent implements OnInit {
    quoteResultData: any;
    quotes: any[] = [];
    currentTime: Date;
    quoteApplication: any;

    constructor(
        private errorService: ErrorService,
        private quoteService: QuoteService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.quoteResultData = this.winRef.nativeWindow.angularData.quoteResult;
        this.errorService.initialize(this.quoteResultData.serviceOutagePage);
        this.quoteApplication = this.quoteService.quoteApplication;
        this.quoteService.getQuoteApplication(this.quoteResultData.referenceId)
            .then((data: any) => {
                this.quoteApplication = data;
                this.quoteService.setQuoteApplication(this.quoteApplication);
                this.getQuotes();
            })
            // TODO remove catch before going live
            .catch((err: any) => {
                this.quoteApplication = this.quoteService.quoteApplication;
                this.quoteService.setQuoteApplication(this.quoteApplication);
                this.getQuotes();
            });
    }

    getQuotes(): void {
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

    getBenefitOption(benefitOptions: BenefitOption[], permutationId:string): any {
        return  benefitOptions.filter(x => x.permutations.filter(p => p === permutationId).length > 0)[0];
    }

    getUnderwritingType(permutationId: string): BenefitOption {
        for (let benefit of this.quoteResultData.benefits) {
            if (benefit.code === QuoteApplyConstants.keys.underwritingType) {
                const benefitOption = this.getBenefitOption(benefit.benefitOptions, permutationId);
                return benefitOption ? benefitOption.code : null;
            }
        }
        return null;
    }

    enableEdit(benefit: any): void {
        for (let bnt of this.quoteResultData.benefits) {
            bnt.isEditing = false;
        }
        benefit.isEditing = true;
    }

    optionChange(benefitId: string, benefitOptionCode: string): void {
        this.quoteResultData.tickIcon = null;
        const permutationIds = new Array<string>();
        for (let permutation of this.quoteResultData.permutations) {
            permutationIds.push(permutation.id);
        }
        for (let benefit of this.quoteResultData.benefits) {
            if (benefit.id === benefitId) {
                for (let benefitOption of benefit.benefitOptions) {
                    benefitOption.permutations = [];
                    if (benefitOptionCode === benefitOption.code) {
                        benefitOption.permutations = permutationIds;
                    }
                }
            }
        }
        this.currentTime = new Date();
        this.getQuotes();
    }
}
