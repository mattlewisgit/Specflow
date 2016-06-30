var init = function () {
    "use strict";

    // --------------------------------------------------------------------Block Heights

    // Usage $(".block").equalizeHeights();
    $.fn.equalizeHeights = function () {
        return this.height(Math.max.apply(this, $(this)
            .map(function (i, e) {
                return $(e)
                    .height();
            })
            .get()));
    };
    // --------------------------------------------------------------------Form clear

    // Usage $("input[type="text"]").clrInput();

    $.fn.clrInput = function () {
        return this.focus(function () {
            if (this.value === this.defaultValue) {
                this.value = "";
            }
        }).blur(function () {
            if (!this.value.length) {
                this.value = this.defaultValue;
            }
        });
    };

    // --------------------------------------------------------------------IE 11 Check

    if (navigator.userAgent.match(/Trident.*rv:11\./)) {
        $("body").addClass("ie11");
    }
};

// --------------------------------------------------------------------Scroll To Element
var scrollToElement = function (el, off, dur) {
    "use strict";
    dur = typeof dur !== "undefined" ? dur : 500;
    off = typeof off !== "undefined" ? off : 0;

    $("body").scrollTo(el, dur, {
        offset: -off,
        queue: false
    });
};

// --------------------------------------------------------------------Get viewport sizes
var getViewport = function () {
    "use strict";
    var viewPortWidth;
    var viewPortHeight;

    // the more standards compliant browsers (mozilla/netscape/opera/IE7) use window.innerWidth and window.innerHeight
    if (typeof window.innerWidth !== "undefined") {
        viewPortWidth = window.innerWidth;
        viewPortHeight = window.innerHeight;

        // IE6 in standards compliant mode (i.e. with a valid doctype as the first line in the document)
    } else if (typeof document.documentElement !== "undefined" && typeof document.documentElement.clientWidth !== "undefined" && document.documentElement.clientWidth !== 0) {
        viewPortWidth = document.documentElement.clientWidth;
        viewPortHeight = document.documentElement.clientHeight;

        // older versions of IE
    } else {
        viewPortWidth = document.getElementsByTagName("body")[0].clientWidth;
        viewPortHeight = document.getElementsByTagName("body")[0].clientHeight;
    }

    return [viewPortWidth, viewPortHeight];
};

module.exports = {
    init: init,
    scrollToElement: scrollToElement,
    getViewport: getViewport
};
