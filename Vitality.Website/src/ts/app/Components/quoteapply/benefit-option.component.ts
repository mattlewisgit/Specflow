import { Component, Input, OnInit } from "@angular/core";
import { Image } from "../../models/image";
import { BenefitOption } from "../../models/quote/benefit-option";

@Component({
    selector: "benefit-option",
    templateUrl: "./js/app/components/quoteapply/benefit-option.component.html"
})
export class BenefitOptionComponent implements OnInit {
    @Input()
    benefitId: string;
    @Input()
    benefitOptions: BenefitOption[];
    benefitOption: BenefitOption;
    @Input()
    crossIcon: Image;
    @Input()
    tickIcon: Image;

    ngOnInit(): void {
        this.benefitOption = this.benefitOptions.filter(x => x.benefitId === this.benefitId)[0];
    }
}
