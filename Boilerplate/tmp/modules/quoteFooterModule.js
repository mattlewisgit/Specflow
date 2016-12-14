var Breakpoints = require("./breakpointsModule");

var settings = {
    breakpoint: Breakpoints.max.tablet,
    footer: null,
    footerBody: null,
    footerHeader: null,
    hiddenClass: "quote-footer--body__hidden",
    isCollapsed: false,
    isExpanded: false,
    pageFooter: null
};

/**
 * @description
 *   Adapts the quote footer based on a media query.
 *   For backwards-compatibility, the mql is optional,
 *   so this can be fired from window.matchMedia or window.resize.
 * @param {MediaQueryListEvent} [mql] From window.matchMedia.
 * @private
 */
function _adapt(mql) {
    "use strict";

    if (settings.isExpanded) {
        return;
    }

    if ((mql && mql.matches) || settings.breakpoint.test()) {
        if (!settings.isCollapsed) {
            // Cache the collapsed state and hide.
            settings.isCollapsed = true;
            _hide();
        }
    } else {
        settings.isCollapsed = false;
        _show();
    }
}

function _adaptPageFooter(height) {
    "use strict";
    // Note: setTimeout cannot be moved to this function!
    settings.pageFooter.css("padding-bottom", (height + 20) + "px");
}

function _hide() {
    "use strict";
    settings.footerBody.addClass(settings.hiddenClass);

    setTimeout(function () {
        _adaptPageFooter(settings.footerHeader.outerHeight());
    }, 350);
}

function _show() {
    "use strict";
    settings.footerBody.removeClass(settings.hiddenClass);

    setTimeout(function () {
        _adaptPageFooter(settings.footer.outerHeight());
    }, 350);
}

function _toggle() {
    "use strict";
    settings.isExpanded = !settings.isExpanded;
    return settings.isExpanded ? _show() : _hide();
}

module.exports = {
    init: function () {
        "use strict";
        settings.footer = $(".quote-footer");

        // Ignore if no footer found, or it is hidden in Experience Editor.
        if (!settings.footer.length || settings.footer.is(":hidden")) {
            return null;
        }

        settings.footerBody = $(".quote-footer--body");
        settings.footerHeader = settings.footer.find(".quote-footer--tab");
        settings.pageFooter = $("footer:last-of-type");

        // If only a single button is present,
        // hide the tab and permanently show the button.
        if (settings.footerBody.children().length < 2) {
            settings.footerHeader.hide();
            return _show();
        }

        // For multiple buttons, register events and adapt the footer.
        settings.footerHeader.find("a").click(_toggle);
        _adapt();

        // Attach the adapt event to the matchMedia listener
        // if possible, to prevent it from being called every
        // time the window resizes, which is the failover for old browsers.
        if (window.matchMedia) {
            return window
                .matchMedia(settings.breakpoint.value)
                .addListener(_adapt);
        }

        return $(window).resize(_adapt);
    }
};