var AccordionModule = require("./accordionModule");
var AnimationDelayModule = require("./animationDelayModule");
var Breakpoints = require("./breakpointsModule");
var FilerModule = require("./filterModule");
var MatchHeightsModule = require("./matchHeightsModule");
var MatchWidthsModule = require("./matchWidthsModule");
var MenuModule = require("./menuModule");
var QuoteFooterModule = require("./quoteFooterModule");
var SearchModule = require("./searchModule");
var SocialShareModule = require("./socialShareModule");
var TabsModule = require("./tabsModule");

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
    TabsModule.init();

    // Check for filterable content with the animation instance.
    FilerModule.init(wow);

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
