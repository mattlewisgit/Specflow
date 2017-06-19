import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class PostcodeService {
    endpoint: string;

    constructor(private http: Http) { }

    setFeedSettings(endpoint: string): void {
        this.endpoint = endpoint;
    }

    lookupPostcode(postcode: string): Promise<any> {
        return this.http.get(this.endpoint + postcode)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }

    private handleError(error: any): void {
        throw error.message || error;
    }
}
