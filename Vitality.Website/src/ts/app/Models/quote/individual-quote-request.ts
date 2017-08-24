import { Life } from "./life";
import { Module } from "./module";

export class IndividualQuoteRequest {
    claimFreeYears: number;
    competitorRenwalPrem: number;
    excessAmount: number;
    excessType: number;
    externalQuoteIdentifier: string;
    hospitalList: number;
    occupation: number;
    policyPostcode: string;
    policyUwChoiceCode: number;
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
