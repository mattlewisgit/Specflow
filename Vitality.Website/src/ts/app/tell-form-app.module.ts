import { NgModule }      from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule }   from "@angular/forms";
import { HttpModule }    from "@angular/http";

import { AutoScrollTo } from "./directives/auto-scroll-to.directive";
import { TellFormComponent }  from "./components/tellform/tell-form.component";
import { QuoteApplyService }  from "./services/quoteapply.service";
import { PostcodeService }  from "./services/postcode.service";
import { ErrorService }  from "./services/error.service";
import { ValidationService }  from "./services/validation.service";
import { DobControlService }  from "./services/dob-control.service";
import { QuestionControlService }  from "./services/question-control.service";
import { QuestionGroupComponent } from "./components/tellform/question-group.component";

import { WindowRef }  from "./components/windowref";

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpModule
    ],
    declarations: [TellFormComponent, AutoScrollTo, QuestionGroupComponent],
    providers: [DobControlService, ErrorService, PostcodeService, QuoteApplyService, QuestionControlService, ValidationService, WindowRef],
    bootstrap: [TellFormComponent]
})
export class TellFormAppModule { }
