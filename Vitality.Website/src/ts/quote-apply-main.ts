import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";

import { QuoteApplyAppModule } from "./app/quote-apply-app.module";

import { enableProdMode } from "@angular/core";

// Enable production mode unless running locally
if (!/presales.vitality.co.uk/.test(document.location.host)) {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(QuoteApplyAppModule);
