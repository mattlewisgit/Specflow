export namespace QuoteApplyConstants {
    export const selectors = {
        okBtnGroup: "ok-btn-group",
        postcode: "postcode"
    };
    export const keys = {
        callbackTimeQuestionGroup: "callbackTimeQuestionGroup",
        callbackDate: "callbackDate",
        callbackTime: "callbackTime",
        child1Dob: "child1Dob",
        childrenQuestionGroup: "childrenDobGroup",
        membersToInsure: "membersToInsure",
        noOfChildren: "noOfChildren",
        postcodeQuestionGroup: "postcodeGroup"
    };
    export const labels = {
        emptyLabel: ""
    };
    export const values = {
        me: "me",
        mePartner: "mepartner",
        mePartnerChildren: "mepartnerchildren",
        meChildren: "mechildren"
    }

    // Drive these from Sitecore
    export const roleType = {
        employeePrincipal: "EMP",
        partner: "PTR",
        child: "CHI",
        adultDependant: "ADT"
    };
    export const excessAmount =
    {
        zero: "EL1",
        hundred: "EL3",
        twoHundredFifty: "EL6",
        fiveHundred: "EL11",
        thousand: "EL21"
    };
    export const excessType =
    {
        perClaim: "XTC",
        perPolicyYear: "XTP"
    };
    export const gender =
    {
        male: "M",
        female: "F"
    };
    export const hospitalNetwork =
    {
        local: "HL1",
        countrywide: "HL2",
        Premier: "HL3"
    };
};
