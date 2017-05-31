import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { QuoteApplyFormComponent }  from './components/quoteapply-form.component';
import { QuoteApplyService }  from './services/quoteapply.service';

import { WindowRef }  from './components/windowref';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [QuoteApplyFormComponent],
    providers: [QuoteApplyService, WindowRef],
    bootstrap: [QuoteApplyFormComponent]
})
export class QuoteApplyFormAppModule { }
