import { Directive, ElementRef, HostListener, Inject, Input, Optional} from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref";
import { NgControl } from "@angular/forms";

@Directive({
    selector: "[auto-scroll-to]"
})
export class AutoScrollTo {
    private formInputFieldSelector = "input,select";
    private hideClass = "hide";
    private okBtnGroupSelector = "ok-btn-group";
    private questionGroupSelector = "question";

    private nativeElement: HTMLElement;
    private scrollToElement: HTMLElement;
    private questionParent: HTMLElement;

    constructor(element: ElementRef, @Inject(DOCUMENT) private document: any, private winRef: WindowRef, @Optional() private control?: NgControl) {
        this.nativeElement = element.nativeElement;
        this.questionParent = this.nativeElement.parentElement;
    }

    @HostListener("keyup", ['$event'])
    onkeyup(event: MouseEvent) {
        event.preventDefault();
        if (this.control && this.control.valid) {
            const okBtn = this.getReleventOkBtn();
            this.showOkBtn(okBtn);
            if (event.shiftKey && event.which === 9) {
                this.handleScrolling(false);
                this.changeFocus(event, okBtn);
            } else if (event.which === 13 || event.which === 9) {
                this.handleScrolling(true);
                this.changeFocus(event, okBtn);
            }
        }
    }

    @HostListener("focus", ["$event"])
    onFocus(event: MouseEvent) {
        if (this.control && this.control.valid) {
            this.showOkBtn(this.getReleventOkBtn());
        }
    }

    @HostListener("focusout", ["$event"])
    onFocusOut(event: MouseEvent) {
        this.hideOkBtn(this.getReleventOkBtn());
    }

    @HostListener("click", ['$event'])
    onclick(event: MouseEvent) {
        //let parent = this.nativeElement.parentElement;
        //if (event.which === 13 || event.which === 9) {
        //    // Check whether this is the last element in the group
        //    if (!parent.nextElementSibling) {
        //    }
        //}
    }

    private getReleventOkBtn(): Element {
        const nextElement = this.questionParent.nextElementSibling;
        if (nextElement.classList.contains(this.okBtnGroupSelector)) {
            const okBtnGroups = this.nativeElement.parentElement.parentElement
                .getElementsByClassName(this.okBtnGroupSelector);
            // Check whether this is the last element in the group
            if (okBtnGroups.length > 0) {
               return okBtnGroups[0];
            }
        }
        return null;
    }

    private showOkBtn(btn: Element) {
       if (btn) {
           btn.classList.remove(this.hideClass);
       }
    }

    private hideOkBtn(btn: Element) {
        if (btn) {
            btn.classList.add(this.hideClass);
        }
    }

    private handleScrolling(goDown: boolean): void {
        // Can't use Lifescycle hooks as the form is dynamic. Assign the scrollToElement here instead
        const parentQuestionGroup = this.questionParent.classList.contains(this.questionGroupSelector)
            ? this.questionParent.parentElement
            : this.questionParent.parentElement.parentElement;
        this.scrollToElement = (goDown
            ? parentQuestionGroup.nextElementSibling
            : parentQuestionGroup.previousElementSibling) as HTMLElement;

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

    private changeFocus(event: MouseEvent, okBtn: Element) {
        if (!(event.shiftKey && event.which === 9)) {
            var inputElements = this.scrollToElement.querySelectorAll(this.formInputFieldSelector);
            if (inputElements.length > 0) {
                (inputElements[0] as HTMLElement).focus();
            }
            this.hideOkBtn(okBtn);
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
        if (document.documentElement && document.documentElement.scrollTop)
            return document.documentElement.scrollTop;
        // Internet Explorer 6, 7 and 8
        if (document.body.scrollTop) return document.body.scrollTop;
        return 0;
    }

    private elmYPosition() {
        const elm = this.scrollToElement;
        let y = elm.offsetTop;
        let node = elm;
        while (node.offsetParent && node.offsetParent !== document.body) {
            node = (node.offsetParent as HTMLElement);
            y += node.offsetTop;
        }
        return y -300;
    }
}
