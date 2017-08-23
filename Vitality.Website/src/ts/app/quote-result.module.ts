import { BrowserModule } from "@angular/platform-browser";
import { NgModule }      from "@angular/core";
import { WindowRef }  from "./components/windowref";

import { QuoteService }  from "./services/quote.service";

import { QuoteResultComponent }  from "./components/quoteapply/quote-result.component";

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        QuoteResultComponent
    ],
    providers: [
        QuoteService,
        WindowRef
    ],
    bootstrap: [QuoteResultComponent]
})
export class QuoteResultModule { }
