import { Directive, ElementRef, HostListener, Inject, Input} from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref";
import { NgControl } from "@angular/forms";

@Directive({
    selector: "[auto-scroll-to]"
})
export class AutoScrollTo {
    @Input("auto-scroll-to") scrollToId: string;

    private nativeElement: HTMLElement;
    private scrollToElement: HTMLElement;

    constructor(element: ElementRef, private control: NgControl,@Inject(DOCUMENT) private document: any, private winRef: WindowRef) {
        this.nativeElement = element.nativeElement;
    }

    @HostListener("keydown",['$event'])
    public onkeydown(event: MouseEvent) {
        if(this.scrollToId && (event.which === 13 || event.which ===9))
        {
            // Can't use Lifescycle hooks as the form is dynamic. Assign the scrollToElement here instead
            if (!this.scrollToElement) {
                this.scrollToElement = this.document.getElementById(this.scrollToId);
                console.log(this.scrollToElement);
            }

            event.preventDefault();
            if( this.control.valid )
            {
                const startY = this.currentYPosition();
                const stopY = this.elmYPosition();
                const distance = stopY > startY ? stopY - startY : startY - stopY;

                if (distance < 100) {
                    this.winRef.nativeWindow.scrollTo(0, stopY); return;
                }
                let speed = Math.round(distance / 100);
                if (speed >= 20) speed = 20;
                const step = Math.round(distance / 100);
                let leapY = stopY > startY ? startY + step : startY - step;
                let timer = 0;
                if (stopY > startY) {
                    for (var i = startY; i < stopY; i += step) {
                        this.scrollTo(leapY, timer * speed);
                        leapY += step; if (leapY > stopY) leapY = stopY; timer++;
                    } return;
                }
                for (var i = startY; i > stopY; i -= step) {
                    this.scrollTo(leapY, timer * speed);
                    leapY -= step; if (leapY < stopY) leapY = stopY; timer++;
                }

                this.scrollToElement.focus();
            }
         }
    }

	scrollTo(yPoint: number, duration: number) {
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
        return y;
    }
}
