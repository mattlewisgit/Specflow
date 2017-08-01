import { BrowserModule } from "@angular/platform-browser";
import { NgModule }      from "@angular/core";
import { WindowRef }  from "./components/windowref";

import { CallbackService }  from "./services/callback.service";
import { FooterBarService }  from "./services/footer-bar.service";
import { footerBarServiceFactory }  from "./factories/footer-bar-service.factory";
import { TellFormService }  from "./services/tell-form.service";

import { QuoteApplyFooterComponent }  from "./components/quoteapply/quote-apply-footer.component";

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        QuoteApplyFooterComponent
    ],
    providers: [
        CallbackService,
        TellFormService,
        { provide: FooterBarService, useValue: footerBarServiceFactory() },
        WindowRef
    ],
    bootstrap: [QuoteApplyFooterComponent]
})
export class QuoteApplyFooterModule { }
