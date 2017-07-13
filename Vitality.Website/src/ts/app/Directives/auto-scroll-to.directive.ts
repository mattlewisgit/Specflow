import { Directive, ElementRef, HostListener, Inject, Input, AfterViewInit, Optional} from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref";
import { Subscription } from "rxjs/Subscription";

import { PostcodeService } from "../services/postcode.service";

@Directive({
    selector: "[auto-scroll-to]"
})
export class AutoScrollTo implements AfterViewInit{
    @Input("isGroupCompleted") isGroupCompleted : boolean;
    private btnTagName = "BUTTON";
    private dropdownTagName = "SELECT";
    private formInputFieldSelector = "input,select";
    private classSelector = ".";
    private hideClass = "hide";
    private okBtnGroupClass = "ok-btn-group";

    private postcodeAsyncValidationSubscription: Subscription;
    private okBtnGroup: Element;
    private currentElement: HTMLElement;
    private currentElementParent: HTMLElement;

    constructor(element: ElementRef, @Inject(DOCUMENT) private document: any, private postcodeService: PostcodeService, private winRef: WindowRef) {
        this.currentElement = element.nativeElement;
        this.currentElementParent = this.currentElement.parentElement;
    }

    ngAfterViewInit() {
        if (this.currentElement.id === "postcode") {
            this.postcodeAsyncValidationSubscription = this.postcodeService.onPostcodeAsyncValidation()
                .subscribe((data: boolean) => {
                    this.hideShowOkBtnGroup(data);
                });
        }
    }

    @HostListener("keyup", ["$event"])
    onkeyup(event: MouseEvent) {
            this.hideShowOkBtnGroup(this.isGroupCompleted);
    }

    private hideShowOkBtnGroup(show: boolean) {
        if (show) {
            this.showOkBtnGroup();
        } else {
            this.hideOkBtnGroups();
        }
    }

    @HostListener("keydown", ["$event"])
    onkeydown(event: MouseEvent) {
        if (this.isGroupCompleted) {
            if (event.which === 9) {
                event.preventDefault();
            }
            if (event.shiftKey && event.which === 9) {
                this.changeFocus(false);
            } else if (event.which === 13 || event.which === 9) {
                this.changeFocus(true);
            }
        }
    }

    @HostListener("click", ["$event"])
    onclick(event: MouseEvent) {
        if (this.currentElement.tagName === this.btnTagName) {
            this.changeFocus(true);
        }
    }

    @HostListener("change", ["$event"])
    onchange(event: MouseEvent) {
        //Just do a timeout to trigger this after model changed
        setTimeout(() => this.onDropDownChange(), 0);
    }

    private onDropDownChange() {
        if (this.currentElement.tagName === this.dropdownTagName && this.isGroupCompleted) {
            this.changeFocus(true);
        }
    }

    @HostListener("focus", ["$event"])
    onFocus(event: MouseEvent) {
        if (this.currentElement.tagName !== this.btnTagName) {
            if (this.currentElement.tagName !== this.dropdownTagName) {
                this.hideOkBtnGroups();
                if (this.isGroupCompleted) {
                    this.showOkBtnGroup();
                }
            }
            this.handleScrolling();
        }
    }

    private showOkBtnGroup() {
        if (!this.okBtnGroup) {
            this.okBtnGroup = this.questionElement.querySelector(this.classSelector+ this.okBtnGroupClass);
        }
        // okBtnGroup still can be null
        if (this.okBtnGroup) {
            this.okBtnGroup.classList.remove(this.hideClass);
        }
    }

    private hideOkBtnGroups() {
        const okBtnGroups = this.document.getElementsByClassName(this.okBtnGroupClass);
        for (let okBtnGroup of okBtnGroups) {
            okBtnGroup.classList.add(this.hideClass);
        }
    }

    private changeFocus(goDown: boolean) {
        const nextOrPrevSibiling = goDown
            ? this.currentElementParent.nextElementSibling
            : this.currentElementParent.previousElementSibling;
        if (nextOrPrevSibiling) {
            const nextOrPrevQuestion = nextOrPrevSibiling.querySelector(this.formInputFieldSelector);
            if (nextOrPrevQuestion) {
                (nextOrPrevQuestion as HTMLElement).focus();
                return;
            }
        }

        let inputElement = null;
        let questionGroupElement = this.questionGroupElement;
        while (inputElement == null) {
            questionGroupElement = (goDown
                ? questionGroupElement.nextElementSibling
                : questionGroupElement.previousElementSibling) as HTMLElement;
            inputElement = questionGroupElement.querySelector(this.formInputFieldSelector);
        }
        if (inputElement) {
            (inputElement as HTMLElement).focus();
        }
    }

    private get questionElement(): HTMLElement {
        return this.currentElementParent.parentElement;
    }
    private get questionGroupElement() : HTMLElement {
        return this.currentElementParent.parentElement.parentElement;
    }

    private handleScrolling(): void {
        const startY = this.currentYPosition();
        const stopY = this.elmYPosition();
        const distance = stopY > startY ? stopY - startY : startY - stopY;
        if (distance < 100) {
            this.winRef.nativeWindow.scrollTo(0, stopY);
        } else {
            let speed = Math.round(distance / 100);
            if (speed >= 20) speed = 20;
            const step = Math.round(distance / 100);
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
        return y - (this.winRef.nativeWindow.screen.height/2 -200);
    }
}
