import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class PostcodeService {
    endpoint: string;
    feedType: string;

    constructor(private http: Http) {}

    initialize(endpoint: string, feedType:string): void {
        this.endpoint = endpoint;
        this.feedType = feedType;
    }

    lookupPostcode(postcode: string): Promise<any> {
        return this.http.post(`/api/bsl/post?bslendpoint=${encodeURIComponent(this.endpoint + postcode)}`,
                { FeedType: this.feedType })
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.handleError);
    }

    private handleError(error: any): void {
        throw error.message || error;
    }
}

