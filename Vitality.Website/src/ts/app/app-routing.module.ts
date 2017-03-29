import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VacanciesComponent }  from './Components/vacancies.component';
import { VacancyDetailsComponent }  from './Components/vacancy-details.component';

const routes: Routes = [
  { path: '', redirectTo: '/vacancies', pathMatch: 'full' },
  { path: 'vacancies',     component: VacanciesComponent },
  { path: 'vacancies/:Advertid', component: VacancyDetailsComponent }
];
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}