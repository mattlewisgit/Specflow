import { EventEmitter, Injectable }    from "@angular/core";

@Injectable()
export class FooterBarService {

    completedPercentageEmitter = new EventEmitter<number>();

    onCompletedPercentageChange() {
        return this.completedPercentageEmitter;
    }

    submitEmitter = new EventEmitter<boolean>();
    onSubmitClicked() {
        return this.submitEmitter;
    }
}
