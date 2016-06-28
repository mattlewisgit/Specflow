var AccordionModule = require("./accordionModule");
var AnimationDelayModule = require("./animationDelayModule");
var FilerModule = require("./filterModule");
var MatchHeightsModule = require("./matchHeightsModule");
var MatchWidthsModule = require("./matchWidthsModule");
var MenuModule = require("./menuModule");
var QuoteFooterModule = require("./quoteFooterModule");
var SearchModule = require("./searchModule");
var SocialShareModule = require("./socialShareModule");
var TabsModule = require("./tabsModule");

$(document).ready(function () {
    "use strict";
    //
    // Vendor libraries -
    //

    //Start fastclick -
    FastClick.attach(document.body);

    //JQ UI Date picker init  -
    //Where JS used, disable direct input to stop mobile keyboards -
    if ($(".js-datepicker").length) {
        $(".js-datepicker").datepicker().attr("readonly", "true");
    }

    //TableSaw responsive tables init -
    if (!$("html").hasClass("disable-tablesaw")) {
        $(document).trigger("enhance.tablesaw");
    }

    //init wow js  - only for larger screens -
    var wow;

    if (Modernizr.mq("(min-width : 770px)")) {
        /* global WOW */
        wow = new WOW({
            boxClass: "animate-on-scroll"
        });

        wow.init();
    } else {
        //Add a class showing that the animation library has not been initialised -
        $("html").addClass("no-js-animations");
    }

    //
    // Custom modules -
    //

    //Main & Mobile menu functionality -
    MenuModule.init();

    //Social Sharing pop ups -
    SocialShareModule.init();

    //Modules for accordions & tabs -
    AccordionModule.init();
    TabsModule.init();

    //Check for filterable content - pass a reference to the animation object -
    FilerModule.init(wow);

    // Match sizes.
    MatchHeightsModule.init();
    MatchWidthsModule.init();

    QuoteFooterModule.init();

    //Check for column animation delays -
    AnimationDelayModule.init();

    //Search functionality -
    SearchModule.init();
});
