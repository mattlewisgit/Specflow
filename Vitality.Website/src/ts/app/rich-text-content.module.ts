import { BrowserModule } from "@angular/platform-browser";
import { NgModule }      from "@angular/core";
import { WindowRef }  from "./components/windowref";

import { RichTextContentComponent, SafeHtmlPipe} from "./components/quoteapply/rich-text-content.component";

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
