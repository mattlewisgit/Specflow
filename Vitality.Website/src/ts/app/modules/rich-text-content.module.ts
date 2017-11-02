import { BrowserModule } from "@angular/platform-browser";
import { NgModule }      from "@angular/core";
import { WindowRef } from "../components/windowref";
import { SafeHtmlPipe } from "../pipes/safe-html.pipe";

import { RichTextContentComponent} from "../components/quoteapply/rich-text-content.component";

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        RichTextContentComponent,
        SafeHtmlPipe
    ],
    providers: [
        WindowRef
    ],
    bootstrap: [RichTextContentComponent]
})
export class RichTextContentModule { }
