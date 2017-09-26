import { Component, Input, Pipe, PipeTransform } from "@angular/core";
import { WindowRef } from "./../windowref";

import { DomSanitizer } from '@angular/platform-browser'

@Pipe({ name: 'safeHtml'})
export class SafeHtmlPipe implements PipeTransform  {
    constructor(private sanitized: DomSanitizer) {}
    transform(html: string) {
        return this.sanitized.bypassSecurityTrustHtml(html);
    }
}

@Component({
    selector: "rich-text-content",
    templateUrl: "./js/app/components/quoteapply/rich-text-content.component.html",
})
export class RichTextContentComponent {
    richTextContent: string;

    constructor(private winRef: WindowRef) {
        this.richTextContent = this.winRef.nativeWindow.angularData.richTextContent;
    }
}
