import { Injectable }   from "@angular/core";
import { WindowRef } from "../components/windowref";

@Injectable()
export class ErrorService {
    serviceOutagePage: string;
    constructor(private winRef: WindowRef) {
    }

    initialize(serviceOutagePage: string) {
        this.serviceOutagePage = serviceOutagePage;
    }

    handleServiceOutage(): void {
        if (this.serviceOutagePage) {
            this.winRef.nativeWindow.location.href = this.serviceOutagePage;
        }
    }
}
