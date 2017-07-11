import { Directive, ElementRef, HostListener, Inject, Input, Optional} from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref";

@Directive({
    selector: "[auto-scroll-to]"
})
export class AutoScrollTo {
    @Input("isGroupCompleted") isGroupCompleted : boolean;
    private btnTagName = "BUTTON";
    private dropdownTagName = "SELECT";
    private formInputFieldSelector = "input,select";
    private hideClass = "hide";
    private okBtnGroupSelector = "ok-btn-group";
    private questionGroupSelector = "question";

    private okBtnGroup: Element;
    private nativeElement: HTMLElement;
    private questionParent: HTMLElement;

    constructor(element: ElementRef, @Inject(DOCUMENT) private document: any, private winRef: WindowRef) {
        this.nativeElement = element.nativeElement;
        this.questionParent = this.nativeElement.parentElement ?  this.nativeElement.parentElement : this.nativeElement;
    }

    @HostListener("keyup", ["$event"])
    onkeyup(event: MouseEvent) {
        if (!this.isDisabled && this.isGroupCompleted) {
            this.showOkBtnGroup();
        }
    }

    @HostListener("keydown", ["$event"])
    onkeydown(event: MouseEvent) {
        if (this.isDisabled) {
            return;
        }
        if (event.which === 9 && this.isGroupCompleted) {
            event.preventDefault();
        }
        if (this.isGroupCompleted) {
            if (event.shiftKey && event.which === 9) {
                this.changeFocus(false);
            } else if (event.which === 13 || event.which === 9) {
                this.changeFocus(true);
            }
        }
    }

    @HostListener("click", ["$event"])
    onclick(event: MouseEvent) {
        if (!this.isDisabled && this.nativeElement.tagName === this.btnTagName) {
            this.changeFocus(true);
        }
    }

    @HostListener("change", ["$event"])
    onchange(event: MouseEvent) {
        //Just do a timeout to trigger this after model changed
        setTimeout(() => this.onDropDownChange(), 0);
    }

    private onDropDownChange() {
        if (!this.isDisabled && this.nativeElement.tagName === this.dropdownTagName && this.isGroupCompleted) {
            this.changeFocus(true);
        }
    }

    @HostListener("focus", ["$event"])
    onFocus(event: MouseEvent) {
        if (this.isDisabled) {
            return;
        }
        if (this.nativeElement.tagName !== this.btnTagName && this.nativeElement.tagName !== this.dropdownTagName) {
            this.hideOkBtnGroups();
            if (this.isGroupCompleted) {
                this.showOkBtnGroup();
            }
        }
        this.handleScrolling();
    }

    private get isDisabled() {
        if (this.questionParent.nextElementSibling) {
            return this.questionParent.nextElementSibling.querySelectorAll(this.formInputFieldSelector).length > 0;
        }
        return false;
    }

    private getReleventOkBtn(): Element {
        const nextElement = this.questionParent.nextElementSibling;
        if (nextElement && nextElement.classList.contains(this.okBtnGroupSelector)) {
            const okBtnGroups = this.nativeElement.parentElement.parentElement
                .getElementsByClassName(this.okBtnGroupSelector);
            // Check whether this is the last element in the group
            if (okBtnGroups.length > 0) {
               return okBtnGroups[0];
            }
        }
        return null;
    }

    private showOkBtnGroup() {
        if (!this.okBtnGroup) {
            this.okBtnGroup = this.getReleventOkBtn();
        }
        // okBtnGroup still can be null
        if (this.okBtnGroup) {
            this.okBtnGroup.classList.remove(this.hideClass);
        }
    }

    private hideOkBtnGroups() {
        const okBtnGroups = this.document.getElementsByClassName(this.okBtnGroupSelector);
        for (let okBtnGroup of okBtnGroups) {
            okBtnGroup.classList.add(this.hideClass);
        }
    }

    private changeFocus(goDown: boolean) {
        // Can't use Lifescycle hooks as the form is dynamic. Assign the scrollToElement here instead
        let parentQuestionGroup = this.questionParent.classList.contains(this.questionGroupSelector)
            ? this.questionParent.parentElement
            : this.questionParent.parentElement.parentElement;
        let inputElement = null;
        while (inputElement == null) {
            parentQuestionGroup = (goDown
                ? parentQuestionGroup.nextElementSibling
                : parentQuestionGroup.previousElementSibling) as HTMLElement;
            inputElement = parentQuestionGroup.querySelector(this.formInputFieldSelector);
        }
        if (inputElement) {
            (inputElement as HTMLElement).focus();
        }
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
        const elm = this.nativeElement;
        let y = elm.offsetTop;
        let node = elm;
        while (node.offsetParent && node.offsetParent !== this.document.body) {
            node = (node.offsetParent as HTMLElement);
            y += node.offsetTop;
        }
        return y -300;
    }
}
