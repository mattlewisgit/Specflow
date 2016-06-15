define([
    "jquery",
    "modules/breakpointsModule"
], function (
    $,
    breakpoints
) {
    "use strict";

    var module = {
        breakpoint: breakpoints.max.small,
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

            // Attach the adapt event to the matchMedia listener
            // if possible, to prevent it from being called every
            // time the window resizes, which is the failover for old browsers.
            if (window.matchMedia) {                
                return window
                    .matchMedia(module.breakpoint.value)
                    .addListener(module.adapt);
            }
            
            return $(window).resize(module.adapt);
        },

        /**
         * Adapts the quote footer based on a media query.
         * For backwards-compatibility, the mql is optional,
         * so this can be fired from window.matchMedia or window.resize.
         * @param {MediaQueryListEvent} [mql] From window.matchMedia.
         */
        adapt: function (mql) {
            if (module.isExpanded) {
                return;
            }

            if ((mql && mql.matches) || module.breakpoint.test()) {
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
                bottom: "-" + module.footerBody.outerHeight() + "px"
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
