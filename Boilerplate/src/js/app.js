// Place third party dependencies in the vendor folder
// Configure loading modules from the vendor directory,
// except "app" ones,
requirejs.config({
    baseUrl: "/src/js/",
    paths: {
        "jquery": "libraries/jquery-1.11.3",
        "jq-date-picker": "libraries/jquery-ui",
        "domready": "vendor/domReady",
        "smart-resize": "libraries/jquery.smart-resize",
        "tablesaw": "libraries/tablesaw.stackonly",
        "match-height": "libraries/jquery.matchHeight",
    },

    "shim": {
        "smart-resize": ["jquery"],
        "jq-date-picker": ["jquery"],
        "tablesaw": ["jquery"],
        "match-height": ["jquery"]
    },

    // Changing this to false strips out our comment too (set in "wrap" in Gruntfile.js)
    preserveLicenseComments: true
});

// Load the main app module to start the app
require(["vendor/domready", "modules/main"], function(domReady, main) {
    "use strict";

    domReady(function() {
        main.init();
    });
});
