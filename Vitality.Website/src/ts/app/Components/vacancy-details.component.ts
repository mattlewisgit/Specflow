import { Component, Inject, OnInit }      from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import 'rxjs/add/operator/switchMap';

import { FeedSettings } from '../models/feedsettings';
import { Vacancy } from '../models/vacancy';
import { Vacancies } from '../models/vacancies';
import { VacanciesService } from '../services/vacancies.service';
import { WindowRef } from './windowref';

@Component({
  selector: 'vacancy-details',
  templateUrl: './js/app/components/vacancy-detailstemplate.html'
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
    feedSettings: FeedSettings;

  constructor(
      private vacanciesService: VacanciesService,
      @Inject(DOCUMENT) private document: any,
      private winRef: WindowRef
  ) {}

  ngOnInit(): void {
      if (!this.document.location.pathname.endsWith("/"))
      {
        this.document.location.pathname = this.winRef.ensureTrailingSlash(this.document.location.pathname);
      }

      this.advertId = this.document.location.href.slice(0, -1).split(/[/ ]+/).pop();

      var data = this.winRef.nativeWindow.angularData;
      this.applyForVacancy = data.applyForVacancyText;
      this.shareVacancy = data.shareVacancyText;
      this.vacancyLocation = data.locationText;
      this.vacancySalary = data.salaryText;
      this.vacancyClosesOn = data.closesOnText;
      this.backToVacanciesListingText = data.backToVacanciesListingText;
      this.backToListingUrl = this.winRef.ensureTrailingSlash(this.document.location.pathname.replace(this.advertId + "/", ""));
      this.feedSettings = data.feedSettings;
      this.vacanciesService.setFeedSettings(this.feedSettings);

      this.vacanciesService.getVacancy(+this.advertId).then(v => this.setVacancy(v));
  }

  setVacancy(vac:Vacancy) : void {
      if (vac != null)
      {
          this.vacancy = vac;
      }
      else
      {
          this.winRef.nativeWindow.location = "/notfound";
      }
  }
}
