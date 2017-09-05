import { EventEmitter, Injectable }    from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { ErrorService } from "./error.service";


@Injectable()
export class TellFormService {
    formData: any;

    constructor(private http: Http,
        private errorService: ErrorService) {
    }

    submit(postAction:string, formData: any): Promise<any> {
        return this.http.post(postAction, formData)
            .toPromise()
            .then(response => response.json())
            .catch(this.errorService.handleServiceOutage.bind(this.errorService));
    }
}
