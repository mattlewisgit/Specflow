var enablerClass = ".match-width";

function init() {
    "use strict";
    // Only use this as a failover for a lack of flexbox.
    if (Modernizr && Modernizr.flexbox) {
        return;
    }

    // Resize the children of each parent element with the enabler.
    $(enablerClass).each(matchWidths);
}

function matchWidths(i, element) {
    "use strict";
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

module.exports = {
    init: init
};
