var Accordion = require("./accordionModule");

//vars -
var _settings = {
    selector: ".js-expander-is-switchable",
    menuClass: ".expander__menu",
    activeClass: "is-active",
    breakpoint: "769px"
};

var _globals = {
    isAvailable: true
};

var _tabModules = [];

// Tab Modules wrapped in function to keep each one"s scope to itself.
// Replaced generalised $(_settings.selector) dom selection.
var TabModule = function (tabModuleDomElement) {
    "use strict";
    var $thisTabModule = tabModuleDomElement;

    var _setDefaultContent = function () {
        // set default for links
        if ($(".expander__link." + _settings.activeClass, $thisTabModule).length === 0) {
            $(".expander__link", $thisTabModule).first().addClass(_settings.activeClass);
        }

        // set default for content
        if ($(".expander__content." + _settings.activeClass, $thisTabModule).length === 0) {
            $(".expander__content", $thisTabModule).first().addClass(_settings.activeClass);
        }
    };

    var _createTabs = function () {
        // create the menu to hold tabs
        var $menu = $("<ul />", { class: _settings.menuClass.replace(".", "") });

        // append all links to the menu inside a tab
        $(".expander__link", $thisTabModule)
            .appendTo($menu)
            .wrap("<li class='expander__item'></li>");

        $thisTabModule.prepend($menu);

        // set the default content to be open if required
        _setDefaultContent();

        // rebind the click function
        $(".expander__link", $thisTabModule).unbind("click").on("click", function (e) {
            e.preventDefault();

            var $link = $(this);

            // switch the current link
            $link.addClass(_settings.activeClass);
            $(".expander__link", $thisTabModule).not($link).removeClass(_settings.activeClass);

            var content = $link.attr("href");

            // hide other active content areas
            $(".expander__content", $thisTabModule).not(content).removeClass(_settings.activeClass);

            // set the active content area
            $(content).addClass(_settings.activeClass);

            return false;
        });

        $thisTabModule
            .removeClass("expander--collapsible  expander--init")
            .addClass("expander--tabs  expander--init");
    };

    var _createAccordion = function () {
        Accordion.createAccordion($thisTabModule);
        $thisTabModule.removeClass("expander--tabs");
    };

    var _switchToTabs = function () {
        _createTabs();
    };

    var _switchToAccordion = function () {
        // find the menu
        var $menu = $(_settings.menuClass, $thisTabModule);

        // find each link in menu
        $(".expander__link", $menu).each(function () {

            var $link = $(this),
                $content = $($link.attr("href"));

            // move it to just before its content partner
            $link.insertBefore($content);

        });

        $menu.remove();
        _createAccordion();
    };

    var _isAccordionState = function () {
        // based on existence of tab menu markup
        return $thisTabModule.find(_settings.menuClass).length === 0;
    };

    this.switchToTabs = _switchToTabs;
    this.switchToAccordion = _switchToAccordion;
    this.createAccordion = _createAccordion;
    this.isAccordionState = _isAccordionState;

};

var _handleResize = function () {
    "use strict";
    // check whether to do anything
    if (_globals.isAvailable === false){
        return;
    }

    //For each registered Expander module -
    $.each(_tabModules, function () {
        var _thisExpanderModule = this;

        if (Modernizr.mq("(min-width : " + _settings.breakpoint+")") && _thisExpanderModule.isAccordionState()) {
            _thisExpanderModule.switchToTabs();
        } else if (Modernizr.mq("(max-width : " + _settings.breakpoint+")") && _thisExpanderModule.isAccordionState() === false) {
            _thisExpanderModule.switchToAccordion();
        }
    });
};

var init = function () {
    "use strict";
    // check existence of tabs
    if ($(_settings.selector).length === 0) {
        _globals.isAvailable = false;
        return;
    }

    //For each expander module in the html -
    $(_settings.selector).each(function () {
        //Create a new tabModule -
        var tabModule = new TabModule($(this));

        //Store a reference to each for onResize actions -
        _tabModules.push(tabModule);

        // determine what we should do on startup
        if (Modernizr.mq("(min-width : " + _settings.breakpoint+")") && tabModule.isAccordionState()) {
            // if larger screen sizes and currently in accordion state, switch
            tabModule.switchToTabs($(this));
        } else {
            // otherwise go ahead and create accordion on smaller screens
            tabModule.createAccordion($(this));
        }
    });

    $(window).on("throttledresize", _handleResize);
};

module.exports = {
    init: init
};
