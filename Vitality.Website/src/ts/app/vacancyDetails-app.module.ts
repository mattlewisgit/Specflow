import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { VacancyDetailsComponent }  from './Components/vacancy-details.component';
import { VacanciesService }  from './Services/vacancies.service';

import { WindowRef }  from './Components/windowRef';

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
