import { Life } from "./life";
import { Module } from "./module";

export class IndividualQuoteRequest {
    claimFreeYears: number;
    competitorRenwalPrem: number;
    excessAmount: string;
    excessType: string;
    externalQuoteIdentifier: string;
    hospitalList: string;
    occupation: number;
    policyPostcode: string;
    policyUwChoiceCode: string;
    previousInsurer: number;
    previousInsurerClaims: number;
    previousInsurerYears: number;
    isPreviouslyInsured: boolean;
    previouslyInsured: string;
    productCode: string;
    renewalDate: string;
    startDate: string;
    lives: Life[];
    modules: Module[];
}
