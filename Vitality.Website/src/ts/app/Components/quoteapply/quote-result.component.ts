import { Component, Input, OnInit } from "@angular/core";
import { WindowRef } from "./../windowref";
import { Subscription } from "rxjs/Subscription";
import { ErrorService } from "../../services/error.service";
import { QuoteService } from "../../services/quote.service";

import { Benefit } from "../..//models/quote/benefit";
import { BenefitOption } from "../..//models/quote/benefit-option";
import { Permutation } from "../..//models/quote/permutation";
import { QuoteResultRenderingData } from "../..//models/quote/quote-result-rendering-data";

import { GlobalConstants } from "../../constants/global-constants";

@Component({
    selector: "quote-result",
    templateUrl: "./js/app/components/quoteapply/quote-result.component.html"
})
export class QuoteResultComponent implements OnInit {
    quoteResultData: QuoteResultRenderingData;
    quotes: any[] = [];
    permutationIds: Array<string>;
    currentTime: Date;
    quoteApplication: any;

    constructor(private errorService: ErrorService,
        private quoteService: QuoteService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.quoteResultData = this.winRef.nativeWindow.angularData.quoteResult;
        this.permutationIds = new Array<string>();
        for (let permutation of this.quoteResultData.permutations) {
            this.permutationIds.push(permutation.id);
        }

        this.errorService.initialize(this.quoteResultData.serviceOutagePage);
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
        this.quoteService.callRtpe(this.quoteResultData.benefits, this.quoteResultData.permutations)
            .then((data: any) => {
                this.quotes = data.Quotes;
            });
    }

    getQuotePrice(externalIdentifier: string): string {
        const quote = this.quotes.filter(x => x.ExternalQuoteIdentifier === externalIdentifier)[0];
        if (quote) {
            return quote.PolicyGrossPremium;
        }
        return GlobalConstants.strings.empty;
    }

    getBenefitOption(benefitOptions: BenefitOption[], permutationId: string): BenefitOption {
        return benefitOptions.filter(x => x.permutations.filter(p => p === permutationId).length > 0)[0];
    }

    filterBenefitOptions(permutationId: string): Benefit[] {
        return this.quoteResultData.benefits
            .filter((x: any) => x.benefitOptions
                .filter((p: BenefitOption) => p.permutations.indexOf(permutationId) > -1)
                .length >
                0);
    }

    getBenefitOptionTitle(benefitOptions: BenefitOption[], permutationId: string, benefitTitle: string): string {
        const benefitOption = this.getBenefitOption(benefitOptions, permutationId);
        //cross
        if (!benefitOption)
            return null;
        //tick
        if (!benefitOption.title)
            return benefitTitle;

        //text
        return benefitTitle + " - " + benefitOption.title;
    }

    enableEdit(benefit: Benefit): void {
        for (let bnt of this.quoteResultData.benefits) {
            bnt.isEditing = false;
        }
        benefit.isEditing = true;
    }

    optionChange(benefit: Benefit): void {
        for (let benefitOption of benefit.benefitOptions) {
            benefitOption.permutations = [];
            if (benefit.selectedOption === benefitOption.code) {
                benefitOption.permutations = this.permutationIds;
            }
        }

        this.currentTime = new Date();
        this.getQuotes();
    }

    showHelpText(benefit: Benefit): void {
        benefit.helpTextVisible = true;
    }

    closeEditBox(benefit: Benefit): void {
        benefit.isEditing = false;
    }

    closeHelpText(benefit: Benefit): void {
        benefit.helpTextVisible = false;
    }
}
