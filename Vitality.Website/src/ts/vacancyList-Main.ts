import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { VacancyListAppModule } from './app/vacancylist-app.module';

import { enableProdMode } from '@angular/core';

platformBrowserDynamic().bootstrapModule(VacancyListAppModule);

// Enable production mode unless running locally
if (!/presales.vitality.co.uk/.test(document.location.host)) {
    enableProdMode();
}
