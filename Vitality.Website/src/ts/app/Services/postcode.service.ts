import { Injectable }    from "@angular/core";
import { Headers, Http } from "@angular/http";
import { ErrorService } from "./error.service";
import "rxjs/add/operator/toPromise";

@Injectable()
export class PostcodeService {
    endpoint: string;
    feedType: string;

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    initialize(endpoint: string, feedType: string): void {
        this.endpoint = endpoint;
        this.feedType = feedType;
    }

    lookupPostcode(postcode: string): Promise<any> {
        return this.http.post(`/api/bsl/post?bslendpoint=${encodeURIComponent(this.endpoint + postcode)}`,
                { FeedType: this.feedType })
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }
}