import { AfterViewInit, Directive, ElementRef, HostListener, Inject, Input, Optional } from "@angular/core";
import { DOCUMENT } from "@angular/platform-browser";
import { WindowRef } from "../components/windowref"
declare var $: any;

@Directive({
    selector: "[qtip]"
})
export class Qtip implements AfterViewInit {
    @Input("tooltipContent")
    tooltipContent: string;
    @Input("advancedMode")
    advancedMode: boolean;
    @Input("isTooltipLeft")
    isTooltipLeft: boolean;
    @Input("adjustX")
    adjustX = 40;
    @Input("selectedOption")
    selectedOption: string;

    private currentElement: HTMLElement;

    constructor(element: ElementRef, @Inject(DOCUMENT) private document: any) {
        this.currentElement = element.nativeElement;
    }

    ngAfterViewInit() {
        let content: string;
        if (this.advancedMode) {
            const elemToShow = document.getElementById(this.tooltipContent)[0];
            content = elemToShow;
            elemToShow.remove();
        } else {
            content = this.tooltipContent;
        }
        $(this.currentElement)
            .qtip({
                content: {
                    text: content
                },
                hide: {
                    event: "unfocus"
                },
                position: {
                    adjust: {
                        x: this.isTooltipLeft ? -this.adjustX : this.adjustX
                    },
                    at: (this.isTooltipLeft ? "left" : "right") + " center",
                    my: (this.isTooltipLeft ? "right" : "left") + " center"
                },
                show: {
                    event: "click"
                },
                style: {
                    tip: {
                        corner: (this.isTooltipLeft ? "right" : "left") + " center",
                        mimic: "center",
                        width: 8
                    }
                },
                suppress: true,
                events: {
                    render: this.renderEvent.bind(this)
                }
            });
    }

    renderEvent(event: any, api: any): void {
        $("select", api.elements.content)
            .change(this.changeValue.bind(this));
    }

    changeValue(e: any):void {
        this.selectedOption = e.target.value;
    }
}
