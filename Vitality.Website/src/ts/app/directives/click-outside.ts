import { Directive, ElementRef, Output, EventEmitter, HostListener } from "@angular/core";

@Directive({
    selector: "[click-outside]"
})
export class ClickOutside {

    constructor(private elementRef: ElementRef) {
    }

    @Output()
    clickOutside = new EventEmitter<MouseEvent>();

    @HostListener("document:click", ["$event", "$event.target"])
    @HostListener("document:touchstart", ["$event"])
    onClick(event: MouseEvent, targetElement: HTMLElement): void {
        if (!targetElement) {
            return;
        }

        const clickedInside = this.elementRef.nativeElement.contains(targetElement);
        if (!clickedInside) {
            this.clickOutside.emit(event);
        }
    }
}
