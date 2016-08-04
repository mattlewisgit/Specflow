function init() {
    "use strict";
    // Block heights.
    // Usage: $(".block").equalizeHeights();.
    $.fn.equalizeHeights = function () {
        return this.height(Math.max.apply(this, $(this)
            .map(function (i, e) {
                return $(e)
                    .height();
            })
            .get()));
    };

    // Form clear.
    // Usage: $("input[type="text"]").clrInput();.
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

    // IE 11 Check.
    if (navigator.userAgent.match(/Trident.*rv:11\./)) {
        $("body").addClass("ie11");
    }
}

function scrollToElement(el, off, dur) {
    "use strict";
    dur = typeof dur !== "undefined" ? dur : 500;
    off = typeof off !== "undefined" ? off : 0;

    $("body").scrollTo(el, dur, {
        offset: -off,
        queue: false
    });
}

function getViewport() {
    "use strict";
    var viewPortWidth;
    var viewPortHeight;

    if (typeof window.innerWidth !== "undefined") {
        // The more standards-compliant browsers, mozilla/netscape/opera/IE7,
        // use window.innerWidth and window.innerHeight.
        viewPortWidth = window.innerWidth;
        viewPortHeight = window.innerHeight;
    } else if (typeof document.documentElement !== "undefined" &&
        typeof document.documentElement.clientWidth !== "undefined" &&
        document.documentElement.clientWidth !== 0) {
        // IE6 in standards compliant mode,
        // i.e. with a valid doctype as the first line in the document.
        viewPortWidth = document.documentElement.clientWidth;
        viewPortHeight = document.documentElement.clientHeight;
    } else {
        // Older versions of IE.
        viewPortWidth = document.getElementsByTagName("body")[0].clientWidth;
        viewPortHeight = document.getElementsByTagName("body")[0].clientHeight;
    }

    return [viewPortWidth, viewPortHeight];
}

module.exports = {
    getViewport: getViewport,
    init: init,
    scrollToElement: scrollToElement
};
