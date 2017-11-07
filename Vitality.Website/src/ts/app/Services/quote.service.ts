import { Injectable }   from "@angular/core";
import * as _ from "underscore";
import { ErrorService } from "./error.service";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { PricingRequest } from "./../models/quote/pricing-request";
import { PermutationRequest } from "./../models/quote/permutation-request";
import { QuoteApplication } from "./../models/quote/quote-application";
import { IndividualQuoteRequest } from "./../models/quote/individual-quote-request";
import { Life } from "./../models/quote/life";
import { Module } from "./../models/quote/module";
import { Benefit } from "./../models/quote/benefit";
import { Permutation } from "./../models/quote/permutation";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";
import { GlobalConstants } from "../constants/global-constants";

@Injectable()
export class QuoteService {
    lives = new Array<Life>();
    quoteApplication: QuoteApplication;

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    getQuoteApplication(referenceNumber: string): Promise<any>  {
        return this.http.get(`${GlobalConstants.endpoints.bslGet}${encodeURIComponent(QuoteApplyConstants.endpoints.getApplication + referenceNumber)}`)
            .toPromise()
            .then(response => response.json().BslResponse);
    }

    setQuoteApplication(application: any) {
        this.quoteApplication = new QuoteApplication(application);
        console.log(this.quoteApplication.coverStartDate.format(GlobalConstants.formats.dateFormat));
        this.getLives();
    }

    getRtpeQuoteList(pricingRequest: PricingRequest): Promise<any> {
        return this.callBslPost(QuoteApplyConstants.endpoints.getRtpeQuoteList,
            {
                FeedSettings: {},
                Permutations: pricingRequest.permutations
            });
    }

    savePricingRequest(referenceNumber: string, pricingRequest: PricingRequest): Promise<any> {
        return this.callBslPost(QuoteApplyConstants.endpoints.savePricingRequest,
            {
                ReferenceNumber: referenceNumber,
                Permutations: pricingRequest.permutations
            });
    }

    savePricingResponse(referenceNumber: string, pricingResponse: any): Promise<any> {
        return this.callBslPost(QuoteApplyConstants.endpoints.savePricingResponse,
            {
                ReferenceNumber: referenceNumber,
                PermutationResponses: pricingResponse
            });
    }

    healSave(referenceNumber: string, permutationNumber: number): Promise<any> {
        return this.callBslPost(QuoteApplyConstants.endpoints.healSave,
            {
                ReferenceNumber: referenceNumber,
                PermutationNumber: permutationNumber
            });
    }

    callBslPost(endpoint: string, postData: any): Promise<any> {
        return this.http.post(GlobalConstants.endpoints.bslPost + encodeURIComponent(endpoint), postData)
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }

    getPricingRequest(benefits: Benefit[], permutations: Permutation[]): PricingRequest {
        const moduleBenefits = benefits.filter(b => b.isModule);
        const otherBenefits = benefits.filter(b => !b.isModule && b.code);
        const permutationRequests = new Array<PermutationRequest>();
        let i = 0;
        for (let permutation of permutations) {
            i = i + 1;
            const modules = new Array<Module>();

            for (let code of permutation.coreModules) {
                modules.push(new Module(code));
            }
            for (let moduleBenefit of moduleBenefits) {
                const moduleBenefitsOption = moduleBenefit.benefitOptions
                    .filter(x => x.permutationIds.filter(p => p === permutation.id).length > 0)[0];
                if (moduleBenefitsOption) {
                    modules.push(new Module(moduleBenefitsOption.code));
                }
            }

            const individualQuoteRequest = new IndividualQuoteRequest();
            for (let otherBenefit of otherBenefits) {
                const otherBenefitsOption = otherBenefit.benefitOptions
                    .filter(x => x.permutationIds.filter(p => p === permutation.id).length > 0)[0];
                if (otherBenefitsOption) {
                    individualQuoteRequest[otherBenefit.code] = otherBenefitsOption.code;
                }
            }

            individualQuoteRequest.claimFreeYears = this.quoteApplication.noOfClaimFreeYears;
            individualQuoteRequest.competitorRenwalPrem = 0.0;
            individualQuoteRequest.externalQuoteIdentifier = permutation.externalIdentifier;
            individualQuoteRequest.occupation = 1;
            individualQuoteRequest.policyPostcode = this.quoteApplication.postcode;
            individualQuoteRequest.previousInsurer = 0;
            individualQuoteRequest.previousInsurerClaims = this.quoteApplication.noOfClaims;
            individualQuoteRequest.isPreviouslyInsured = this.quoteApplication.insuredStatus;
            // If  previously insured default to 1. This will change when ABC project goes live
            individualQuoteRequest.previousInsurerYears = individualQuoteRequest.isPreviouslyInsured ? 1 : 0;
            individualQuoteRequest.previouslyInsured = individualQuoteRequest.isPreviouslyInsured
                ? QuoteApplyConstants.previouslyInsured.yes
                : QuoteApplyConstants.previouslyInsured.no;

            individualQuoteRequest.productCode = QuoteApplyConstants.values.productCode;
            individualQuoteRequest.renewalDate = this.quoteApplication.coverStartDate.format(GlobalConstants.formats.dateFormat);
            individualQuoteRequest.startDate = individualQuoteRequest.renewalDate;
            individualQuoteRequest.lives = this.lives;
            individualQuoteRequest.modules = modules;

            const permutationRequest = new PermutationRequest();
            permutationRequest.individualQuoteRequest = individualQuoteRequest;
            permutationRequest.permutationNumber = i;
            permutationRequests.push(permutationRequest);
        }

        return new PricingRequest(permutationRequests);
    }

    private getLives(): void {
        this.lives.push(new Life(this.quoteApplication.dateOfBirth.format(GlobalConstants.formats.dateFormat),
            QuoteApplyConstants.gender.male,
            0,
            QuoteApplyConstants.roleType.employeePrincipal));
        if (this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartner ||
            this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartnerChildren) {
            this.lives.push(new Life(this.quoteApplication.partnerDateOfBirth.format(GlobalConstants.formats.dateFormat),
                QuoteApplyConstants.gender.male,
                this.lives.length,
                QuoteApplyConstants.roleType.partner));
        }
        if (this.quoteApplication.membersToInsure === QuoteApplyConstants.values.meChildren ||
            this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartnerChildren) {

            for (let i = 1; i <= this.quoteApplication.noOfChildren; i++) {
                this.lives.push(new Life(this.quoteApplication[`child${i}Dob`].format(GlobalConstants.formats.dateFormat),
                    QuoteApplyConstants.gender.male,
                    this.lives.length,
                    QuoteApplyConstants.roleType.child));
            }
        }
    }
}
