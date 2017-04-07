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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
require('rxjs/add/operator/switchMap');
var vacancies_service_1 = require('../Services/vacancies.service');
var windowRef_1 = require('./windowRef');
var VacancyDetailsComponent = (function () {
    function VacancyDetailsComponent(vacanciesService, document, winRef) {
        this.vacanciesService = vacanciesService;
        this.document = document;
        this.winRef = winRef;
    }
    VacancyDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
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
        this.vacanciesService.getVacancy(+this.advertId).then(function (v) { return _this.vacancy = v; });
    };
    VacancyDetailsComponent = __decorate([
        core_1.Component({
            selector: 'vacancy-details',
            templateUrl: './js/app/Components/vacancy-detailsTemplate.html'
        }),
        __param(1, core_1.Inject(platform_browser_1.DOCUMENT)), 
        __metadata('design:paramtypes', [vacancies_service_1.VacanciesService, Object, windowRef_1.WindowRef])
    ], VacancyDetailsComponent);
    return VacancyDetailsComponent;
}());
exports.VacancyDetailsComponent = VacancyDetailsComponent;
