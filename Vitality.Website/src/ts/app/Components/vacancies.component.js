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
var VacanciesComponent = (function () {
    function VacanciesComponent(vacanciesService, document, winRef) {
        this.vacanciesService = vacanciesService;
        this.document = document;
        this.winRef = winRef;
    }
    VacanciesComponent.prototype.ngOnInit = function () {
        if (!this.document.location.pathname.endsWith("/")) {
            this.document.location.pathname = this.winRef.ensureTrailingSlash(this.document.location.pathname);
        }
        this.headline = this.winRef.nativeWindow.angularData.headline;
        this.locationsLabel = this.winRef.nativeWindow.angularData.locationsDropdownLabel;
        this.allLocations = this.winRef.nativeWindow.angularData.allLocationsText;
        this.departmentsLabel = this.winRef.nativeWindow.angularData.departmentsDropdownLabel;
        this.allDepartments = this.winRef.nativeWindow.angularData.allDepartmentsText;
        this.findoutMore = this.winRef.nativeWindow.angularData.findoutMoreText;
        this.noVacanciesFoundText = this.winRef.nativeWindow.angularData.noVacanciesFoundText;
        this.vacancyLocation = this.winRef.nativeWindow.angularData.locationText;
        this.vacancySalary = this.winRef.nativeWindow.angularData.salaryText;
        this.vacancyClosesOn = this.winRef.nativeWindow.angularData.closesOnText;
        this.feedId = this.winRef.nativeWindow.angularData.FeedSettings;
        this.vacanciesService.setFeedId(this.feedId);
        this.getVacancies();
        this.path = this.winRef.ensureTrailingSlash(this.document.location.pathname);
    };
    VacanciesComponent.prototype.getVacancies = function () {
        var _this = this;
        this.vacanciesService.getVacancies().then(function (v) { return _this.initialisePage(v); });
    };
    VacanciesComponent.prototype.initialisePage = function (vac) {
        this.vacancies = vac.Vacancies;
        this.getLocations();
        this.location = this.allLocations;
        this.getDepartments();
        this.department = this.allDepartments;
        this.filtersChanged(this.allLocations, this.allDepartments);
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
    // used if we want to display job details on same page
    VacanciesComponent.prototype.onSelect = function (vacancy) {
        this.vacancy = vacancy;
    };
    // populates departments array
    VacanciesComponent.prototype.getDepartments = function () {
        var _this = this;
        var depts = new Array();
        // add default department
        depts.push(this.allDepartments);
        // add departments from feed
        this.vacancies.forEach(function (s) { return _this.addDepartment(s, depts); });
        this.departments = depts;
    };
    // add department to array
    VacanciesComponent.prototype.addDepartment = function (vacancy, depts) {
        // check department not already added
        if (depts.indexOf(vacancy.Jobdepartment) < 1) {
            depts.push(vacancy.Jobdepartment);
        }
    };
    /// filters vacancy list based on selected department
    VacanciesComponent.prototype.filtersChanged = function (loc, dept) {
        // reset filter
        this.filteredVacancies = this.vacancies;
        if (loc != this.allLocations) {
            this.filteredVacancies = this.filteredVacancies.filter(function (p) { return p.Joblocation === loc; });
        }
        if (dept != this.allDepartments) {
            this.filteredVacancies = this.filteredVacancies.filter(function (p) { return p.Jobdepartment === dept; });
        }
    };
    VacanciesComponent = __decorate([
        core_1.Component({
            selector: 'vacancy-list',
            templateUrl: './js/app/Components/vacancyListTemplate.html'
        }),
        __param(1, core_1.Inject(platform_browser_1.DOCUMENT))
    ], VacanciesComponent);
    return VacanciesComponent;
}());
exports.VacanciesComponent = VacanciesComponent;
