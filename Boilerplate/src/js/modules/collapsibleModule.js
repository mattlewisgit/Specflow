var _settings = {
    selector: ".js-expander-is-collapsible",
    activeClass: "is-active",
    breakpoint: "500px"
};

var  _collapsibleModule = {
    _destroyCollapsible: function (context) {
        "use strict";
        var contextSelector = context || _settings.selector;

        $(".expander__link", contextSelector).unbind("click");

        $(contextSelector).removeClass("expander--collapsible  expander--init");

    },

    _createCollapsible: function (context, onBeforeSlideDown) {
        "use strict";
        var $context = context ? $(context) : $(_settings.selector);

        // if it"s already set up, return
        if ($context.hasClass("expander--collapsible")){
            return;
        }

        // if we shouldn"t be creating it, return
        //if ($context.hasClass("expander--mobile") && _screensize.greaterThan(_settings.breakpoint))
        if ($context.hasClass("expander--mobile") && Modernizr.mq("(min-width : "+_settings.breakpoint+")")){
            return;
        }

        $(".expander__link", $context).unbind("click").on("click", function (e) {
            e.preventDefault();

            var $link = $(this);

            var content = $link.attr("href");

            if ($link.hasClass(_settings.activeClass)) {
                // set the active content area
                $(content).stop().slideUp("fast", function () {
                    $(this).removeClass(_settings.activeClass).removeAttr("style");
                    $link.removeClass(_settings.activeClass);
                });
            } else {
                // switch the current link
                $link.addClass(_settings.activeClass);
                $(".expander__link", $context).not($link).removeClass(_settings.activeClass);

                // run callback if it"s there
                if (typeof onBeforeSlideDown === "function") {
                    onBeforeSlideDown($link);
                }

                // set the active content area
                $(content).stop().slideDown("fast", function () {
                    $(this).addClass(_settings.activeClass).removeAttr("style");
                });
            }

            return false;
        });

        $context.addClass("expander--collapsible  expander--init");
    },

    _createAllCollapsibles: function () {
        "use strict";
        $(_settings.selector).each(function () {
            _collapsibleModule._createCollapsible($(this));
        });
    }
};

var handleResize = function () {
    "use strict";
    if (Modernizr.mq("(min-width : "+_settings.breakpoint+")")) {
        // destroy mobile-only
        _collapsibleModule._destroyCollapsible(_settings.selector + ".expander--mobile");
    } else {
        // create mobile only
        _collapsibleModule._createCollapsible(_settings.selector + ".expander--mobile");
    }
};

var init = function () {
    "use strict";
    _collapsibleModule._createAllCollapsibles();
    $(window).on("throttledresize", handleResize);
};

module.exports = {
    init: init,
    createCollapsible: _collapsibleModule._createCollapsible
};
