import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Vacancies } from '../Models/vacancies';
import { Vacancy } from '../Models/vacancy';

@Injectable()
export class VacanciesService {
    private vacancyFeedUrl = '/api/vacancy/list?settingsId={3180CA2D-2EE1-4AD7-B8A0-E507DDC1093C}';  // URL to web api
    vacancy:Vacancy;

  constructor(private http: Http) { }

  getVacancies(): Promise<Vacancies> {
    return this.http.get(this.vacancyFeedUrl)
               .toPromise()
               .then(response => response.json() as Vacancies)
               .catch(this.handleError);
  }

  getVacancy(advertId: number): Promise<Vacancy> {      
      return this.getVacancies().then(v => v.Vacancies.find(p => p.Advertid === advertId));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
