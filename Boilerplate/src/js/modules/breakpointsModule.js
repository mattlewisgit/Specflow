define([
    "jquery",
    "json!breakpoints.json"
], function (
    $,
    data
) {
    "use strict";

    // Take raw breakpoint values from JSON and repackage them
    // as reusable values and Modernizr media query tests!
    var breakpoints = {
        max: {},
        min: {}
    };

    $.each(data, function (name, value) {
        var max = "(max-width: " + value + "px)";
        var min = "(min-width: " + value + "px)";

        // Creates values and functions for each breakpoint,
        // as they need to be evaluated each time, not precalculated.
        // e.g. breakpoints.max.small.test()
        breakpoints.max[name] = {
            test: function() {
                return Modernizr.mq(max);
            },
            value: max
        };

        breakpoints.min.name = {
            test: function() {
                return Modernizr.mq(min);
            },
            value: min
        };
    });

    return breakpoints;
});
