import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { VacanciesComponent }  from './components/vacancies.component';
import { VacanciesService }  from './services/vacancies.service';

import { WindowRef }  from './components/windowref';

@NgModule({
  imports:      [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  declarations: [VacanciesComponent ],
  providers: [ VacanciesService, WindowRef ],
  bootstrap: [VacanciesComponent]
})
export class VacancyListAppModule { }
