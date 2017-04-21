import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { VacanciesComponent }  from './Components/vacancies.component';
import { VacanciesService }  from './Services/vacancies.service';

import { WindowRef }  from './Components/windowRef';

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
