import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { FeedSettings } from '../models/feedsettings';
import { Vacancies } from '../models/vacancies';
import { Vacancy } from '../models/vacancy';

@Injectable()
export class VacanciesService {
    feedSettings: FeedSettings;
    vacancy: Vacancy;

  constructor(private http: Http) {}

  setFeedSettings(feedSettings: FeedSettings): void {
      this.feedSettings = feedSettings;
  }

  getVacancies(): Promise<Vacancies> {
     return this.http.post("/api/bsl/post?bslendpoint=" + encodeURIComponent(this.feedSettings.Endpoint),
          { FeedType: this.feedSettings.FeedType, MockDataFile: encodeURI(this.feedSettings.MockDataFile )})
               .toPromise()
               .then(response => response.json().BslResponse as Vacancies)
          .catch(this.handleError);
  }

  getVacancy(advertId: number): Promise<Vacancy> {
      return this.getVacancies().then(v => v.Vacancies.find(p => p.Advertid === advertId));
  }

  private handleError(error: any): void {
      throw error.message || error;
  }
}
