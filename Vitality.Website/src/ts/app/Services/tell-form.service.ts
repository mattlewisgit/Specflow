import { EventEmitter, Injectable }    from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { ErrorService } from "./error.service";


@Injectable()
export class TellFormService {
    submitEmitter = new EventEmitter<boolean>();
    onSubmitClicked() {
        return this.submitEmitter;
    }

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    submit(formData: any): Promise<any> {
        return this.http.post("/api/apply/", formData)
            .toPromise()
            .then(response => response.json().BslResponse)
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }
}
