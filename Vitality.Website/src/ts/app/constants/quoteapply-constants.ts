﻿export namespace QuoteApplyConstants {
    export const selectors = {
        okBtnGroup: "ok-btn-group",
        postcode: "postcode"
    };
    export const endpoints =
    {
        getApplication: "/api/quote/getapplication/"
    };
    export const keys = {
        callbackTimeQuestionGroup: "callbackTimeQuestionGroup",
        callbackDate: "callbackDate",
        callbackTime: "callbackTime",
        child1Dob: "child1Dob",
        childrenQuestionGroup: "childrenDobGroup",
        membersToInsure: "membersToInsure",
        noOfChildren: "noOfChildren",
        postcodeQuestionGroup: "postcodeGroup",
        featuresAndBenefitsGroup: "featuresAndBenefits",
        moratorium: "A01",
        underwritingType: "policyUwChoiceCode"
    };
    export const gender =
    {
        male: "M",
        female: "F"
    };
    export const previouslyInsured =
    {
        no: "PI0",
        yes: "PI1"
    };
    export const roleType = {
        employeePrincipal: "EMP",
        partner: "PTR",
        child: "CHI",
        adultDependant: "ADT"
    };
    export const values = {
        me: "me",
        mePartner: "mepartner",
        mePartnerChildren: "mepartnerchildren",
        meChildren: "mechildren",
        productCode: "PHC"
    };
    export const formNames = {
        quoteAndApply: "Quote Apply Form",
        quotePaymentDetails: "Payment Details Form"
    };
    export const fieldNames = {
        billingPostcode: "billingPostcode",
        selectBillingAddress: "selectBillingAddress",
        address1: "address1",
        address2: "address2",
        address3: "address3",
        address4: "address4",
        postcode: "postcode",
    }; 
};
