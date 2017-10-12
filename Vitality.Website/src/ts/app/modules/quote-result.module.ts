import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from '@angular/forms';
import { HttpModule } from "@angular/http";
import { NgModule } from "@angular/core";
import { WindowRef }  from "../components/windowref";

import { ErrorService } from "../services/error.service";
import { QuoteService }  from "../services/quote.service";

import { QuoteResultComponent } from "../components/quoteapply/quote-result.component";
import { BenefitOptionComponent } from "../components/quoteapply/benefit-option.component";
import { PermutationButtonComponent } from "../components/quoteapply/permutation-button.component"
import { ClickOutside } from "../directives/click-outside"

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [
        ClickOutside,
        QuoteResultComponent,
        BenefitOptionComponent,
	PermutationButtonComponent
    ],
    providers: [
        ErrorService,
        QuoteService,
        WindowRef
    ],
    bootstrap: [QuoteResultComponent]
})
export class QuoteResultModule { }
