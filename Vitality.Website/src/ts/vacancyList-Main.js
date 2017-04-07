"use strict";
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var vacancyList_app_module_1 = require('./app/vacancyList-app.module');
var core_1 = require('@angular/core');
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(vacancyList_app_module_1.VacancyListAppModule);
// Enable production mode unless running locally
if (!/presales.vitality.co.uk/.test(document.location.host)) {
    core_1.enableProdMode();
}
