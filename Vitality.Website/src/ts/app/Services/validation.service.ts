﻿import { Validators } from "@angular/forms";

export class ValidationService {
    static getValidatorErrorMessage(validatorName: string, validatorValue?: any) {
        let config = {
            "required": "Required",
            "invalidDate": "Invalid Date",
            "invalidEmailAddress": "Invalid email address",
            "invalidPhoneNumber": "Invalid phone number",
            "minLength": "Minimum length ${validatorValue.requiredLength}",
            "maxLength": "Maximum length ${validatorValue.requiredLength}",
            "invalidPostcode": "Invalid Postcode"
        };

        return config[validatorName];
    }

    static getValidator(validatorName: string, params: any) :any{
        switch (validatorName) {
        case "required":
            return Validators.required;
        case "dateValidator":
            return this.dateValidator;
        case "emailValidator":
            return this.emailValidator;
        case "phoneNumberValidator":
            return this.phoneNumberValidator;
        case "minlength":
            return Validators.minLength;
        case "maxlength":
            return Validators.maxLength;
        case "ageRangeValidator":
            return this.ageRangeValidator(params);
        case "postcodeValidator":
            return this.postcodeValidator;
        default: return null;
        }
    }

    static dateValidator(control: any) {
        if (control.value.match(/^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/g)) {
            return null;
        } else {
            return { "invalidDate": true };
        }
    }

    static ageRangeValidator(options: any) {
        return (control: any) => {
            if (this.dateValidator(control) == null) {
                const dateParts = control.value.split("/");
                const birthDate = new Date(dateParts[2], dateParts[1], dateParts[0]);
                const now = new Date();
                let years = (now.getFullYear() - birthDate.getFullYear());

                if (now.getMonth() < birthDate.getMonth() ||
                    now.getMonth() === birthDate.getMonth() && now.getDate() < birthDate.getDate()) {
                    years--;
                }
                if (years >= options.minAge && years < options.maxAge) {
                    return null;
                }
            }
            return { "invalidAgeRange": true };
        }
    }

    static emailValidator(control: any) {
        if (control.value
            .match(/[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/)) {
            return null;
        }
        return { "invalidEmailAddress": true };
    }

    static phoneNumberValidator(control: any) {
        if (control.value
            .match(/^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$/)) {
            return null;
        }
        return { "invalidPhoneNumber": true };
    }

    static postcodeValidator(control: any) {
        if (control.value
            .match(/^((([gG][iI][rR] {0,}0[aA]{2})|(([aA][sS][cC][nN]|[sS][tT][hH][lL]|[tT][dD][c‌​C][uU]|[bB][bB][nN][‌​dD]|[bB][iI][qQ][qQ]‌​|[fF][iI][qQ][qQ]|[p‌​P][cC][rR][nN]|[sS][‌​iI][qQ][qQ]|[iT][kK]‌​[cC][aA]) {0,}1[zZ]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yxA-HK-XY]?[0-9][‌​0-9]?)|(([a-pr-uwyzA‌​PR-UWYZ][0-9][a-hjk‌​stuwA-HJKSTUW])|([a-‌​pr-uwyzA-PR-UWYZ][a-‌​hk-yA-HK-Y][0-9][abe‌​hmnprv-yABEHMNPRV-Y]‌​))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2})))$/)) {
            return null;
        }
        return { "invalidPostcode": true };
    }
}
