import { EventEmitter, Injectable }    from "@angular/core";

@Injectable()
export class ProgressBarService {
    private completedPercentage = 0;
    private completedPercentageChange = new EventEmitter<number>();


    getCompletedPercentage() {
        return this.completedPercentage;
    }

    setCompletedPercentage(noOfCompleted: number, noOfVisible: number) {
        this.completedPercentage = (noOfCompleted / noOfVisible) * 100;
        this.completedPercentageChange.emit(this.completedPercentage);
    }

    onCompletedPercentageChange() {
        return this.completedPercentageChange;
    }
}
