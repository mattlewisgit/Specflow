"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
require('rxjs/add/operator/switchMap');
var VacancyDetailsComponent = (function () {
    function VacancyDetailsComponent(vacanciesService, document, winRef) {
        this.vacanciesService = vacanciesService;
        this.document = document;
        this.winRef = winRef;
    }
    VacancyDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (!this.document.location.pathname.endsWith("/")) {
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
        this.feedId = data.FeedSettings;
        this.vacanciesService.setFeedId(this.feedId);
        this.vacanciesService.getVacancy(+this.advertId).then(function (v) { return _this.setVacancy(v); });
    };
    VacancyDetailsComponent.prototype.setVacancy = function (vac) {
        if (vac != null) {
            this.vacancy = vac;
        }
        else {
            this.winRef.nativeWindow.location = "/notfound";
        }
    };
    VacancyDetailsComponent = __decorate([
        core_1.Component({
            selector: 'vacancy-details',
            templateUrl: './js/app/Components/vacancy-detailsTemplate.html'
        }),
        __param(1, core_1.Inject(platform_browser_1.DOCUMENT))
    ], VacancyDetailsComponent);
    return VacancyDetailsComponent;
}());
exports.VacancyDetailsComponent = VacancyDetailsComponent;
