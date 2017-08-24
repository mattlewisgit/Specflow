import { Injectable }   from "@angular/core";
import * as _ from "underscore";
import * as moment from "moment/moment";
import { ErrorService } from "./error.service";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { MomentExtendedService } from "../services/moment-extended.service";

@Injectable()
export class QuoteService {
    endpoint = "rtpe/quotelist";

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    quoteApplication = {
        child1Age:"04/02/2012",
        child2Dob: "04/08/2002",
        child3Dob: "",
        child4Dob: "",
        child5Dob: "",
        coverStartDate: "03/09/2017",
        dateOfBirth: "03/02/1999",
        emailAddress: "sd@dsfs.com",
        firstName: "Janaka",
        insuredStatus: "1",
        lastName: "Lakmal",
        marketingPermission: "1",
        membersToInsure: "mepartnerchildren",
        noOfChildren: "2",
        noOfClaimFreeYears: "2",
        noOfClaims: "2",
        partnerDateOfBirth: "04/03/1994",
        phoneNumber: "03434334232",
        postcode: "BH48dx",
        title: "mr"
    }

    callRtpe(): Promise<any> {
        return this.http.post(`/api/bsl/post?bslendpoint=${encodeURIComponent(this.endpoint)}`,
            { "FeedSettings": { "Key": null, "FeedType": null, "MockDataFile": "http://presalesapi.vitality.co.uk/QuoteResponse.json", "Name": null, "Secret": null, "Url": null }, "Permutations": [{ "IndividualQuoteRequest": { "ClaimFreeYears": 5, "CompetitorRenwalPrem": 0.0, "ExcessAmount": 0, "ExcessType": 1, "ExternalQuoteIdentifier": "Core_Cover", "HospitalList": 0, "Lives": [{ "LifeAgeOrBirthDate": { "Age": 30 }, "Gender": 0, "LifeNumber": 0, "RoleType": 0 }], "Modules": [{ "ModuleCode": "P01" }, { "ModuleCode": "P20" }, { "ModuleCode": "P03" }], "Occupation": 1, "PolicyPostcode": "SE1 1AA", "PolicyUwChoiceCode": 2, "PreviousInsurer": 0, "PreviousInsurerClaims": 0, "PreviousInsurerYears": 2, "IsPreviouslyInsured": false, "PreviouslyInsured": "PI1", "ProductCode": "PHC", "RenewalDate": "26/08/2017", "StartDate": "24/08/2017" }, "PermutationNumber": 1 }, { "IndividualQuoteRequest": { "ClaimFreeYears": 5, "CompetitorRenwalPrem": 0.0, "ExcessAmount": 0, "ExcessType": 1, "ExternalQuoteIdentifier": "Core_plus_Outpatient", "HospitalList": 0, "Lives": [{ "LifeAgeOrBirthDate": { "Age": 30 }, "Gender": 0, "LifeNumber": 0, "RoleType": 0 }], "Modules": [{ "ModuleCode": "P01" }, { "ModuleCode": "P20" }, { "ModuleCode": "P03" }, { "ModuleCode": "P05" }], "Occupation": 1, "PolicyPostcode": "SE1 1AA", "PolicyUwChoiceCode": 2, "PreviousInsurer": 0, "PreviousInsurerClaims": 0, "PreviousInsurerYears": 2, "IsPreviouslyInsured": false, "PreviouslyInsured": "PI1", "ProductCode": "PHC", "RenewalDate": "26/08/2017", "StartDate": "24/08/2017" }, "PermutationNumber": 2 }] }).toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }
}
