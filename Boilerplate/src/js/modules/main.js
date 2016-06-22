/*jshint maxparams: 20*/
define([
    "jquery",
    "libraries/fastclick",
    "jq-date-picker",
    "tablesaw",
    "libraries/wow",

    "modules/helpers",
    "modules/menuModule",
    "modules/socialShareModule",
    "modules/accordionModule",
    "modules/tabsModule",
    "modules/filterModule",
    "modules/matchHeightsModule",
    "modules/matchWidthsModule",
    "modules/quoteFooterModule",
    "modules/animationDelayModule",
    "modules/searchModule"
], function (
    $,
    FastClick,
    DatePicker,
    TableSaw,
    Wow,

    Helpers,
    MenuModule,
    SocialShareModule,
    AccordionModule,
    TabsModule,
    FilerModule,
    MatchHeightsModule,
    MatchWidthsModule,
    QuoteFooterModule,
    AnimationDelayModule,
    SearchModule
) {
    "use strict";
    var main = {
        init: function () {
            //
            // Vendor libraries -
            //

            //Start fastclick -
            FastClick.attach(document.body);

            //JQ UI Date picker init  -
            //Where JS used, disable direct input to stop mobile keyboards -
            $(".js-datepicker").datepicker().attr("readonly", "true");

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

            //Demo of how to use helpers -
            //Helpers.init();
            //console.log(Helpers.getViewport());

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
        }
    };

    return main;
});
