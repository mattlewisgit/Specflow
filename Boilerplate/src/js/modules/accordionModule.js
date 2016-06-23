var Collapsible = require("./collapsibleModule");

//vars -
var _settings = {
    selector: ".js-expander-is-accordion",
    activeClass: "is-active",
    breakpoint: "medium",
    openFirstAccordionOption: false
};

var _globals = {
    userInteracted: false
};

//functions -
var _accordionModule = {
    _showActiveContent: function () {
        "use strict";
        // set default for links
        if ($(".expander__link." + _settings.activeClass, _settings.selector).length === 0){
            $(".expander__link", _settings.selector).first().addClass(_settings.activeClass);
        }

        // set default for content
        if ($(".expander__content." + _settings.activeClass, _settings.selector).length === 0){
            $(".expander__content", _settings.selector).first().addClass(_settings.activeClass);
        }
    },

    _hideActiveContent: function () {
        "use strict";
        var compoundLinkSelector = ".expander__link" + "." + _settings.activeClass;
        var compoundContentSelector = ".expander__content" + "." + _settings.activeClass;

        // remove defaults
        $(compoundLinkSelector, _settings.selector).removeClass(_settings.activeClass);
        $(compoundContentSelector, _settings.selector).removeClass(_settings.activeClass);
    },

    _createAccordion: function (context) {
        "use strict";
        var contextSelector = context || _settings.selector;

        // set the default content to be open if required
        if (_settings.openFirstAccordionOption) {
            this._showActiveContent();
        }

        Collapsible.createCollapsible(contextSelector, function ($target) {
            // user has interacted
            _globals.userInteracted = true;

            var content = $target.attr("href");

            // generator other active content selector
            var otherActiveContentSelector = ".expander__content." + _settings.activeClass;

            // hide other active content areas
            $(otherActiveContentSelector, contextSelector).not(content)
                .stop()
                .slideUp("fast", function () {
                    $(this).removeClass(_settings.activeClass).removeAttr("style");
                });
        });
    }
};

module.exports = {
    init: _accordionModule._createAccordion,
    createAccordion: _accordionModule._createAccordion
};
