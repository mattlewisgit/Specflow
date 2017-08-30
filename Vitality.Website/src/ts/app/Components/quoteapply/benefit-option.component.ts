import { Component, Input, OnChanges } from "@angular/core";
import { Image } from "../../models/image";
import { BenefitOption } from "../../models/quote/benefit-option";

@Component({
    selector: "benefit-option",
    templateUrl: "./js/app/components/quoteapply/benefit-option.component.html"
})
export class BenefitOptionComponent implements OnChanges {
    @Input()
    permutationId: string;
    @Input()
    benefitOptions: BenefitOption[];
    benefitOption: BenefitOption;
    @Input()
    crossIcon: Image;
    @Input()
    tickIcon: Image;
    // This is a hack to get OnChanges trigger as it doesn't trigger
    // when benefitOption reference doesn't change when permutation array changes inside it
    // OnChanges only trigger when reference changes
    // https://stackoverflow.com/questions/34796901/angular2-change-detection-ngonchanges-not-firing-for-nested-object
    @Input()
    currentTime : Date;

    ngOnChanges(): void {
        this.benefitOption = this.benefitOptions.filter(x => x.permutations.filter(p => p === this.permutationId).length > 0)[0];
    }
}
