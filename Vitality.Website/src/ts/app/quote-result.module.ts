import { BrowserModule } from "@angular/platform-browser";
import { NgModule }      from "@angular/core";
import { WindowRef }  from "./components/windowref";

import { QuoteService }  from "./services/quote.service";

import { QuoteResultComponent } from "./components/quoteapply/quote-result.component";
import { BenefitOptionComponent } from "./components/quoteapply/benefit-option.component";

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        QuoteResultComponent,
        BenefitOptionComponent
    ],
    providers: [
        QuoteService,
        WindowRef
    ],
    bootstrap: [QuoteResultComponent]
})
export class QuoteResultModule { }
