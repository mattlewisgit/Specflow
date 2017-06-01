import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { QuoteApplication } from '../models/quoteapplication';

@Injectable()
export class QuoteApplyService {
    endpoint: string;
    feedType: string;
    mockDataFile: string;
    quoteApplication: QuoteApplication;

  constructor(private http: Http) {}

  setFeedSettings(endpoint: string, feedType: string, mockDataFile: string): void {
      this.endpoint = endpoint;
      this.feedType = feedType;
      this.mockDataFile = mockDataFile;
  }
}
