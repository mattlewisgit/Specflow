import { BrowserModule } from "@angular/platform-browser";
import { HttpModule }    from "@angular/http";
import { NgModule }      from "@angular/core";
import { ReactiveFormsModule }   from "@angular/forms";

import { CallbackService }  from "./services/callback.service";
import { DobControlService }  from "./services/dob-control.service";
import { ErrorService }  from "./services/error.service";
import { PostcodeService }  from "./services/postcode.service";
import { ProgressBarService }  from "./services/progress-bar.service";
import { QuestionControlService }  from "./services/question-control.service";
import { TellFormService }  from "./services/tell-form.service";
import { ValidationService }  from "./services/validation.service";

import { AutoScrollTo } from "./directives/auto-scroll-to.directive";
import { QuestionGroupComponent } from "./components/tellform/question-group.component";
import { QuoteApplyFooterComponent }  from "./components/quoteapply/quote-apply-footer.component";
import { TellFormComponent }  from "./components/tellform/tell-form.component";

import { WindowRef }  from "./components/windowref";

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpModule
    ],
    declarations: [AutoScrollTo, TellFormComponent, QuestionGroupComponent, QuoteApplyFooterComponent],
    providers: [CallbackService, DobControlService, ErrorService, PostcodeService, ProgressBarService, QuestionControlService, TellFormService, ValidationService, WindowRef],
    bootstrap: [TellFormComponent, QuoteApplyFooterComponent]
})
export class QuoteApplyAppModule { }
