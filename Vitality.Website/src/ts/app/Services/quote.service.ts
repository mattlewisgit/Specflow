import { Injectable }   from "@angular/core";
import * as _ from "underscore";
import * as moment from "moment/moment";
import { ErrorService } from "./error.service";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { MomentExtendedService } from "./moment-extended.service";

import { QuoteRequest } from "./../models/quote/quote-request";
import { PermutationRequest } from "./../models/quote/permutation-request";
import { IndividualQuoteRequest } from "./../models/quote/individual-quote-request";
import { Life } from "./../models/quote/life";
import { Module } from "./../models/quote/module";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";
import { GlobalConstants } from "../constants/global-constants";

@Injectable()
export class QuoteService {
    endpoint = "rtpe/quotelist";
    lives = new Array<Life>();

    constructor(private http: Http,
        private errorService: ErrorService) {
    }
    // TODO : remove this before going live... For testing purpose only
    quoteApplication = {
        child1Dob: "04/02/2012",
        child2Dob: "04/08/2002",
        child3Dob: "",
        child4Dob: "",
        child5Dob: "",
        coverStartDate: "03/10/2017",
        dateOfBirth: "03/02/1999",
        emailAddress: "sd@dsfs.com",
        firstName: "Janaka",
        insuredStatus: 1,
        lastName: "Lakmal",
        marketingPermission: 1,
        membersToInsure: "mepartnerchildren",
        noOfChildren: 2,
        noOfClaimFreeYears: 2,
        noOfClaims: 2,
        partnerDateOfBirth: "04/03/1994",
        phoneNumber: "03434334232",
        postcode: "BH48dx",
        title: "mr"
    }

    getQuoteApplication(referenceId: string): any {
        return this.http.get(QuoteApplyConstants.endpoints.getApplication + referenceId)
            .toPromise()
            .then(response => response.json())
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }

    callRtpe(application: any, permutations: any[]): Promise<any> {
        if (application) {
            this.quoteApplication = application;
            this.getLives();
        }
        const requestData = this.getRtpeRequest(permutations);
        return this.http.post(GlobalConstants.endpoints.bslEndpoint + encodeURIComponent(this.endpoint), requestData)
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }

    private getRtpeRequest(quoteResultData: any): QuoteRequest {
        const moduleBenefits = quoteResultData.benefits.filter((b:any) => b.isModule);
        const otherBenefits = quoteResultData.benefits.filter((b: any) => !b.isModule && b.code);
        const permutationRequests = new Array<PermutationRequest>();
        let i = 0;
        for (let permutation of quoteResultData.permutations) {
            i = i + 1;
            const modules = new Array<Module>();

            for (let code of permutation.coreModules) {
                modules.push(new Module(code));
            }
            for (let moduleBenefit of moduleBenefits) {
                const moduleBenefitsOption = moduleBenefit.benefitOptions
                    .filter((x: any) => x.permutations.filter((p: string) => p === permutation.id).length > 0)[0];
                if (moduleBenefitsOption) {
                    modules.push(new Module(moduleBenefitsOption.code));
                }
            }

            const individualQuoteRequest = new IndividualQuoteRequest();
            for (let otherBenefit of otherBenefits) {
                const otherBenefitsOption = otherBenefit.benefitOptions
                    .filter((x: any) => x.permutations.filter((p: string) => p === permutation.id).length > 0)[0];
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

            individualQuoteRequest.previouslyInsured = this.quoteApplication.insuredStatus === 1
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
