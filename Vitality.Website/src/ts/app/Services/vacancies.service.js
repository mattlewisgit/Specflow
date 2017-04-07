"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('@angular/core');
require('rxjs/add/operator/toPromise');
var VacanciesService = (function () {
    function VacanciesService(http) {
        this.http = http;
        this.vacancyFeedUrl = '/api/vacancy/list?settingsId={3180CA2D-2EE1-4AD7-B8A0-E507DDC1093C}'; // URL to web api
    }
    VacanciesService.prototype.getVacancies = function () {
        return this.http.get(this.vacancyFeedUrl)
            .toPromise()
            .then(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    VacanciesService.prototype.getVacancy = function (advertId) {
        return this.getVacancies().then(function (v) { return v.Vacancies.find(function (p) { return p.Advertid === advertId; }); });
    };
    VacanciesService.prototype.handleError = function (error) {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    };
    VacanciesService = __decorate([
        core_1.Injectable()
    ], VacanciesService);
    return VacanciesService;
}());
exports.VacanciesService = VacanciesService;
