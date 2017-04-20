import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Vacancies } from '../Models/vacancies';
import { Vacancy } from '../Models/vacancy';

@Injectable()
export class VacanciesService {
    settingsId: string;
    vacancy: Vacancy;

  constructor(private http: Http) {}

  setFeedId(feedId: string): void {
      this.settingsId = feedId;
  }

  getVacancies(): Promise<Vacancies> {
      return this.http.get('/api/vacancy/list?settingsId=' + this.settingsId)
               .toPromise()
               .then(response => response.json() as Vacancies)
          .catch(this.handleError);      
  }

  getVacancy(advertId: number): Promise<Vacancy> {      
      return this.getVacancies().then(v => v.Vacancies.find(p => p.Advertid === advertId));
  }

  private handleError(error: any): void {
      throw error.message || error;    
  }
}
