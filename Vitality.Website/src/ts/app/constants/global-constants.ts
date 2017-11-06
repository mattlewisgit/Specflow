export namespace GlobalConstants {
    export const tagNames= {
        button: "BUTTON",
        dropdown: "SELECT",
        input: "INPUT",
        questionGroup: "QUESTION-GROUP"
    };
    export const questionElementClass = "question";

    export const endpoints =
    {
            bslGet: "/api/bsl/get?bslendpoint=",
            bslPost: "/api/bsl/post?bslendpoint=",
    };
    export const selectors = {
        classIdentifier: ".",
        formInputFields: "input,select",
        hide: "hide"
    };
    export const strings = {
        empty: ""
    };
    export const keyboardKeys = {
        zero: 0,
        enter: 13,
        tab: 9
    };
    export const formats = {
        dateFormat: "DD/MM/YYYY",
        dddd: "dddd",
        hoursMinutes: "HH:mm"
    };
    export const moments = {
        days: "days" as "Q",
        years: "years" as "Q",
        minutes: "minutes" as "Q"
    };
    export const validators = {
        ageRangeValidator: "ageRangeValidator",
        dateValidator: "dateValidator",
        emailValidator: "emailValidator",
        excludeDayValidator: "excludeDayValidator",
        futureDateValidator: "futureDateValidator",
        maxLength: "maxLength",
        minLength: "minLength",
        required : "required",
        phoneNumberValidator: "phoneNumberValidator",
        postcodeValidator: "postcodeValidator",
        textOnly: "textOnly"
    };
};
