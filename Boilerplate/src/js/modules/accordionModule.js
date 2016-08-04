var Collapsible = require("./collapsibleModule");

var _settings = {
    activeClass: "is-active",
    breakpoint: "medium",
    openFirstAccordionOption: false,
    selector: ".js-expander-is-accordion"
};

var _globals = {
    userInteracted: false
};

var _accordionModule = {
    _createAccordion: function (context) {
        "use strict";
        var contextSelector = context || _settings.selector;

        // Set the default content to be open if required.
        if (_settings.openFirstAccordionOption) {
            this._showActiveContent();
        }

        Collapsible.createCollapsible(contextSelector, function ($target) {
            // User has interacted.
            _globals.userInteracted = true;

            var content = $target.attr("href");

            // Generator other active content selector.
            var otherActiveContentSelector = ".expander__content." + _settings.activeClass;

            // Hide other active content areas.
            $(otherActiveContentSelector, contextSelector).not(content)
                .stop()
                .slideUp("fast", function () {
                    $(this).removeClass(_settings.activeClass).removeAttr("style");
                });
        });
    },

    _hideActiveContent: function () {
        "use strict";
        var compoundLinkSelector = ".expander__link" + "." + _settings.activeClass;
        var compoundContentSelector = ".expander__content" + "." + _settings.activeClass;

        // Remove defaults.
        $(compoundLinkSelector, _settings.selector).removeClass(_settings.activeClass);
        $(compoundContentSelector, _settings.selector).removeClass(_settings.activeClass);
    },

    _showActiveContent: function () {
        "use strict";
        // Set default for links.
        if ($(".expander__link." + _settings.activeClass, _settings.selector).length === 0) {
            $(".expander__link", _settings.selector).first().addClass(_settings.activeClass);
        }

        // Set default for content.
        if ($(".expander__content." + _settings.activeClass, _settings.selector).length === 0) {
            $(".expander__content", _settings.selector).first().addClass(_settings.activeClass);
        }
    }
};

module.exports = {
    createAccordion: _accordionModule._createAccordion,
    init: _accordionModule._createAccordion
};
