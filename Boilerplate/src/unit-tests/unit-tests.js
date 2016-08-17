// Disable no globals, as third-party libraries will cause this to error.
QUnit.config.noglobals = false;
QUnit.config.notrycatch = false;

var Breakpoints = require("./modules/breakpointsModuleTest");
