var Accordion = require("./accordionModule");
var Breakpoints = require("./breakpointsModule");

var _settings = {
    selector: ".js-expander-is-switchable",
    menuClass: ".expander__menu",
    activeClass: "is-active"
};

var _globals = {
    isAvailable: true
};

var _tabModules = [];

var TabModule = function (tabModuleDomElement) {
    "use strict";
    var $thisTabModule = tabModuleDomElement;

    var _setDefaultContent = function () {
        // Set the default for links.
        if ($(".expander__link." + _settings.activeClass, $thisTabModule).length === 0) {
            $(".expander__link", $thisTabModule).first().addClass(_settings.activeClass);
        }

        // Set the default for content.
        if ($(".expander__content." + _settings.activeClass, $thisTabModule).length === 0) {
            $(".expander__content", $thisTabModule).first().addClass(_settings.activeClass);
        }
    };

    var _tabClick = function(e) {
        e.preventDefault();
        var link = $(e.target);

        // switch the current link
        link.addClass(_settings.activeClass);
        $(".expander__link", $thisTabModule).not(link).removeClass(_settings.activeClass);

        var content = link.attr("href");

        // hide other active content areas
        $(".expander__content", $thisTabModule).not(content).removeClass(_settings.activeClass);

        // set the active content area
        $(content).addClass(_settings.activeClass);

        return false;
    };

    var _createTabs = function () {
        // Create the menu to hold the tabs.
        var $menu = $("<ul />", {
            "class": _settings.menuClass.replace(".", "")
        });

        // Append all links to the menu inside a tab.
        $(".expander__link", $thisTabModule)
            .appendTo($menu)
            .wrap("<li class='expander__item'></li>");

        $thisTabModule.prepend($menu);

        // Set the default content to be open if required.
        _setDefaultContent();

        // Rebind the click event.
        $(".expander__link", $thisTabModule).unbind("click").click(_tabClick);

        $thisTabModule
            .removeClass("expander--collapsible  expander--init")
            .addClass("expander--tabs  expander--init");
    };

    var _createAccordion = function () {
        Accordion.createAccordion($thisTabModule);
        $thisTabModule.removeClass("expander--tabs");
    };

    var _switchToAccordion = function () {
        var $menu = $(_settings.menuClass, $thisTabModule);

        $(".expander__link", $menu).each(function () {
            // Move it to just before its content partner.
            var link = $(this);
            var content = $(link.attr("href"));
            link.insertBefore(content);
        });

        $menu.remove();
        _createAccordion();
    };

    var _isAccordionState = function () {
        // Based on existence of tab menu markup.
        return $thisTabModule.find(_settings.menuClass).length === 0;
    };

    this.switchToTabs = _createTabs;
    this.switchToAccordion = _switchToAccordion;
    this.createAccordion = _createAccordion;
    this.isAccordionState = _isAccordionState;
};

var _handleResize = function () {
    "use strict";
    // Check whether to do anything.
    if (!_globals.isAvailable) {
        return;
    }

    $.each(_tabModules, function (i, tab) {
        var isAccordion = tab.isAccordionState();

        if (Breakpoints.min.tablet.test() && isAccordion) {
            tab.switchToTabs();
        } else if (Breakpoints.max.tablet.test() && !isAccordion) {
            tab.switchToAccordion();
        }
    });
};

var init = function () {
    "use strict";
    // Ignore if no tabs are present.
    if ($(_settings.selector).length < 1) {
        return (_globals.isAvailable = false);
    }

    $(_settings.selector).each(function () {
        var tabModule = new TabModule($(this));
        _tabModules.push(tabModule);

        // Determine what we should do on startup.
        if (Breakpoints.min.tablet.test() && tabModule.isAccordionState()) {
            // Switch to tabs larger screen sizes currently in accordion state.
            tabModule.switchToTabs($(this));
        } else {
            // Otherwise create an accordion for smaller screens.
            tabModule.createAccordion($(this));
        }
    });

    // Attach the adapt event to the matchMedia listener
    // if possible, to prevent it from being called every
    // time the window resizes, which is the failover for old browsers.
    if (window.matchMedia) {
        return window
            .matchMedia(Breakpoints.min.tablet.value)
            .addListener(_handleResize);
    }

    return $(window).resize(_handleResize);
};

module.exports = {
    init: init
};
