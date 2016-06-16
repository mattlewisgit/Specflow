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
        footerHeader: null,
        hiddenClass: "quote-footer--body__hidden",
        pageFooter: null,

        init: function () {
            module.footer = $(".quote-footer");

            // Ignore if no footer found.
            if (!module.footer.length) {
                return null;
            }

            module.footerBody = $(".quote-footer--body");
            module.footerHeader = module.footer.find("h6");
            module.pageFooter = $("footer:last-of-type");

            // If only a single button is present,
            // hide the tab and permanently show the button.
            if (module.footerBody.children().length < 2) {
                module.footerHeader.hide();
                return module.show();
            }

            // For multiple buttons, register events and adapt the footer.
            module.footerHeader.find("a").click(module.toggle);
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

        adaptPageFooter: function (height) {
            // Note: setTimeout cannot be moved to this function!
            module.pageFooter.css("padding-bottom", (height + 20) + "px");
        },

        hide: function() {
            module.footerBody.addClass(module.hiddenClass);

            setTimeout(function () {
                module.adaptPageFooter(module.footerHeader.outerHeight());
            }, 350);
        },

        show: function() {
            module.footerBody.removeClass(module.hiddenClass);

            setTimeout(function () {
                module.adaptPageFooter(module.footer.outerHeight());
            }, 350);
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
