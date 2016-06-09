define([
    "jquery",
    "match-height",
    "smart-resize"
], function (
    $
) {
    "use strict";

    //vars -
    var _settings = {

        matchHeightClasses: [
            // Any element with the utility class of .match-height
            ".match-height",

            // The top-content wrapper for the spotlights - to ensure the CTA links line up
            ".spotlight-item__top-content",

            // The outisde container of the spotlight elements
            ".spotlight-item"
        ]
    };

    var $allMatchHeightElements;

    //funcitons -
    var _matchHeightMod = {
        init: function () {
            //Populate the elements -
            $allMatchHeightElements = [];

            //For each match height class in the settings, add it to the array of elements to be height matched -
            for (var i = 0; i < _settings.matchHeightClasses.length; i++) {
                $allMatchHeightElements.push($(_settings.matchHeightClasses[i]));
            }

            _matchHeightMod.matchHeights();
            $(window).smartresize(_matchHeightMod.matchHeights);

            $("body").on("TRIGGER_MATCH_HEIGHTS", _matchHeightMod.matchHeights);
        },

        matchHeights: function () {
            for (var i = 0; i < $allMatchHeightElements.length; i++) {
                $allMatchHeightElements[i].matchHeight();
            }
        }
    };

    /**
       *  initialiser
       */
    var init = function () {
        _matchHeightMod.init();
    };

    //Return our public methods -
    return {
        "init": init
    };
});
