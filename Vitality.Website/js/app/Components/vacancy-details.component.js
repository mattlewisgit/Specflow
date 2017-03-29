"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var common_1 = require('@angular/common');
require('rxjs/add/operator/switchMap');
var vacancies_service_1 = require('../Services/vacancies.service');
var VacancyDetailsComponent = (function () {
    function VacancyDetailsComponent(vacanciesService, route, location) {
        this.vacanciesService = vacanciesService;
        this.route = route;
        this.location = location;
    }
    VacancyDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params
            .switchMap(function (params) { return _this.vacanciesService.getVacancy(+params['Advertid']); })
            .subscribe(function (v) { return _this.vacancy = v; });
    };
    VacancyDetailsComponent.prototype.goBack = function () {
        this.location.back();
    };
    VacancyDetailsComponent = __decorate([
        core_1.Component({
            selector: 'vacancy',
            templateUrl: './app/Components/vacancy-details.html'
        }), 
        __metadata('design:paramtypes', [vacancies_service_1.VacanciesService, router_1.ActivatedRoute, common_1.Location])
    ], VacancyDetailsComponent);
    return VacancyDetailsComponent;
}());
exports.VacancyDetailsComponent = VacancyDetailsComponent;
