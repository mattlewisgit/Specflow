import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { VacancyDetailsComponent }  from '../components/vacancy-details.component';
import { VacanciesService }  from '../services/vacancies.service';

import { WindowRef }  from '../components/windowref';

@NgModule({
  imports:      [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  declarations: [VacancyDetailsComponent ],
  providers: [ VacanciesService, WindowRef ],
  bootstrap: [VacancyDetailsComponent]
})
export class VacancyDetailsAppModule { }
