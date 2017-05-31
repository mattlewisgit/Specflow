import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { QuoteApplyForm } from '../models/quoteapplyform';

@Injectable()
export class QuoteApplyService {
    endpoint: string;
    feedType: string;
    mockDataFile: string;
    quoteApplyForm: QuoteApplyForm;

  constructor(private http: Http) {}

  setFeedSettings(endpoint: string, feedType: string, mockDataFile: string): void {
      this.endpoint = endpoint;
      this.feedType = feedType;
      this.mockDataFile = mockDataFile;
  }

  //Impliment postQuoteApplyForm() when ready
  //private handleError(error: any): void {
  //    throw error.message || error;
  //}
}
