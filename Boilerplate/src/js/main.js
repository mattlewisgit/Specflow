var AccordionModule = require("./modules/accordionModule");
var AnimationDelayModule = require("./modules/animationDelayModule");
var Breakpoints = require("./modules/breakpointsModule");
var CookieMessageModule = require("./modules/cookieMessageModule");
var FilterModule = require("./modules/filterModule");
var HomeHeroModule = require("./modules/homeHeroModule");
var MatchHeightsModule = require("./modules/matchHeightsModule");
var MatchWidthsModule = require("./modules/matchWidthsModule");
var MenuModule = require("./modules/menuModule");
var QuoteFooterModule = require("./modules/quoteFooterModule");
var SearchModule = require("./modules/searchModule");
var SocialShareModule = require("./modules/socialShareModule");
var TabsModule = require("./modules/tabsModule");

function _initVendor() {
    "use strict";
    FastClick.attach(document.body);

    // TableSaw responsive tables.
    if (!$("html").hasClass("disable-tablesaw")) {
        $(document).trigger("enhance.tablesaw");
    }

    // Add WOW for larger screens.
    var wow;

    if (Breakpoints.min.tablet.test()) {
        wow = new WOW({
            boxClass: "animate-on-scroll"
        });

        wow.init();
    } else {
        // Add a class showing that the animation library has not been initialised.
        $("html").addClass("no-js-animations");
    }

    return wow;
}

function _initCustom(wow) {
    "use strict";
    MenuModule.init();

    SocialShareModule.init();

    AccordionModule.init();
    CookieMessageModule.init();
    HomeHeroModule.init();
    TabsModule.init();

    // Check for filterable content with the animation instance.
    FilterModule.init(wow);

    // Match sizes.
    MatchHeightsModule.init();
    MatchWidthsModule.init();

    QuoteFooterModule.init();
    AnimationDelayModule.init();
    SearchModule.init();
}

$(document).ready(function () {
    "use strict";
    _initCustom(_initVendor());
});

require("./angular/healthAdvisersLiteratureApp");