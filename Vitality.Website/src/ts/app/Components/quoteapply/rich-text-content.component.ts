import { Component, Input} from "@angular/core";
import { WindowRef } from "./../windowref";

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
