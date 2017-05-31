import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { QuoteApplyFormAppModule } from './app/quoteapply-form-app.module';

import { enableProdMode } from '@angular/core';

// Enable production mode unless running locally
if (!/presales.vitality.co.uk/.test(document.location.host)) {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(QuoteApplyFormAppModule);

