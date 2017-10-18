import { BrowserModule } from "@angular/platform-browser";
import { HttpModule }    from "@angular/http";
import { NgModule }      from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { MaskModule } from "soft-angular-mask";

import { CallbackService }  from "../services/callback.service";
import { DobControlService }  from "../services/dob-control.service";
import { ErrorService }  from "../services/error.service";
import { FooterBarService }  from "../services/footer-bar.service";
import { footerBarServiceFactory }  from "../factories/footer-bar-service.factory";
import { PostcodeService }  from "../services/postcode.service";
import { QuestionControlService }  from "../services/question-control.service";
import { TellFormService }  from "../services/tell-form.service";
import { ValidationService } from "../services/validation.service";

import { Common } from "../modules/common.module";

import { AutoScrollTo } from "../directives/auto-scroll-to.directive";
import { LimitMultiSelect } from "../directives/limit-multi-select.directive";
import { QuestionGroupComponent } from "../components/tellform/question-group.component";
import { QuoteApplyFooterComponent }  from "../components/quoteapply/quote-apply-footer.component";
import { TellFormComponent }  from "../components/tellform/tell-form.component";
import { WindowRef } from "../components/windowref";

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpModule,
        MaskModule
    ],
    declarations: [
        AutoScrollTo,
        LimitMultiSelect,
        TellFormComponent,
        QuestionGroupComponent],
    providers: [
        CallbackService,
        Common,
        DobControlService,
        ErrorService,
        PostcodeService,
        { provide: FooterBarService, useValue: footerBarServiceFactory() },
        QuestionControlService,
        TellFormService,
        ValidationService,
        WindowRef],
    bootstrap: [TellFormComponent]
})
export class TellFormModule { }
