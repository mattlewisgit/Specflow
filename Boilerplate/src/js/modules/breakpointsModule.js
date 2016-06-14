define([
    "jquery",
    "json!breakpoints.json"
], function (
    $,
    data
) {
    "use strict";

    // Take raw breakpoint values from JSON and packages
    // them up as reusable Modernizr media query tests for easy reuse!
    var breakpoints = {
        max: {},
        min: {}
    };

    $.each(data, function (name, value) {
        // Creates functions for each breakpoint,
        // as they need to be evaluated each time, not precalculated.
        // e.g. breakpoints.max.small()
        breakpoints.max[name] = function () {
            return Modernizr.mq("(max-width: " + value + "px)");
        };

        breakpoints.min[name] = function () {
            return Modernizr.mq("(min-width: " + value + "px)");
        };
    });

    return breakpoints;
});
