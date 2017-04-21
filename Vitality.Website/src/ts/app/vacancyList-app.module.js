"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
var forms_1 = require('@angular/forms');
var http_1 = require('@angular/http');
var vacancies_component_1 = require('./Components/vacancies.component');
var vacancies_service_1 = require('./Services/vacancies.service');
var windowRef_1 = require('./Components/windowRef');
var VacancyListAppModule = (function () {
    function VacancyListAppModule() {
    }
    VacancyListAppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpModule
            ],
            declarations: [vacancies_component_1.VacanciesComponent],
            providers: [vacancies_service_1.VacanciesService, windowRef_1.WindowRef],
            bootstrap: [vacancies_component_1.VacanciesComponent]
        })
    ], VacancyListAppModule);
    return VacancyListAppModule;
}());
exports.VacancyListAppModule = VacancyListAppModule;