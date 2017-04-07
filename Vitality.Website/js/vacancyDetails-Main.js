"use strict";
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var vacancyDetails_app_module_1 = require('./app/vacancyDetails-app.module');
var core_1 = require('@angular/core');
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(vacancyDetails_app_module_1.VacancyDetailsAppModule);
// Enable production mode unless running locally
if (!/presales.vitality.co.uk/.test(document.location.host)) {
    core_1.enableProdMode();
}
