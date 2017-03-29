import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { AppRoutingModule }  from './app-routing.module';

import { AppComponent }  from './Components/app.component';
import { VacanciesComponent }  from './Components/vacancies.component';
import { VacancyDetailsComponent }  from './Components/vacancy-details.component';
import { VacanciesService }  from './Services/vacancies.service';


@NgModule({
  imports:      [ 
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  declarations: [ AppComponent, VacanciesComponent, VacancyDetailsComponent ],
  providers: [ VacanciesService ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
