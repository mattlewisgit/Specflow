define(["jquery"], function ($) {
    "use strict";

    var module = {
        enablerClass: ".match-width",

        init: function () {
            // Only use this as a failover for a lack of flexbox.
            if (Modernizr && Modernizr.flexbox) {
                return;
            }

            // Resize the children of each parent element with the enabler.
            $(module.enablerClass).each(module.matchWidths);
        },

        matchWidths: function (i, element) {
            var maxWidth = 0;

            $(element)
                .children()
                .each(function (j, child) {
                    var width = $(child).width();

                    if (width > maxWidth) {
                        maxWidth = width;
                    }
                })
                .width(maxWidth);
        }
    };

    return {
        "init": module.init
    };
});
