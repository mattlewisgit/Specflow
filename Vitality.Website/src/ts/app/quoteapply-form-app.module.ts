import { NgModule }      from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule }   from "@angular/forms";
import { HttpModule }    from "@angular/http";

import { AutoScrollTo } from "./directives/auto-scroll-to.directive";
import { QuoteApplyFormComponent }  from "./components/quoteapply-form.component";
import { QuoteApplyService }  from "./services/quoteapply.service";
import { PostcodeService }  from "./services/postcode.service";
import { ValidationService }  from "./services/validation.service";
import { QuestionControlService }  from "./dynamic-form/question-control.service";
import { DynamicFormQuestionGroupComponent } from "./dynamic-form/dynamic-form-question-group.component";

import { WindowRef }  from "./components/windowref";

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpModule
    ],
    declarations: [QuoteApplyFormComponent, AutoScrollTo, DynamicFormQuestionGroupComponent],
    providers: [PostcodeService, QuoteApplyService, QuestionControlService, ValidationService, WindowRef],
    bootstrap: [QuoteApplyFormComponent]
})
export class QuoteApplyFormAppModule { }
