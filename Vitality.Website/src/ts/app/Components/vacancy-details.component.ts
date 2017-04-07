import { Component, Inject, OnInit }      from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import 'rxjs/add/operator/switchMap';

import { Vacancy } from '../Models/vacancy';
import { Vacancies } from '../Models/vacancies';
import { VacanciesService } from '../Services/vacancies.service';
import { WindowRef } from './windowRef';

@Component({
  selector: 'vacancy-details',
  templateUrl: './js/app/Components/vacancy-detailsTemplate.html'
})
export class VacancyDetailsComponent implements OnInit  {
    vacancy: Vacancy;
    advertId: number;
    applyForVacancy: string;
    shareVacancy: string;
    backToListing: string;
    backToListingUrl: string;
    backToVacanciesListingText: string;
    vacancyLocation: string;
    vacancySalary: string;
    vacancyClosesOn: string;
    feedId: string;

  constructor(
      private vacanciesService: VacanciesService,
      @Inject(DOCUMENT) private document: any,
      private winRef: WindowRef
  ) {}

  ngOnInit(): void {
      this.advertId = this.document.location.href.split(/[/ ]+/).pop();
      this.applyForVacancy = this.winRef.nativeWindow.angularData.applyForVacancyText;
      this.shareVacancy = this.winRef.nativeWindow.angularData.shareVacancyText;
      this.vacancyLocation = this.winRef.nativeWindow.angularData.locationText;
      this.vacancySalary = this.winRef.nativeWindow.angularData.salaryText;
      this.vacancyClosesOn = this.winRef.nativeWindow.angularData.closesOnText;
      this.backToVacanciesListingText = this.winRef.nativeWindow.angularData.backToVacanciesListingText;
      this.backToListingUrl = this.document.location.pathname.split("/").slice(0, -1).join("/") + "/";
      this.feedId = this.winRef.nativeWindow.angularData.FeedSettings;
      this.vacanciesService.setFeedId(this.feedId);

      this.vacanciesService.getVacancy(+this.advertId).then(v => this.vacancy = v);
      
  }
}
