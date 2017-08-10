import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Vacancies } from '../models/vacancies';
import { Vacancy } from '../models/vacancy';

@Injectable()
export class VacanciesService {
    endpoint: string;
    feedType: string;
    mockDataFile: string;
    vacancy: Vacancy;

  constructor(private http: Http) {}

  setFeedSettings(endpoint: string, feedType: string, mockDataFile: string): void {
      this.endpoint = endpoint;
      this.feedType = feedType;
      this.mockDataFile = mockDataFile;
  }

  getVacancies(): Promise<Vacancies> {
     return this.http.post("/api/bsl/post?bslendpoint=" + encodeURIComponent(this.endpoint),
          { FeedType: this.feedType, MockDataFile: encodeURI(this.mockDataFile )})
               .toPromise()
               .then(response => {
                   var vacancies = response.json().BslResponse as Vacancies;
                   return vacancies;
         })
          .catch(this.handleError);
  }

  getVacancy(advertId: number): Promise<Vacancy> {
      return this.getVacancies().then(v => {
          var vacancies = v.Vacancies.find(p => p.Advertid === advertId);
          return vacancies;
      });
  }

  private handleError(error: any): void {
      throw error.message || error;
  }
}
