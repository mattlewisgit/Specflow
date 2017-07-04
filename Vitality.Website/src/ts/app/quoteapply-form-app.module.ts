import { NgModule }      from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule }   from "@angular/forms";
import { HttpModule }    from "@angular/http";

import { AutoScrollTo } from "./directives/auto-scroll-to.directive";
import { QuoteApplyFormComponent }  from "./components/quoteapply/quoteapply-form.component";
import { QuoteApplyService }  from "./services/quoteapply.service";
import { ProgressBarService }  from "./services/progress-bar.service";
import { PostcodeService }  from "./services/postcode.service";
import { ErrorService }  from "./services/error.service";
import { ValidationService }  from "./services/validation.service";
import { DobControlService }  from "./services/dob-control.service";
import { QuestionControlService }  from "./services/question-control.service";
import { QuestionGroupsComponent } from "./components/quoteapply/question-groups.component";

import { WindowRef }  from "./components/windowref";

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpModule
    ],
    declarations: [QuoteApplyFormComponent, AutoScrollTo, QuestionGroupsComponent],
    providers: [DobControlService, ErrorService, PostcodeService, ProgressBarService, QuoteApplyService, QuestionControlService, ValidationService, WindowRef],
    bootstrap: [QuoteApplyFormComponent]
})
export class QuoteApplyFormAppModule { }
