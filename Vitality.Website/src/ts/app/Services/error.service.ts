import { Injectable }   from "@angular/core";
import { WindowRef } from "../components/windowref";

@Injectable()
export class ErrorService {
    constructor(private winRef: WindowRef) {
    }

    handleServiceOutage(): void {
        this.winRef.nativeWindow.location.href = this.winRef.nativeWindow.angularData.serviceOutagePage;
    }
}
