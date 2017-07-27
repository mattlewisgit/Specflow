import { EventEmitter, Injectable }    from "@angular/core";

@Injectable()
export class ProgressBarService {

    completedPercentageEmitter = new EventEmitter<number>();
    onCompletedPercentageChange() {
        return this.completedPercentageEmitter;
    }
}
