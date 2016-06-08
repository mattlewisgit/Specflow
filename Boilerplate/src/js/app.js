requirejs.config({
    baseUrl: "/src/js/",
    paths: {
        "jquery": "libraries/jquery-1.11.3",
        "jq-date-picker": "libraries/jquery-ui",
        "domready": "vendor/domReady",
        "smart-resize": "libraries/jquery.smart-resize",
        "tablesaw": "libraries/tablesaw.stackonly",
        "match-height": "libraries/jquery.matchHeight"
    },

    "shim": {
        "smart-resize": ["jquery"],
        "tablesaw": ["jquery"]
    },

    preserveLicenseComments: true
});

require(["vendor/domready", "modules/main"], function(domReady, main) {
    "use strict";
    domReady( main.init);
});
