import { Injectable }   from "@angular/core";
import * as _ from "underscore";
import * as moment from "moment/moment";

import { MomentExtendedService } from "../services/moment-extended.service";
import { OpeningHours } from "../models/opening-hours";
import { Question } from "../models/question";
import { GlobalConstants } from "../constants/global-constants";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";

@Injectable()
export class CallbackService {
    interval: number;
    openingHours = new Array<OpeningHours>();

    initialize(options: any) {
        this.interval = options.interval;
        for (let weekday of moment.weekdays()) {
            let openingHour: OpeningHours;
            // add safely
            try {
                const openingHoursArr = options[weekday.toLowerCase()].split("-");
                const [ startHour, startMinute, endHour, endMinute ]= (_.flatten(openingHoursArr.map((x: string) => x.split(":"))));
                openingHour = new OpeningHours(weekday, startHour, startMinute, endHour, endMinute);
            } catch (ex) {
                // Default 8 to 18.
                openingHour = new OpeningHours(weekday, 8, 0, 18, 0);
            }
            this.openingHours.push(openingHour);
        }
    }

    populateRanges(callbackDate: any, question: Question<any>) {
        callbackDate = moment(callbackDate, GlobalConstants.formats.dateFormat);
        const callbackDateOpeningHours = this.openingHours
            .filter(x => x.weekDay === callbackDate.format(GlobalConstants.formats.dddd))[0];
        const starts = MomentExtendedService.setTime(callbackDate.clone(),
            callbackDateOpeningHours.startHour,
            callbackDateOpeningHours.startMinute);
        const ends = MomentExtendedService.setTime(callbackDate.clone(),
            callbackDateOpeningHours.endHour,
            callbackDateOpeningHours.endMinute);

        question.relatedData = MomentExtendedService.getRanges(this.interval, starts, ends);
    }
}
