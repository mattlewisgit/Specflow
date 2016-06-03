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
    "modules/animationDelayModule",
    "modules/searchModule"
], function(
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
    AnimationDelayModule,
    SearchModule
) {
  "use strict";
    var main = {

        init: function(){

            // Your code here
            console.log("Main JS init here!");

            //
        // Vendor libraries -
        //

            //Start fastclick -
            FastClick.attach(document.body);

            //JQ UI Date picker init  -
      //Where JS used, disable direct input to stop mobile keyboards -
        $(".js-datepicker").datepicker().attr("readonly", "true");

        //TableSaw responsive tables init -
        $( document ).trigger( "enhance.tablesaw" );

        //init wow js  - only for larger screens -
      var wow;
      if(Modernizr.mq("(min-width : 770px)")){
          wow = new WOW({
              boxClass: "animate-on-scroll"
          });
          wow.init();
      }
      else{
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

            //Check for height matching -
            MatchHeightsModule.init();

      //Check for column animation delays -
      AnimationDelayModule.init();

      //Search functionality -
      SearchModule.init();

        }
    };

    return main;
});
