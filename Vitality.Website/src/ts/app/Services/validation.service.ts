﻿import * as moment from "moment/moment";
import { Injectable }  from "@angular/core";
import { Validators } from "@angular/forms";

import { GlobalConstants } from "../constants/global-constants";
import { PostcodeService } from "./postcode.service";

@Injectable()
export class ValidationService {
    constructor(
        private postcodeService: PostcodeService
    ) {
    }

    getAsyncValidator(validatorName: string, params: any): any {
        switch (validatorName) {
        case "postcodeValidator":
            return this.postcodeValidator(params, this.postcodeService);
        default:
            return null;
        }
    }

    getValidator(validatorName: string, params: any): any {
        switch (validatorName) {
        case "required":
            return Validators.required;
        case "dateValidator":
            return this.dateValidator;
        case "emailValidator":
            return this.emailValidator;
        case "phoneNumberValidator":
            return this.phoneNumberValidator;
        case "textOnly":
            return this.textOnlyValidator;
        case "minLength":
            return Validators.minLength(params.minLength);
        case "maxLength":
            return Validators.maxLength(params.maxLength);
        case "ageRangeValidator":
            return this.ageRangeValidator(params);
        case "futureDateValidator":
            return this.futureDateValidator(params);
        case "excludeDayValidator":
            return this.excludeDayValidator(params);
        case "maxSelectionsValidator":
            return this.maxSelectionsValidator(params);
        default:
            return null;
        }
    }

    dateValidator() {
        return (control: any) => {
            return this.matchDate(control.value) ? null : { "invalidDate": true };
        }
    }

    ageRangeValidator(options: any) {
        // TODO: remove this. proves these params are coming through
        console.log('age: ' + options.maxAge);
        return (control: any) => {
            if (this.matchDate(control.value)) {
                const birthDate = moment(control.value, GlobalConstants.formats.dateFormat);
                const now = moment();
                const years = Math.floor(now.diff(birthDate, GlobalConstants.moments.years, true));
                if ((years >= options.minAge && years < options.maxAge)) {
                    return null;
                }
            }
            return { "invalidAgeRange": true };
        }
    }

    futureDateValidator(options: any) {
        return (control: any) => {
            if (this.matchDate(control.value)) {
                const futureDate = moment(control.value, GlobalConstants.formats.dateFormat);
                const dateDifference = Math.ceil(futureDate.diff(moment(), GlobalConstants.moments.days, true));
                if (dateDifference <= options.maxDaysAhead && dateDifference > -1) {
                    return null;
                }
            }
            return { "invalidFutureDate": true };
        }
    }

    excludeDayValidator(options: any) {
        return (control: any) => {
            if (this.matchDate(control.value)) {
                const date = moment(control.value, GlobalConstants.formats.dateFormat);
                if (date.day() != options.exclude) {
                    return null;
                }
            }
            return { "invalidDate": true };
        }
    }

    emailValidator(control: any) {
        if (control.value
            .match(/^.+@.+\..+$/)) {
            return null;
        }
        return { "invalidEmailAddress": true };
    }

    phoneNumberValidator(control: any) {
        if (control.value
            .replace(/\s/g, "").replace(/\)|\(/g, "").match(/((0)(?!44)[0-9]{10}$)|((0044|044|\+44)[0-9]{10}$)/)) {
                return null;
            }
        return { "invalidPhoneNumber": true };
    }

    textOnlyValidator(control: any) {
        if (control.value
            .match(/^[a-zA-Z \s\.\!\?\"\-]+$/)) {
            return null;
        }
        return { "textOnly": true };
    }

    postcodeValidator(param: any, postcodeService : PostcodeService) {
        return function (control: any): Promise<any> {
            let failedMessage = { "invalidPostcode": true };
            return new Promise<any>((resolve,reject) => {
                if (control.value
                    .match(/^((([gG][iI][rR] {0,}0[aA]{2})|(([aA][sS][cC][nN]|[sS][tT][hH][lL]|[tT][dD][c‌​C][uU]|[bB][bB][nN][‌​dD]|[bB][iI][qQ][qQ]‌​|[fF][iI][qQ][qQ]|[p‌​P][cC][rR][nN]|[sS][‌​iI][qQ][qQ]|[iT][kK]‌​[cC][aA]) {0,}1[zZ]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yxA-HK-XY]?[0-9][‌​0-9]?)|(([a-pr-uwyzA‌​PR-UWYZ][0-9][a-hjk‌​stuwA-HJKSTUW])|([a-‌​pr-uwyzA-PR-UWYZ][a-‌​hk-yA-HK-Y][0-9][abe‌​hmnprv-yABEHMNPRV-Y]‌​))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2})))$/)) {
                    postcodeService.initialize(param.endpoint, param.feedType);
                    postcodeService.lookupPostcode(control.value)
                        .then((data:any) => {
                            if (data.Addresses.length > 0) {
                                postcodeService.postcodeAsyncValidationEmitter.emit(true);
                                return resolve(null);
                            } else {
                                postcodeService.postcodeAsyncValidationEmitter.emit(false);
                                return resolve(failedMessage);
                            }
                        })
                        .catch((error:any) => {
                            return resolve(failedMessage);
                        });
                } else {
                    return resolve(failedMessage);
                }
            });
        }
    }

    maxSelectionsValidator(options: any) {
        // TODO: remove this once param is coming through
        console.log('max selections:' + options.maxSelectionsExceeded);
        return (control: any) => {
            let selectionsCount = 0;
            if (options.selectedCheckboxes) {
                selectionsCount = options.selectedCheckboxes;
            }

            //TODO: remove these lines, hardcoded value to get validation working
            //options.maxSelectionsExceeded = 2;
            console.log('comparing:' + selectionsCount + ' with ' + options.maxSelectionsExceeded);

            return selectionsCount > options.maxSelectionsExceeded ? { "maxSelectionsExceeded": true } : null;
        }
    }

    private matchDate(value: string): boolean {
        return value
            .match(/^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/g)!=null;
    }
}
