var data = require("../breakpoints.json");

// Take raw breakpoint values from JSON and repackage them
// as reusable values and Modernizr media query tests!
var breakpoints = {
    max: {},
    min: {}
};

$.each(data, function (name, value) {
    "use strict";
    var max = "(max-width: " + value + ")";
    var min = "(min-width: " + value + ")";

    // Creates values and functions for each breakpoint,
    // as they need to be evaluated each time, not precalculated.
    // e.g. breakpoints.max.desktop.test()
    breakpoints.max[name] = {
        test: function () {
            return Modernizr.mq(max);
        },
        value: max
    };

    breakpoints.min[name] = {
        test: function () {
            return Modernizr.mq(min);
        },
        value: min
    };
});

module.exports = breakpoints;
