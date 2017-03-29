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
var vacancies_service_1 = require('../Services/vacancies.service');
var VacanciesComponent = (function () {
    function VacanciesComponent(router, vacanciesService) {
        this.router = router;
        this.vacanciesService = vacanciesService;
        this.title = 'Latest Vacancies';
        this.allLocations = "All locations"; // all job locations dropdown value
    }
    VacanciesComponent.prototype.ngOnInit = function () {
        this.getVacancies();
    };
    VacanciesComponent.prototype.getVacancies = function () {
        var _this = this;
        this.vacanciesService.getVacancies().then(function (v) { return _this.initialisePage(v); });
    };
    VacanciesComponent.prototype.initialisePage = function (vac) {
        this.vacancies = vac.Vacancies;
        this.getLocations();
        this.locationChanged(this.allLocations);
        this.location = this.allLocations;
    };
    // populates locations array
    VacanciesComponent.prototype.getLocations = function () {
        var _this = this;
        var locs = new Array();
        // add default location
        locs.push(this.allLocations);
        // add locations from feed
        this.vacancies.forEach(function (s) { return _this.addLocation(s, locs); });
        this.locations = locs;
    };
    // add location to array
    VacanciesComponent.prototype.addLocation = function (vacancy, locs) {
        // check location not already added
        if (locs.indexOf(vacancy.Joblocation) < 1) {
            locs.push(vacancy.Joblocation);
        }
    };
    /// filters vacancy list based on selected location
    VacanciesComponent.prototype.locationChanged = function (loc) {
        this.filteredVacancies = loc === this.allLocations ? this.vacancies : this.vacancies.filter(function (e) { return e.Joblocation == loc; });
    };
    // used if we want to display job details on same page
    VacanciesComponent.prototype.onSelect = function (vacancy) {
        this.vacancy = vacancy;
    };
    // used if we want to display job details on same page
    VacanciesComponent.prototype.gotoDetail = function () {
        this.router.navigate(['/vacancies', this.vacancy.Advertid]);
    };
    VacanciesComponent = __decorate([
        core_1.Component({
            selector: 'vacancies',
            templateUrl: './app/Components/vacancyList.html'
        }), 
        __metadata('design:paramtypes', [router_1.Router, vacancies_service_1.VacanciesService])
    ], VacanciesComponent);
    return VacanciesComponent;
}());
exports.VacanciesComponent = VacanciesComponent;
