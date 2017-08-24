import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import { NgModule }      from "@angular/core";
import { WindowRef }  from "./components/windowref";

import { ErrorService } from "./services/error.service";
import { QuoteService }  from "./services/quote.service";

import { QuoteResultComponent } from "./components/quoteapply/quote-result.component";
import { BenefitOptionComponent } from "./components/quoteapply/benefit-option.component";

@NgModule({
    imports: [
        BrowserModule,
        HttpModule
    ],
    declarations: [
        QuoteResultComponent,
        BenefitOptionComponent
    ],
    providers: [
        ErrorService,
        QuoteService,
        WindowRef
    ],
    bootstrap: [QuoteResultComponent]
})
export class QuoteResultModule { }
