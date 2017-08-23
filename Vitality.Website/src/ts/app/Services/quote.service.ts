import { Injectable }   from "@angular/core";
import * as _ from "underscore";
import * as moment from "moment/moment";

import { MomentExtendedService } from "../services/moment-extended.service";

@Injectable()
export class QuoteService {
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
}
