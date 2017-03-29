import { Component, OnInit }      from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';
import 'rxjs/add/operator/switchMap';

import { Vacancy } from '../Models/vacancy';
import { Vacancies } from '../Models/vacancies';
import { VacanciesService } from '../Services/vacancies.service';

@Component({
  selector: 'vacancy',
  templateUrl: './app/Components/vacancy-details.html'
})
export class VacancyDetailsComponent implements OnInit  {
  vacancy: Vacancy;

  constructor(
    private vacanciesService: VacanciesService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.route.params
      .switchMap((params: Params) => this.vacanciesService.getVacancy(+params['Advertid']))
      .subscribe(v => this.vacancy = v);
  }

  goBack(): void {
    this.location.back();
  }
}