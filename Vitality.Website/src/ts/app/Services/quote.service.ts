import { Injectable }   from "@angular/core";
import * as _ from "underscore";
import { ErrorService } from "./error.service";
import { Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { QuoteRequest } from "./../models/quote/quote-request";
import { PermutationRequest } from "./../models/quote/permutation-request";
import { IndividualQuoteRequest } from "./../models/quote/individual-quote-request";
import { Life } from "./../models/quote/life";
import { Module } from "./../models/quote/module";
import { Benefit } from "./../models/quote/benefit";
import { Permutation } from "./../models/quote/permutation";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";
import { GlobalConstants } from "../constants/global-constants";

@Injectable()
export class QuoteService {
    endpoint = "rtpe/quotelist";
    lives = new Array<Life>();
    quoteApplication: any;

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    getQuoteApplication(referenceNumber: string): Promise<any>  {
        return this.http.get(`${QuoteApplyConstants.endpoints.bslGet}${encodeURIComponent(QuoteApplyConstants.endpoints.getApplication + referenceNumber)}`)
            .toPromise()
            .then(response => response.json());
    }

    setQuoteApplication(application: any) {
        this.quoteApplication = application;
        this.getLives();
    }

    callRtpe(benefits: Benefit[], permutations: Permutation[]): Promise<any> {
        const requestData = this.getRtpeRequest(benefits, permutations);
        return this.http.post(GlobalConstants.endpoints.bslEndpoint + encodeURIComponent(this.endpoint), requestData)
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }

    private getRtpeRequest(benefits: Benefit[], permutations: Permutation[]): QuoteRequest {
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
                    .filter(x => x.permutations.filter(p => p === permutation.id).length > 0)[0];
                if (moduleBenefitsOption) {
                    modules.push(new Module(moduleBenefitsOption.code));
                }
            }

            const individualQuoteRequest = new IndividualQuoteRequest();
            for (let otherBenefit of otherBenefits) {
                const otherBenefitsOption = otherBenefit.benefitOptions
                    .filter(x => x.permutations.filter(p => p === permutation.id).length > 0)[0];
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
            individualQuoteRequest.isPreviouslyInsured = this.quoteApplication.insuredStatus === 1;
            // If  previously insured default to 1. This will change when ABC project goes live
            individualQuoteRequest.previousInsurerYears = individualQuoteRequest.isPreviouslyInsured ? 1 : 0;
            individualQuoteRequest.previouslyInsured = individualQuoteRequest.isPreviouslyInsured
                ? QuoteApplyConstants.previouslyInsured.yes
                : QuoteApplyConstants.previouslyInsured.no;

            individualQuoteRequest.productCode = QuoteApplyConstants.values.productCode;
            individualQuoteRequest.renewalDate = this.quoteApplication.coverStartDate;
            individualQuoteRequest.startDate = this.quoteApplication.coverStartDate;
            individualQuoteRequest.lives = this.lives;
            individualQuoteRequest.modules = modules;

            const permutationRequest = new PermutationRequest();
            permutationRequest.individualQuoteRequest = individualQuoteRequest;
            permutationRequest.permutationNumber = i;
            permutationRequests.push(permutationRequest);
        }

        return new QuoteRequest(permutationRequests);
    }

    private getLives(): void {
        this.lives.push(new Life(this.quoteApplication.dateOfBirth,
            QuoteApplyConstants.gender.male,
            0,
            QuoteApplyConstants.roleType.employeePrincipal));
        if (this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartner ||
            this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartnerChildren) {
            this.lives.push(new Life(this.quoteApplication.partnerDateOfBirth,
                QuoteApplyConstants.gender.male,
                this.lives.length,
                QuoteApplyConstants.roleType.partner));
        }
        if (this.quoteApplication.membersToInsure === QuoteApplyConstants.values.meChildren ||
            this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartnerChildren) {

            for (let i = 1; i <= this.quoteApplication.noOfChildren; i++) {
                this.lives.push(new Life(this.quoteApplication[`child${i}Dob`],
                    QuoteApplyConstants.gender.male,
                    this.lives.length,
                    QuoteApplyConstants.roleType.child));
            }
        }
    }
}
