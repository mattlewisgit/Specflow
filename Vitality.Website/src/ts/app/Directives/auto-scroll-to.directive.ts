import { AfterViewInit, Directive, ElementRef, HostListener, Inject, Input, Optional } from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref";
import { Subscription } from "rxjs/Subscription";

import { GlobalConstants } from "../constants/global-constants";
import { PostcodeService } from "../services/postcode.service";
import { QuoteApplyConstants } from "../constants/quoteapply-constants";
import { Common } from "../modules/common.module";

@Directive({
    selector: "[auto-scroll-to]"
})
export class AutoScrollTo implements AfterViewInit {
    @Input("isGroupCompleted")
    isGroupCompleted: boolean;

    private readonly minDistance = 30;
    private readonly scrollStepDistance = 100;
    private readonly scrollSpeed = 20;

    private currentElement: HTMLElement;
    private currentElementParent: HTMLElement;
    private okBtnGroup: Element;
    private postcodeAsyncValidationSubscription: Subscription;

    constructor(element: ElementRef,
        @Inject(DOCUMENT) private document: any,
        private postcodeService: PostcodeService,
        private common: Common,
        private winRef: WindowRef) {
        this.currentElement = element.nativeElement;
        this.currentElementParent = this.currentElement.parentElement;
    }

    ngAfterViewInit() {
        if (this.currentElement.id === QuoteApplyConstants.selectors.postcode) {
            this.postcodeAsyncValidationSubscription = this.postcodeService.onPostcodeAsyncValidation()
                .subscribe((data: boolean) => {
                    this.hideShowOkBtnGroup(data);
                });
        }
    }

    @HostListener("keyup", ["$event"])
    onkeyup(event: KeyboardEvent) {
        if (this.currentElement.tagName !== GlobalConstants.tagNames.dropdown) {
            this.hideShowOkBtnGroup(this.isGroupCompleted);
        }
    }

    @HostListener("keydown", ["$event"])
    onkeydown(event: KeyboardEvent) {
        if (this.isGroupCompleted) {
            if (event.which === GlobalConstants.keyboardKeys.enter) {
                event.preventDefault();
                this.changeFocus(true, this.isGroupCompleted);
            }
        } else {
            if (event.shiftKey && event.which === GlobalConstants.keyboardKeys.tab) {
                event.preventDefault();
                this.changeFocus(false, false);
            } else if (event.which === GlobalConstants.keyboardKeys.tab) {
                event.preventDefault();
                this.changeFocus(true, false);
            }
        }
    }

    @HostListener("click", ["$event"])
    onclick(event: MouseEvent) {
        if (this.currentElement.tagName === GlobalConstants.tagNames.button) {
            this.changeFocus(true, true);
        } else if (this.currentElement.tagName === GlobalConstants.tagNames.dropdown &&
            event.which === GlobalConstants.keyboardKeys.zero) {
            this.changeFocus(true,false);
        }
    }

    @HostListener("mousedown", ["$event"])
    mousedown(event: MouseEvent) {
        if (this.currentElement.tagName === GlobalConstants.tagNames.dropdown) {
            const startY = this.currentYPosition();
            const stopY = this.elmYPosition();
            if (Math.abs(startY - stopY) > this.minDistance) {
                event.preventDefault();
                this.handleScrolling(startY, stopY);
            }
        }
    }

    @HostListener("focus", ["$event"])
    onFocus(event: MouseEvent) {
        if (this.currentElement.tagName !== GlobalConstants.tagNames.button) {
            this.hideOkBtnGroups();
            if (this.currentElement.tagName !== GlobalConstants.tagNames.dropdown) {
                if (this.isGroupCompleted) {
                    this.showOkBtnGroup();
                }
            }
            this.handleScrolling(this.currentYPosition(), this.elmYPosition());
        }
    }

    private hideShowOkBtnGroup(show: boolean) {
        if (show) {
            this.showOkBtnGroup();
        } else {
            this.hideOkBtnGroups();
        }
    }

    private showOkBtnGroup() {
        if (!this.okBtnGroup && this.questionElement) {
            this.okBtnGroup =
                this.questionGroupElement.querySelector(GlobalConstants.selectors.classIdentifier +
                    QuoteApplyConstants.selectors.okBtnGroup);
        }
        // okBtnGroup still can be null
        if (this.okBtnGroup) {
            console.log("enter if 2");
            this.okBtnGroup.classList.remove(GlobalConstants.selectors.hide);
        }
    }

