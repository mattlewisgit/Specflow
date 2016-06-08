/*
 * Utility to set animaiton delays based on column position,
 * so elements animate in with the correct delay for variable column widths.
*/
define([
    "jquery",
    "smart-resize"
], function (
    $
) {
    "use strict";

    //vars -
    var _settings = {
        animationDelayClass: ".column-animation-delay"
    };

    var BASE_ANIMATION_DELAY = 0.5;
    var COLUMN_ANIMAITON_DELAY_STEP = 0.2;

    var $animationElements;
    var prevElTop =  0;
    var count = 0;

    //funcitons -
    var _animationDelayMod = {
        init: function () {
            //Populate the elements -
            $animationElements = $(_settings.animationDelayClass);

            //Call the delay set methos -
            _animationDelayMod.setDelays();

            //Add a resize listener to reset them -
            $(window).smartresize(_animationDelayMod.setDelays);
        },

        setDelays: function () {
            if (Modernizr.mq("(min-width : 770px)")) {
                $.each($animationElements, function () {
                    //Work out its column position
                    var $el = $(this);

                    //And set the animation delay based on that -
                    var thisElTop = $el.position().top;

                    if (prevElTop !== thisElTop) {
                        // we just came to a new row.
                        count = 0;

                        // set the variables for the new row
                        prevElTop = thisElTop;
                    } else {
                        count++;
                    }

                    var animDelay = BASE_ANIMATION_DELAY + (COLUMN_ANIMAITON_DELAY_STEP * count);

                    //Set the delay -
                    $(this).attr("data-wow-delay", animDelay + "s");
                });
            }
        }
    };

    /**
     *  initialiser
     */
    var init = function () {
        _animationDelayMod.init();
    };

    //Return our public methods -
    return {
        "init": init
    };
});
