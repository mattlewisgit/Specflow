import { Directive, ElementRef, HostListener, OnInit, Output } from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref";
import { Subscription } from "rxjs/Subscription";

import { QuestionControlService } from "../services/question-control.service";
import { GlobalConstants } from "../constants/global-constants";

@Directive({
    selector: "[limit-multi-select]"
})
export class LimitMultiSelect implements OnInit {
    private checkBoxes: any;
    private currentElement: HTMLElement;
    private multiSelectOptionsSubscription: Subscription;

    constructor(element: ElementRef, private qcs: QuestionControlService, private winRef: WindowRef) {
        this.currentElement = element.nativeElement;
    }

    ngOnInit(): void {
        this.checkBoxes = this.currentElement.getElementsByTagName(GlobalConstants.tagNames.input);
        this.multiSelectOptionsSubscription = this.qcs.multiSelectOptionsEmitter
            .subscribe((maxNumberReached: boolean) => {
                this.toggleCheckBoxes(maxNumberReached);
            });
    }

    private toggleCheckBoxes(disable: boolean) {
        for (let elem of this.checkBoxes) {
            if (!elem.checked) {
                elem.disabled = disable;
            }
        }
    }
}