    private hideOkBtnGroups() {
        const okBtnGroups = this.document.getElementsByClassName(QuoteApplyConstants.selectors.okBtnGroup);
        for (let okBtnGroup of okBtnGroups) {
            okBtnGroup.classList.add(GlobalConstants.selectors.hide);
        }
    }

    private changeFocus(goDown: boolean, changeGroup: boolean) {
        const nextOrPrevSibiling = goDown
            ? this.questionElement.nextElementSibling
            : this.questionElement.previousElementSibling;
        if (nextOrPrevSibiling) {
            const nextOrPrevQuestion = nextOrPrevSibiling.querySelector(GlobalConstants.selectors.formInputFields);
            if (nextOrPrevQuestion && changeGroup === false) {
                (nextOrPrevQuestion as HTMLElement).focus();
                return;
            } else
                changeGroup = true;
        }

        if (changeGroup) {

            let questionGroupElement = this.questionGroupElement;

            questionGroupElement = (goDown
                ? questionGroupElement.nextElementSibling
                : questionGroupElement.previousElementSibling) as HTMLElement;

            if (questionGroupElement != null) {
                let element = questionGroupElement.querySelector(GlobalConstants.selectors.formInputFields);

                while (element === null && (goDown
                    ? questionGroupElement.nextElementSibling
                    : questionGroupElement.previousElementSibling) !== null) {

                    questionGroupElement = ((goDown
                        ? questionGroupElement.nextElementSibling
                        : questionGroupElement.previousElementSibling) as HTMLElement);

                    element = questionGroupElement.querySelector(GlobalConstants.selectors.formInputFields);
                }
                if (element !== null)
                    (element as HTMLElement).focus();
            }
        }
    }

    private get questionElement(): HTMLElement {
        return this.common.getParentElementByClass(GlobalConstants.questionElementClass, this.currentElement);
    }
    private get questionGroupElement(): HTMLElement {
        return this.common.getParentElementByTag(GlobalConstants.tagNames.questionGroup, this.currentElement);
    }

    private handleScrolling(startY: number, stopY: number): void {
        const distance = stopY > startY ? stopY - startY : startY - stopY;
        if (distance < this.scrollStepDistance) {
            this.winRef.nativeWindow.scrollTo(0, stopY);
        } else {
            let speed = Math.round(distance / this.scrollStepDistance);
            if (speed >= this.scrollSpeed) speed = this.scrollSpeed;
            const step = Math.round(distance / this.scrollStepDistance);
            let leapY = stopY > startY ? startY + step : startY - step;
            let timer = 0;
            if (stopY > startY) {
                for (let i = startY; i < stopY; i += step) {
                    this.scrollTo(leapY, timer * speed);
                    leapY += step;
                    if (leapY > stopY) leapY = stopY;
                    timer++;
                }
            } else {
                for (let i = startY; i > stopY; i -= step) {
                    this.scrollTo(leapY, timer * speed);
                    leapY -= step;
                    if (leapY < stopY) leapY = stopY;
                    timer++;
                }
            }
        }
    }

    private scrollTo(yPoint: number, duration: number) {
        setTimeout(() => {
            this.winRef.nativeWindow.scrollTo(0, yPoint);
        }, duration);
        return;
    }

    private currentYPosition() {
        // Firefox, Chrome, Opera, Safari
        if (self.pageYOffset) return self.pageYOffset;
        // Internet Explorer 6 - standards mode
        if (this.document && this.document.scrollTop)
            return this.document.scrollTop;
        // Internet Explorer 6, 7 and 8
        if (this.document.body.scrollTop) return this.document.body.scrollTop;
        return 0;
    }

    private elmYPosition() {
        const elm = this.currentElement;
        let y = elm.offsetTop;
        let node = elm;
        while (node.offsetParent && node.offsetParent !== this.document.body) {
            node = (node.offsetParent as HTMLElement);
            y += node.offsetTop;
        }
        return y - (this.winRef.nativeWindow.screen.height / 2 - 200);
    }
}
