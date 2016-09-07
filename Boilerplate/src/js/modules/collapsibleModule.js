var Breakpoints = require("./breakpointsModule");

var _settings = {
    activeClass: "is-active",
    breakpoint: Breakpoints.min["mobile-landscape"],
    selector: ".js-expander-is-collapsible"
};

var _collapsibleModule = {
    _createAllCollapsibles: function () {
        "use strict";
        $(_settings.selector).each(function () {
            _collapsibleModule._createCollapsible($(this));
        });
    },

    _createCollapsible: function (context, onBeforeSlideDown) {
        "use strict";
        var $context = context ? $(context) : $(_settings.selector);

        // Bomb out if it is already set up.
        if ($context.hasClass("expander--collapsible")) {
            return;
        }

        // Bomb out if we should not be creating it.
        if ($context.hasClass("expander--mobile") && _settings.breakpoint.test()) {
            return;
        }

        $(".expander__link", $context).unbind("click").on("click", function (e) {
            e.preventDefault();
            var $link = $(e.target);
            var content = $link.attr("href");

            if ($link.hasClass(_settings.activeClass)) {
                // Set the active content area.
                $(content).stop().slideUp("fast", function () {
                    $(this).removeClass(_settings.activeClass).removeAttr("style");
                    $link.removeClass(_settings.activeClass);
                });

                return false;
            }

            // Switch the current link.
            $link.addClass(_settings.activeClass);
            $(".expander__link", $context).not($link).removeClass(_settings.activeClass);

            // Run the callback if it exists.
            if (typeof onBeforeSlideDown === "function") {
                onBeforeSlideDown($link);
            }

            // Set the active content area.
            $(content).stop().slideDown("fast", function () {
                $(this).addClass(_settings.activeClass).removeAttr("style");
            });
        });

        $context.addClass("expander--collapsible  expander--init");
    },

    _destroyCollapsible: function (context) {
        "use strict";
        var contextSelector = context || _settings.selector;
        $(".expander__link", contextSelector).unbind("click");
        $(contextSelector).removeClass("expander--collapsible  expander--init");
    }
};

function handleResize() {
    "use strict";
    var method = _settings.breakpoint.test() ? "_destroyCollapsible" : "_createCollapsible";
    _collapsibleModule[method](_settings.selector + ".expander--mobile");
}

function init() {
    "use strict";
    _collapsibleModule._createAllCollapsibles();

    // Attach the adapt event to the matchMedia listener
    // if possible, to prevent it from being called every
    // time the window resizes, which is the failover for old browsers.
    if (window.matchMedia) {
        return window
            .matchMedia(_settings.breakpoint.value)
            .addListener(handleResize);
    }

    return $(window).resize(handleResize);
}

module.exports = {
    createCollapsible: _collapsibleModule._createCollapsible,
    init: init
};
