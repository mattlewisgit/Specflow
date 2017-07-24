import { Injectable }   from "@angular/core";
import * as moment from "moment/moment";
import "twix";



import { FormControl } from "@angular/forms";
import { Question } from "../models/question";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";

@Injectable()
export class CallMeBackService {
    interval: number;
    options: {};

    initialize(options: {}) {
        this.options = options;
    }

    populateRanges(question : Question<any>) {
        
    }
}
