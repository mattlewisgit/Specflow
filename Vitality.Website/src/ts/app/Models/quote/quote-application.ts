import * as moment from "moment/moment";

export class QuoteApplication {
    addressLine1: string;
    addressLine2: string;
    childDob1: moment.Moment;
    childDob2: moment.Moment;
    childDob3: moment.Moment;
    childDob4: moment.Moment;
    childDob5: moment.Moment;
    coverStartDate: moment.Moment;
    dateOfBirth: moment.Moment;
    emailAddress: string;
    featuresAndBenefits: string[];
    firstName: string;
    insuredStatus: boolean;
    lastName: string;
    marketingPermission: boolean;
    membersToInsure: string;
    noOfChildren: number;
    noOfClaimFreeYears: number;
    noOfClaims: number;
    partnerDateOfBirth: moment.Moment;
    phoneNumber: string;
    postcode: string;
    title: string;
    town: string;

    constructor(quoteApplication: any) {
        this.addressLine1 = quoteApplication.AddressLine1;
        this.addressLine2 = quoteApplication.AddressLine2;
        this.childDob1 = moment(quoteApplication.childDob1);
        this.childDob2 = moment(quoteApplication.childDob2);
        this.childDob3 = moment(quoteApplication.childDob3);
        this.childDob4 = moment(quoteApplication.childDob4);
        this.childDob5 = moment(quoteApplication.childDob5);
        this.coverStartDate = moment(quoteApplication.CoverStartDate);
        this.dateOfBirth = moment(quoteApplication.DateOfBirth);
        this.emailAddress = quoteApplication.EmailAddress;
        this.featuresAndBenefits = quoteApplication.FeaturesAndBenefits;
        this.firstName = quoteApplication.FirstName;
        this.insuredStatus = quoteApplication.InsuredStatus;
        this.lastName = quoteApplication.LastName;
        this.marketingPermission = quoteApplication.MarketingPermission;
        this.membersToInsure = quoteApplication.MembersToInsure;
        this.noOfChildren = quoteApplication.NoOfChildren;
        this.noOfClaimFreeYears = quoteApplication.NoOfClaimFreeYears;
        this.noOfClaims = quoteApplication.NoOfClaims;
        this.partnerDateOfBirth = moment(quoteApplication.PartnerDateOfBirth);
        this.phoneNumber = quoteApplication.PhoneNumber;
        this.postcode = quoteApplication.Postcode;
        this.title = quoteApplication.Title;
        this.town = quoteApplication.Town;
    }
}
