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
