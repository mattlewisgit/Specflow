define([
    "jquery",
    "modules/breakpointsModule"
], function (
    $,
    breakpoints
) {
    "use strict";

    var module = {
        isCollapsed: false,
        isExpanded: false,
        footer: null,
        footerBody: null,

        init: function () {
            module.footer = $(".quote-footer");

            // Ignore if no footer found.
            if (!module.footer.length) {
                return null;
            }

            module.footerBody = $(".quote-footer--body");

            // If only a single button is present,
            // hide the tab and permanently show the button.
            if (module.footerBody.children().length < 2) {
                module.footer.find("h6").hide();
                return module.show();
            }

            // For multiple buttons, register events and adapt the footer.
            module.footer.find("h6 a").click(module.toggle);
            module.adapt();
            return $(window).resize(module.adapt);
        },

        adapt: function () {
            if (module.isExpanded) {
                return;
            }

            if (breakpoints.max.small()) {
                if (!module.isCollapsed) {
                    // Cache the collapsed state and hide.
                    module.isCollapsed = true;
                    module.hide();
                }
            } else {
                module.isCollapsed = false;
                module.show();
            }
        },

        hide: function() {
            module.footer.css({
                bottom: "-" + module.footerBody.height() + "px"
            });
        },

        show: function() {
            module.footer.css({
                bottom: "0"
            });
        },

        toggle: function() {
            module.isExpanded = !module.isExpanded;
            return module.isExpanded ? module.show() : module.hide();
        }
    };

    return {
        init: module.init
    };
});
