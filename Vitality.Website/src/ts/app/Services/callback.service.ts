import { Injectable }   from "@angular/core";
import * as moment from "moment/moment";
import { extendMoment } from "momentrange/dist/moment-range.js";

import { FormControl } from "@angular/forms";
import { Question } from "../models/question";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";

@Injectable()
export class CallbackService {
    interval: number;
    additionalData: {};

    initialize(options: {}) {
        this.additionalData = options;
    }
    populateRanges(question: Question<any>) {
        console.log(question);
        console.log(this.additionalData);
    }
}
