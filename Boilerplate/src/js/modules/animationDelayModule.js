/*
 * Utility to set animaiton delays based on column position,
 * so elements animate in with the correct delay for variable column widths.
*/
var Breakpoints = require("./breakpointsModule");

var _settings = {
    animationDelayClass: ".column-animation-delay"
};

var BASE_ANIMATION_DELAY = 0.5;
var COLUMN_ANIMAITON_DELAY_STEP = 0.2;

var $animationElements;
var prevElTop =  0;
var count = 0;

var _animationDelayMod = {
    init: function () {
        "use strict";
        $animationElements = $(_settings.animationDelayClass);
        _animationDelayMod.setDelays();
        $(window).on("throttledresize", _animationDelayMod.setDelays);
    },

    setDelays: function () {
        "use strict";
        if (!Breakpoints.min.tablet.test()) {
            return;
        }

        $.each($animationElements, function (el) {
            var $el = $(el);
            var thisElTop = $el.position().top;

            if (prevElTop !== thisElTop) {
                // Set the variables for the new row.
                count = 0;
                prevElTop = thisElTop;
            } else {
                count++;
            }

            var animDelay = BASE_ANIMATION_DELAY + (COLUMN_ANIMAITON_DELAY_STEP * count);
            $el.attr("data-wow-delay", animDelay + "s");
        });
    }
};

module.exports = {
    init: _animationDelayMod.init
};
