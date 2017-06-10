import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class QuoteApplyService {
    endpoint: string;
    feedType: string;
    mockDataFile: string;

  constructor(private http: Http) {}

  setFeedSettings(endpoint: string, feedType: string, mockDataFile: string): void {
      this.endpoint = endpoint;
      this.feedType = feedType;
      this.mockDataFile = mockDataFile;
  }
}
