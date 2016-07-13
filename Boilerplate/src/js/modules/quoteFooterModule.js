var Breakpoints = require("./breakpointsModule");

var settings = {
    breakpoint: Breakpoints.max["mobile-landscape"],
    isCollapsed: false,
    isExpanded: false,
    footer: null,
    footerBody: null,
    footerHeader: null,
    hiddenClass: "quote-footer--body__hidden",
    pageFooter: null,

    init: function () {
        "use strict";
        settings.footer = $(".quote-footer");

        // Ignore if no footer found, or it is hidden in Experience Editor.
        if (!settings.footer.length || settings.footer.is(":hidden")) {
            return null;
        }

        settings.footerBody = $(".quote-footer--body");
        settings.footerHeader = settings.footer.find("h6");
        settings.pageFooter = $("footer:last-of-type");

        // If only a single button is present,
        // hide the tab and permanently show the button.
        if (settings.footerBody.children().length < 2) {
            settings.footerHeader.hide();
            return settings.show();
        }

        // For multiple buttons, register events and adapt the footer.
        settings.footerHeader.find("a").click(settings.toggle);
        settings.adapt();

        // Attach the adapt event to the matchMedia listener
        // if possible, to prevent it from being called every
        // time the window resizes, which is the failover for old browsers.
        if (window.matchMedia) {
            return window
                .matchMedia(settings.breakpoint.value)
                .addListener(settings.adapt);
        }

        return $(window).resize(settings.adapt);
    },

    /**
     * Adapts the quote footer based on a media query.
     * For backwards-compatibility, the mql is optional,
     * so this can be fired from window.matchMedia or window.resize.
     * @param {MediaQueryListEvent} [mql] From window.matchMedia.
     */
    adapt: function (mql) {
        "use strict";
        if (settings.isExpanded) {
            return;
        }

        if ((mql && mql.matches) || settings.breakpoint.test()) {
            if (!settings.isCollapsed) {
                // Cache the collapsed state and hide.
                settings.isCollapsed = true;
                settings.hide();
            }
        } else {
            settings.isCollapsed = false;
            settings.show();
        }
    },

    adaptPageFooter: function (height) {
        "use strict";
        // Note: setTimeout cannot be moved to this function!
        settings.pageFooter.css("padding-bottom", (height + 20) + "px");
    },

    hide: function () {
        "use strict";
        settings.footerBody.addClass(settings.hiddenClass);

        setTimeout(function () {
            settings.adaptPageFooter(settings.footerHeader.outerHeight());
        }, 350);
    },

    show: function () {
        "use strict";
        settings.footerBody.removeClass(settings.hiddenClass);

        setTimeout(function () {
            settings.adaptPageFooter(settings.footer.outerHeight());
        }, 350);
    },

    toggle: function () {
        "use strict";
        settings.isExpanded = !settings.isExpanded;
        return settings.isExpanded ? settings.show() : settings.hide();
    }
};

module.exports = {
    init: settings.init
};
