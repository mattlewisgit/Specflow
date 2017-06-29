import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { ErrorService } from "./error.service";

@Injectable()
export class QuoteApplyService {

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    apply(formData: any): Promise<any> {
        return this.http.post("/api/apply/", formData)
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }
}
