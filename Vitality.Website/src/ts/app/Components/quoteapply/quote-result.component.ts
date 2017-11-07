import { Component, Input, OnInit } from "@angular/core";
import { WindowRef } from "./../windowref";

import { QuoteApplyConstants } from "../../constants/quoteapply-constants";

import { ErrorService } from "../../services/error.service";
import { QuoteService } from "../../services/quote.service";

import { Benefit } from "../..//models/quote/benefit";
import { BenefitOption } from "../..//models/quote/benefit-option";
import { QuoteResultRenderingData } from "../..//models/quote/quote-result-rendering-data";

import { GlobalConstants } from "../../constants/global-constants";

@Component({
    selector: "quote-result",
    templateUrl: "./js/app/components/quoteapply/quote-result.component.html"
})
export class QuoteResultComponent implements OnInit {
    quoteResultData: QuoteResultRenderingData;
    permutationResponses: any[] = [];
    permutationIds: Array<number>;
    currentTime: Date;
    quoteApplication: any;
    marketingMessage: string;
    timeoutExpired = false;


    constructor(private errorService: ErrorService,
        private quoteService: QuoteService,
        private winRef: WindowRef) {
    }

    ngOnInit(): void {
        this.quoteResultData = this.winRef.nativeWindow.angularData.quoteResult;
        let delay: number = this.quoteResultData.marketingMessageTimeOut * 1000;
        setTimeout(() => this.timeoutExpired = true, delay);
        this.marketingMessage = this.quoteResultData.marketingMessages[Math.floor(Math.random() * this.quoteResultData.marketingMessages.length)];
        this.permutationIds = new Array<number>();
        for (let permutation of this.quoteResultData.permutations) {
            this.permutationIds.push(permutation.id);
        }

        this.errorService.initialize(this.quoteResultData.serviceOutagePage);
        this.quoteService.getQuoteApplication(this.quoteResultData.referenceNumber)
            .then((data: any) => {
                this.quoteApplication = data;
                this.quoteService.setQuoteApplication(this.quoteApplication);
                this.handlePricingRequest(true);
            });
    }

    handlePricingRequest(sendToHeal: boolean) {
        const quoteRequest = this.quoteService.getPricingRequest(this.quoteResultData.benefits, this.quoteResultData.permutations);

        this.quoteService.savePricingRequest(this.quoteResultData.referenceNumber, quoteRequest);

        this.quoteService.getRtpeQuoteList(quoteRequest)
            .then((data: any) => {
                this.permutationResponses = data.Permutations;
                this.quoteService.savePricingResponse(this.quoteResultData.referenceNumber, data.Permutations);

                if (sendToHeal)
                    for (let permutation of this.permutationResponses) {
                        this.quoteService.healSave(this.quoteResultData.referenceNumber, permutation.PermutationNumber);
                }
            });
    }

    getUnderwritingType(permutationId: number): string {
        for (let benefit of this.quoteResultData.benefits) {
            if (benefit.code === QuoteApplyConstants.keys.underwritingType) {
                const benefitOption = this.getBenefitOption(benefit.benefitOptions, permutationId);
                return benefitOption ? benefitOption.code : GlobalConstants.strings.empty;
            }
        }
        return GlobalConstants.strings.empty;
    }

    getQuotePrice(externalIdentifier: string): string {
        const permutationResponse = this.permutationResponses.filter(x => x.Quote.ExternalQuoteIdentifier === externalIdentifier)[0];
        console.log(permutationResponse);
        if (permutationResponse) {
            return permutationResponse.Quote.PolicyGrossPremium;
        }
        return GlobalConstants.strings.empty;
    }

    getBenefitOption(benefitOptions: BenefitOption[], permutationId: number): BenefitOption {
        return benefitOptions.filter(x => x.permutations.filter(p => p === permutationId).length > 0)[0];
    }

    filterBenefitOptions(permutationId: number): Benefit[] {
        return this.quoteResultData.benefits
            .filter((x: any) => x.benefitOptions
                .filter((p: BenefitOption) => p.permutations.indexOf(permutationId) > -1)
                .length >
                0);
    }

    getBenefitOptionTitle(benefitOptions: BenefitOption[], permutationId: number, benefitTitle: string): string {
        const benefitOption = this.getBenefitOption(benefitOptions, permutationId);
        //cross
        if (!benefitOption) {
            return null;
        }
        //tick
        if (!benefitOption.title) {
            return benefitTitle;
        }

        //text
        return `${benefitTitle} - ${benefitOption.title}`;
    }

    optionChange(benefit: Benefit): void {
        for (let benefitOption of benefit.benefitOptions) {
            benefitOption.permutations = [];
            if (benefit.selectedOption === benefitOption.code) {
                benefitOption.permutations = this.permutationIds;
            }
        }

        this.currentTime = new Date();
        this.handlePricingRequest(false);
    }

    toggleEditBox(benefit: Benefit, enableEdit: boolean): void {
        benefit.isEditing = enableEdit;
    }

    toggleMobileEditBox(benefit: Benefit, enableEdit: boolean, permutationId:string): void {
        if (enableEdit) {
            this.selectedPermutationId = permutationId;
       }
       if(this.selectedPermutationId === permutationId)
        {
            benefit.isMobileEditing = enableEdit;
        }
    }

    toggleHelpText(benefit: Benefit, makeVisible: boolean): void {
        benefit.helpTextVisible = makeVisible;
    }

    selectedPermutationId:string;
    toggleMobileHelpText(benefit: Benefit, makeVisible: boolean, permutationId: string): void {
        if (makeVisible) {
            this.selectedPermutationId = permutationId;
        }

        if (this.selectedPermutationId === permutationId) {
            benefit.mobileHelpTextVisible = makeVisible;
        }
    }
}
