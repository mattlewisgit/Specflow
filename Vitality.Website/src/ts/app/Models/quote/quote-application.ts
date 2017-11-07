import * as moment from "moment/moment";

export class QuoteApplication {
    addressLine1: string;
    addressLine2: string;
    child1Dob: moment.Moment;
    child2Dob: moment.Moment;
    child3Dob: moment.Moment;
    child4Dob: moment.Moment;
    child5Dob: moment.Moment;
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
        this.child1Dob = moment(quoteApplication.Child1Dob);
        this.child2Dob = moment(quoteApplication.Child2Dob);
        this.child3Dob = moment(quoteApplication.Child3Dob);
        this.child4Dob = moment(quoteApplication.Child4Dob);
        this.child5Dob = moment(quoteApplication.Child5Dob);
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
