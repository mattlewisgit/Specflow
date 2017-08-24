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

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    quoteApplication = {
        child1Dob: "04/02/2012",
        child2Dob: "04/08/2002",
        child3Dob: "",
        child4Dob: "",
        child5Dob: "",
        coverStartDate: "03/09/2017",
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

    callRtpe(permutations: any[]): Promise<any> {
        let requestData= this.getRtpeRequest(permutations);
        return this.http.post(`/api/bsl/post?bslendpoint=${encodeURIComponent(this.endpoint)}`,requestData)
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }

    private getRtpeRequest(permutations: any[]): QuoteRequest {
        const lives = this.getLives();
        const modules = new Array<Module>();
        modules.push(new Module("P01"));
        modules.push(new Module("P20"));
        modules.push(new Module("P03"));

        let permutationRequests = new Array<PermutationRequest>();
        let i = 0;
        for (let permutation of permutations) {
            console.log(permutation);
            i=i+1;
            const individualQuoteRequest = new IndividualQuoteRequest();
            individualQuoteRequest.claimFreeYears= this.quoteApplication.noOfClaimFreeYears;
            individualQuoteRequest.competitorRenwalPrem = 0.0;
            individualQuoteRequest.excessAmount = QuoteApplyConstants.excessAmount.hundred;
            individualQuoteRequest.excessType = QuoteApplyConstants.excessType.perClaim;
            individualQuoteRequest.externalQuoteIdentifier = permutation.externalIdentifier;
            individualQuoteRequest.hospitalList = QuoteApplyConstants.hospitalNetwork.countrywide;
            individualQuoteRequest.occupation = 1;
            individualQuoteRequest.policyPostcode = this.quoteApplication.postcode;
            individualQuoteRequest.policyUwChoiceCode = "A01";
            individualQuoteRequest.previousInsurer = 0;
            individualQuoteRequest.previousInsurerClaims = this.quoteApplication.noOfClaims;
            individualQuoteRequest.isPreviouslyInsured = this.quoteApplication.insuredStatus === 1;
            individualQuoteRequest.previouslyInsured = this.quoteApplication.insuredStatus === 1 ? "PI0" : "PI1";
            individualQuoteRequest.productCode ="PHC";
            individualQuoteRequest.renewalDate = this.quoteApplication.coverStartDate;
            individualQuoteRequest.startDate = this.quoteApplication.coverStartDate;
            individualQuoteRequest.lives = lives;
            individualQuoteRequest.modules= modules;
            const permutationRequest = new PermutationRequest();
            permutationRequest.individualQuoteRequest = individualQuoteRequest;
            permutationRequest.permutationNumber = i;
            permutationRequests.push(permutationRequest);
        }

        return new QuoteRequest(permutationRequests);
    }

    private getLives(): Life[] {
        const lives = new Array<Life>();
        lives.push(new Life(this.getAge(this.quoteApplication.dateOfBirth),
            QuoteApplyConstants.gender.male,
            0,
            QuoteApplyConstants.roleType.employeePrincipal));
        if (this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartner ||
            this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartnerChildren) {
            lives.push(new Life(this.getAge(this.quoteApplication.partnerDateOfBirth),
                QuoteApplyConstants.gender.male,
                lives.length,
                QuoteApplyConstants.roleType.partner));
        }
        if (this.quoteApplication.membersToInsure === QuoteApplyConstants.values.meChildren ||
            this.quoteApplication.membersToInsure === QuoteApplyConstants.values.mePartnerChildren) {

            for (let i = 1; i <= this.quoteApplication.noOfChildren; i++) {
                lives.push(new Life(this.getAge(this.quoteApplication[`child${i}Dob`]),
                    QuoteApplyConstants.gender.male,
                    lives.length,
                    QuoteApplyConstants.roleType.child));
            }
        }
        return lives;
    }

    private getAge(birthDayString: string): number {
        console.log(birthDayString);
        const birthDate = moment(birthDayString, GlobalConstants.formats.dateFormat);
        const now = moment();
        const age = Math.floor(now.diff(birthDate, GlobalConstants.moments.years, true));
        return age;
    }
}
