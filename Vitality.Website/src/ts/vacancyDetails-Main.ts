import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { VacancyDetailsAppModule } from './app/vacancyDetails-app.module';

import { enableProdMode } from '@angular/core';

platformBrowserDynamic().bootstrapModule(VacancyDetailsAppModule);

// Enable production mode unless running locally
if (!/presales.vitality.co.uk/.test(document.location.host)) {
    enableProdMode();
}
