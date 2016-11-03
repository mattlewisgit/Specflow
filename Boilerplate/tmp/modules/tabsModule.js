var Accordion = require("./accordionModule");
var Breakpoints = require("./breakpointsModule");

var _settings = {
    activeClass: "is-active",
    menuClass: ".expander__menu",
    selector: ".js-expander-is-switchable"
};

var _globals = {
    isAvailable: true
};

var _tabModules = [];

function TabModule(tabModuleDomElement) {
    "use strict";
    var $thisTabModule = tabModuleDomElement;

    function _setDefaultContent() {
        // Set the default for links.
        if ($(".expander__link." + _settings.activeClass, $thisTabModule).length === 0) {
            $(".expander__link", $thisTabModule).first().addClass(_settings.activeClass);
        }

        // Set the default for content.
        if ($(".expander__content." + _settings.activeClass, $thisTabModule).length === 0) {
            $(".expander__content", $thisTabModule).first().addClass(_settings.activeClass);
        }
    }

    function _tabClick(e) {
        e.preventDefault();
        var link = $(e.target);

        // Switch the current link.
        link.addClass(_settings.activeClass);

        $(".expander__link", $thisTabModule)
            .not(link)
            .removeClass(_settings.activeClass);

        var content = link.attr("href");

        // Hide other active content areas.
        $(".expander__content", $thisTabModule)
            .not(content)
            .removeClass(_settings.activeClass);

        // Set the active content area.
        $(content).addClass(_settings.activeClass);

        return false;
    }

    function _createTabs() {
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
    }

    function _createAccordion() {
        Accordion.createAccordion($thisTabModule);
        $thisTabModule.removeClass("expander--tabs");
    }

    function _switchToAccordion() {
        var $menu = $(_settings.menuClass, $thisTabModule);

        $(".expander__link", $menu).each(function () {
            // Move it to just before its content partner.
            var link = $(this);
            var content = $(link.attr("href"));
            link.insertBefore(content);
        });

        $menu.remove();
        _createAccordion();
    }

    function _isAccordionState() {
        // Based on existence of tab menu markup.
        return $thisTabModule.find(_settings.menuClass).length === 0;
    }

    this.switchToTabs = _createTabs;
    this.switchToAccordion = _switchToAccordion;
    this.createAccordion = _createAccordion;
    this.isAccordionState = _isAccordionState;
}

function _handleResize() {
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
}

function init() {
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
}

module.exports = {
    init: init
};
