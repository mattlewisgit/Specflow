import { Validators } from "@angular/forms";

export class ValidationService {
    static getValidatorErrorMessage(validatorName: string, validatorValue?: any) {
        let config = {
            "required": "Required",
            "invalidDate": "Invalid Date",
            "invalidEmailAddress": "Invalid email address",
            "invalidPhoneNumber": "Invalid phone number",
            "minLength": "Minimum length ${validatorValue.requiredLength}",
            "maxLength": "Maximum length ${validatorValue.requiredLength}"
        };

        return config[validatorName];
    }

    static getValidator(validatorName: string) {
        let config = {
            "required": Validators.required,
            "dateValidator": this.dateValidator,
            "emailValidator": this.emailValidator,
            "phoneNumberValidator": this.phoneNumberValidator,
            "minlength": Validators.minLength,
            "maxlength": Validators.maxLength
        };

        return config[validatorName];
    }

    static dateValidator(control: any) {
        if (control.value.match(/^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/g)) {
            return null;
        } else {
            return { 'invalidDate': true };
        }
    }

    static emailValidator(control: any) {
        if (control.value.match(/[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/)) {
            return null;
        } else {
            return { 'invalidEmailAddress': true };
        }
    }

    static phoneNumberValidator(control: any) {
        if (control.value.match(/^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$/)) {
            return null;
        } else {
            return { 'invalidPhoneNumber': true };
        }
    }
}

