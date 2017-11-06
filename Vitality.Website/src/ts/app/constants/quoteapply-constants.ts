export namespace QuoteApplyConstants {
    export const selectors = {
        okBtnGroup: "ok-btn-group",
        postcode: "postcode"
    };
    export const endpoints =
    {
        getApplication: "quote/getapplication/",
        getRtpeQuoteList: "rtpe/quotelist",
        healSave: "quote/healsave",
        savePricingRequest: "quote/savepricingrequest",
        savePricingResponse: "quote/savepricingresponse"
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
};
