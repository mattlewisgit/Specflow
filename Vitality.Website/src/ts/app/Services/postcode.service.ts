import { EventEmitter, Injectable }    from "@angular/core";
import { ErrorService } from "./error.service";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

@Injectable()
export class PostcodeService {
    endpoint: string;
    feedType: string;

    postcodeAsyncValidationEmitter = new EventEmitter<boolean>();
    onPostcodeAsyncValidation() {
        return this.postcodeAsyncValidationEmitter;
    }

    updatePostcodeEmitter = new EventEmitter<string>();
    onUpdatePostcode() {
        return this.updatePostcodeEmitter;
    }

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
