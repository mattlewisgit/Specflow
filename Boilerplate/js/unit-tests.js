(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
module.exports=﻿{
    "mobile": "350px",
    "mobile-landscape": "540px",
    "tablet": "770px",
    "desktop": "1025px",
    "wide": "1200px",
    "max": "1440px"
}

},{}],2:[function(require,module,exports){
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

},{"../breakpoints.json":1}],3:[function(require,module,exports){
var Breakpoints = require("../../js/modules/breakpointsModule");

QUnit.module("Breakpoints module");

QUnit.test("Module exported", function (assert) {
    "use strict";
    assert.ok(Breakpoints, "Module exported");
});

QUnit.test("Max breakpoints created", function (assert) {
    "use strict";
    var maxBreakpoints = Breakpoints.max;
    var breakpointKeys = Object.keys(maxBreakpoints);
    assert.ok(breakpointKeys, "Breakpoints exist");
    assert.ok(breakpointKeys.length > 0, "Breakpoints available");

    var firstBreakpoint = maxBreakpoints[breakpointKeys[0]];
    assert.ok(typeof firstBreakpoint.test === "function", "Test function available");
    assert.ok(firstBreakpoint.value.indexOf("max-width") > -1, "Expected test value");
});

QUnit.test("Min breakpoints created", function (assert) {
    "use strict";
    var minBreakpoints = Breakpoints.min;
    var breakpointKeys = Object.keys(minBreakpoints);
    assert.ok(breakpointKeys, "Breakpoints exist");
    assert.ok(breakpointKeys.length > 0, "Breakpoints available");

    var firstBreakpoint = minBreakpoints[breakpointKeys[0]];
    assert.ok(typeof firstBreakpoint.test === "function", "Test function available");
    assert.ok(firstBreakpoint.value.indexOf("min-width") > -1, "Expected test value");
});

},{"../../js/modules/breakpointsModule":2}],4:[function(require,module,exports){
// Disable no globals, as third-party libraries will cause this to error.
QUnit.config.noglobals = false;
QUnit.config.notrycatch = false;

require("./modules/breakpointsModuleTest");

},{"./modules/breakpointsModuleTest":3}]},{},[4]);
