(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
// jscs:disable maximumNumberOfLines
var MomentApi = require("../config/moment-api.json");

var events = {
    dateFilter: "dateFilter",
    documentedSelected: "documentedSelected",
    typeSelected: "typeSelected"
};

window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersSalesLiteratureApp", ["LiteratureLibraryService"])
    .directive("typeahead", [
        "$rootScope",
        "LiteratureLibraryService",
        function ($rootScope, LiteratureLibraryService) {
            "use strict";
            return {
                link: function (scope, element) {
                    $(element)
                        .typeahead({
                            highlight: true,
                            hint: false,
                            minLength: 1
                        },
                        {
                            displayKey: "Title",
                            limit: 10,
                            name: "literature",
                            source: function (text, callback) {
                                callback(LiteratureLibraryService.searchDocuments(text));
                            },
                            templates: {
                                notFound: "<div class=\"tt-no-results\">" +
                                    "Sorry, there are no matching documents.</div>"
                            }
                        })
                        .bind("typeahead:select", function (event, document) {
                            $rootScope.$broadcast(events.documentedSelected, document);
                            $rootScope.$broadcast(events.typeSelected);
                        });
                },
                restrict: "A"
            };
        }
    ])
    .controller("DateController", [
        "$scope",
        "$rootScope",
        function ($scope, $rootScope) {
            "use strict";
            // Initialise the date model with today.
            var today = new Date();

            $scope.filterDate = {
                day: today.getDate(),
                month: today.getMonth() + 1,
                year: today.getFullYear()
            };

            $scope.filterAction = function (dateForm, filterDate) {
                // Generate a date.
                var actualDate = moment([filterDate.year, filterDate.month - 1, filterDate.day]);

                // Reset the validity.
                dateForm.$setValidity("filterDate", true);
                dateForm.day.$setValidity("day", true);
                dateForm.month.$setValidity("month", true);

                // Check for validity and show the first date error where possible.
                if (!actualDate.isValid()) {
                    switch (actualDate.invalidAt()) {
                        case MomentApi.invalidAtUnit.months:
                            dateForm.month.$setValidity("month", false);
                            return;
                        case MomentApi.invalidAtUnit.days:
                            dateForm.day.$setValidity("day", false);
                            return;
                        default:
                            dateForm.$setValidity("filterDate", false);
                            return;
                    }
                }

                // Broadcast the filter event.
                $rootScope.$broadcast(events.dateFilter, actualDate);
            };
        }
    ])
    .controller("ChooseController", [
        "$scope",
        "$rootScope",
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            LiteratureLibraryService.getCategories(function (categories) {
                $scope.types = categories;
            });

            // Broadcast the type and update the view state.
            this.loadType = function (typeToLoad) {
                $rootScope.$broadcast(events.typeSelected, typeToLoad);
                var typeToLoadName = typeToLoad.Name;

                $scope.types.forEach(function (literatureType) {
                    literatureType.IsSelected =
                        literatureType.Name === typeToLoadName;
                });
            };
        }
    ])
    .controller("AvailableController", [
        "$scope",
        "$rootScope",
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            $rootScope.$on(events.typeSelected, function (event, literatureType) {
                // Clear out the literature if none provided.
                if (!literatureType) {
                    return ($scope.literature = []);
                }

                // Fetch the data.
                $scope.literature = LiteratureLibraryService.getDocuments(literatureType.Name);

                // Deselect all of the documents.
                $scope.literature.forEach(function (document) {
                    document.IsSelected = false;
                });
            });

            $rootScope.$on(events.dateFilter, function (event, filterDate) {
                // Ignore if the date is empty.
                if (!filterDate) {
                    return;
                }

                // Fetch the data.
                $scope.literature = LiteratureLibraryService.filterByDate(filterDate);

                // Deselect all of the documents.
                $scope.literature.forEach(function (document) {
                    document.IsSelected = false;
                });
            });

            // Broadcast the selected document and update the view state.
            this.loadDocument = function (documentToLoad) {
                $rootScope.$broadcast(events.documentedSelected, documentToLoad);
                var documentToLoadKey = documentToLoad.Key;

                $scope.literature.forEach(function (document) {
                    document.IsSelected = document.Key === documentToLoadKey;
                });
            };
        }
    ])
    .controller("DocumentController", [
        "$scope",
        "$rootScope",
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            $rootScope.$on(events.documentedSelected, function (event, document) {
                $scope.document = LiteratureLibraryService.getDocument(document.Key);

                // Force apply, as the typeahead jQuery event mode update may not re-render!
                // Note this is an anti-pattern and would be resolved by integrating typeahead.js
                // correctly with Angular:
                // https://github.com/angular/angular.js/wiki/Anti-Patterns
                if (!$scope.$$phase) {
                    $scope.$apply();
                }
            });
        }
    ]);

},{"../config/moment-api.json":3}],2:[function(require,module,exports){
module.exports=﻿{
    "mobile": "350px",
    "mobile-landscape": "540px",
    "tablet": "770px",
    "desktop": "1025px",
    "wide": "1200px",
    "max": "1440px"
}

},{}],3:[function(require,module,exports){
module.exports={
    "invalidAtUnit": {
        "years": 0,
        "months": 1,
        "days": 2,
        "hours": 3,
        "minutes": 4,
        "seconds": 5,
        "milliseconds": 6
    }
}

},{}],4:[function(require,module,exports){
module.exports={
    "autohide": 1,
    "autoplay": 0,
    "cc_load_policy": 0,
    "controls": 0,
    "disablekb": 0,
    "enablejsapi": 1,
    "fs": 0,
    "hl": "en",
    "iv_load_policy": 3,
    "loop": 1,
    "modestbranding": 1,
    "playsinline": 1,
    "rel": 0,
    "showinfo": 0
}

},{}],5:[function(require,module,exports){
require("./angular/healthAdvisersLiteratureApp");

var AccordionModule = require("./modules/accordionModule");
var AnimationDelayModule = require("./modules/animationDelayModule");
var Breakpoints = require("./modules/breakpointsModule");
var CookieMessageModule = require("./modules/cookieMessageModule");
var FilterModule = require("./modules/filterModule");
var HomeHeroModule = require("./modules/homeHeroModule");
var MatchHeightsModule = require("./modules/matchHeightsModule");
var MatchWidthsModule = require("./modules/matchWidthsModule");
var MenuModule = require("./modules/menuModule");
var QuoteFooterModule = require("./modules/quoteFooterModule");
var SearchModule = require("./modules/searchModule");
var SocialShareModule = require("./modules/socialShareModule");
var TabsModule = require("./modules/tabsModule");

function _initVendor() {
    "use strict";
    FastClick.attach(document.body);

    // TableSaw responsive tables.
    if (!$("html").hasClass("disable-tablesaw")) {
        $(document).trigger("enhance.tablesaw");
    }

    // Add WOW for larger screens.
    if (Breakpoints.min.tablet.test()) {
        var wow = new WOW({
            boxClass: "animate-on-scroll"
        });

        wow.init();
        return wow;
    }

    // Add a class showing that the animation library has not been initialised.
    $("html").addClass("no-js-animations");
    return null;
}

function _initCustom(wow) {
    "use strict";
    MenuModule.init();

    SocialShareModule.init();

    AccordionModule.init();
    CookieMessageModule.init();
    HomeHeroModule.init();
    TabsModule.init();

    // Check for filterable content with the animation instance.
    FilterModule.init(wow);

    // Match sizes.
    MatchHeightsModule.init();
    MatchWidthsModule.init();

    QuoteFooterModule.init();
    AnimationDelayModule.init();
    SearchModule.init();
}

$(document).ready(function () {
    "use strict";
    _initCustom(_initVendor());
});

},{"./angular/healthAdvisersLiteratureApp":1,"./modules/accordionModule":6,"./modules/animationDelayModule":7,"./modules/breakpointsModule":8,"./modules/cookieMessageModule":10,"./modules/filterModule":11,"./modules/homeHeroModule":12,"./modules/matchHeightsModule":13,"./modules/matchWidthsModule":14,"./modules/menuModule":15,"./modules/quoteFooterModule":16,"./modules/searchModule":17,"./modules/socialShareModule":18,"./modules/tabsModule":19}],6:[function(require,module,exports){
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

},{"./collapsibleModule":9}],7:[function(require,module,exports){
/*
 * Utility to set animaiton delays based on column position,
 * so elements animate in with the correct delay for variable column widths.
 */
var Breakpoints = require("./breakpointsModule");

var _settings = {
    animationDelayClass: ".column-animation-delay"
};

var BASE_ANIMATION_DELAY = 0.5;
var COLUMN_ANIMAITON_DELAY_STEP = 0.2;

var $animationElements;
var prevElTop = 0;
var count = 0;

var _animationDelayMod = {
    init: function () {
        "use strict";
        $animationElements = $(_settings.animationDelayClass);
        _animationDelayMod.setDelays();
        $(window).on("throttledresize", _animationDelayMod.setDelays);
    },

    setDelays: function () {
        "use strict";

        if (!Breakpoints.min.tablet.test()) {
            return;
        }

        $.each($animationElements, function (el) {
            var $el = $(el);
            var thisElTop = $el.position().top;

            if (prevElTop !== thisElTop) {
                // Set the variables for the new row.
                count = 0;
                prevElTop = thisElTop;
            } else {
                count++;
            }

            var animDelay = BASE_ANIMATION_DELAY + (COLUMN_ANIMAITON_DELAY_STEP * count);
            $el.attr("data-wow-delay", animDelay + "s");
        });
    }
};

module.exports = {
    init: _animationDelayMod.init
};

},{"./breakpointsModule":8}],8:[function(require,module,exports){
var data = require("../breakpoints.json");

// Take raw breakpoint values from JSON and repackage them
// as reusable values and Modernizr media query tests!
var breakpoints = {
    max: {},
    min: {}
};

$.each(data, function (name, value) {
    "use strict";
    var max = "(max-width: " + value + ")";
    var min = "(min-width: " + value + ")";

    // Creates values and functions for each breakpoint,
    // as they need to be evaluated each time, not precalculated.
    // e.g. breakpoints.max.desktop.test()
    breakpoints.max[name] = {
        test: function () {
            return Modernizr.mq(max);
        },
        value: max
    };

    breakpoints.min[name] = {
        test: function () {
            return Modernizr.mq(min);
        },
        value: min
    };
});

module.exports = breakpoints;

},{"../breakpoints.json":2}],9:[function(require,module,exports){
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

},{"./breakpointsModule":8}],10:[function(require,module,exports){
var _container = null;
var _cookieReadKey = "hasReadCookieMessage";
var _cookieSeenKey = "hasSeenCookieMessage";
var _areCookiesDisabled = false;

var _expiry = {
    expires: 365
};

function init() {
    "use strict";
    // Bomb out if there is no cookie container, or the read cookie is set.
    _container = $(".cookie-message");
    _areCookiesDisabled = $("html").hasClass("disable-cookies");

    if (_container.length < 1 || (!_areCookiesDisabled && !!Cookies.get(_cookieReadKey))) {
        return;
    }

    // Animate the message if it has not been seen before.
    if (!Cookies.get(_cookieSeenKey)) {
        _container
            .addClass("animated")
            .addClass("slideInDown");
    }

    // Show the message and stop if from being animated again.
    _container.show();

    if (!Cookies.get(_cookieSeenKey)) {
        Cookies.set(_cookieSeenKey, true, _expiry);
    }

    // Hide the message and stop it from being shown again on accept.
    _container.find(".box-button").click(function () {
        _container
            .addClass("animated")
            .removeClass("slideInDown")
            .addClass("slideOutUp");

        if (!_areCookiesDisabled) {
            Cookies.set(_cookieReadKey, true, _expiry);
        }

        // Hide after animating.
        setTimeout(function () {
            _container.hide();
        }, 500);

        return false;
    });
}

module.exports = {
    init: init
};

},{}],11:[function(require,module,exports){
/*
    When a ".filter-options__item" is clicked, look up its data-filter attribute.
    Fade out the ".filtered-container", set its children to visibile or invisible
    based on if they match the filter data, then fade it back in.
    Any filter names can be used, other than "all" which is a reserved word, used
    to show all items.
*/

var _settings = {
    defaultFilterOptionItemClass: ".js-filter-options__item--default",
    filterDataName: "filter",
    filterOptionClass: ".js-filter-options",
    filterOptionItemClass: ".js-filter-options__item",
    filterSeparator: ",",
    filteredContainerClass: ".js-filtered-container",
    filteredContainerItemClass: ".js-filtered-container__item",
    focusClass: "js-focus"
};

var currentFilter = "all";

var $filterOptionContainer;
var $filterOptionItems;
var $filteredContainer;
var $filteredContainerItems;

var animtionHandler;

var _filterModule = {
    // Filter the items by the data name.
    filterItemsBy: function (filterName) {
        "use strict";

        if (animtionHandler) {
            animtionHandler.stop();
        }

        // Fade out the container.
        $filteredContainer.fadeOut("fast", function () {
            // Check if the filter name is "all",
            // a reserved word which will always show all the items.
            var showAll = (filterName === "all");

            // For each filterable item.
            $.each($filteredContainerItems, function () {
                // Remove the animation class to stop odd animations on filter.
                $(this)
                    .removeClass("animate-on-scroll")
                    .removeClass("fadeInUp")
                    .removeAttr("style");

                // If "all" selected, show them all.
                if (showAll) {
                    $(this).show();
                } else {
                    // Otherwise, check if their filter data contains the selected filter.
                    var filters = $(this)
                        .data(_settings.filterDataName)
                        .split(_settings.filterSeparator);

                    if ($.inArray(filterName, filters) > -1) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                }
            });

            $filteredContainer.fadeIn("fast");
            $("body").trigger("TRIGGER_MATCH_HEIGHTS");
        });
    },

    filterSelected: function () {
        "use strict";
        // Look up the filter data.
        var selectedFilter = $(this).data(_settings.filterDataName);

        // Remove any focused filters.
        $filterOptionContainer.find("." + _settings.focusClass).removeClass(_settings.focusClass);

        // Add the focus class to this filter.
        $(this).addClass(_settings.focusClass);

        // If it has changed, call the filter function.
        if (currentFilter !== selectedFilter) {
            _filterModule.filterItemsBy(selectedFilter);
            currentFilter = selectedFilter;
        }
    },

    initFilterSection: function () {
        "use strict";
        // On clicking a filter control.
        $filterOptionContainer.on("click", "a", _filterModule.filterSelected);

        // If there is a default option - set the focus class.
        if ($(_settings.defaultFilterOptionItemClass)) {
            $(_settings.defaultFilterOptionItemClass).find("a").addClass(_settings.focusClass);
        }
    }
};

function init(wowInstance) {
    "use strict";
    // Set a reference to the main animaiton handler.
    animtionHandler = wowInstance;

    // If there is a filterable section on the page.
    if ($(_settings.filterOptionClass).length > 0) {
        // Look up and set up some dom vars.
        $filterOptionContainer = $(_settings.filterOptionClass);
        $filterOptionItems = $(_settings.filterOptionItemClass);

        $filteredContainer = $(_settings.filteredContainerClass);
        $filteredContainerItems = $(_settings.filteredContainerItemClass);

        // Init the module.
        _filterModule.initFilterSection();
    }
}

module.exports = {
    init: init
};

},{}],12:[function(require,module,exports){
// jscs:disable maximumNumberOfLines
var YouTubeAPIBaseConfig = require("../config/youtube-api-base-config.json");

var _classes = {
    button: {
        pause: "svg-svg--button-video-pause",
        play: "svg-svg--button-video-play"
    },
    fade: {
        in: "fadeIn",
        out: "fadeOut"
    }
};

var _timeoutDuration = 750;

function _fadeOut(element) {
    "use strict";
    return element && element
        .removeClass(_classes.fade.in)
        .addClass(_classes.fade.out);
}

function _fadeIn(element) {
    "use strict";
    return element && element
        .removeClass(_classes.fade.out)
        .addClass(_classes.fade.in);
}

function _enhanceHero(i, el) {
    "use strict";

    // State.
    // Replace the container with a player iframe,
    // using the video data attribute as the ID.
    var hero = $(el);

    var overlay = hero.find(".home-hero--static");
    var backgroundImage = overlay.css("background-image");

    var paragraph = hero.find("p");
    var header = hero.find(".header");
    var button = hero.find(".home-hero--static__button");
    var videoContainer = hero.find(".youtube-video");

    var videoId = videoContainer.data("youtube-id");

    // Set the element to always animate.
    var fadedElements = [header, paragraph, button];

    fadedElements.forEach(function (element) {
        element.addClass("animated");
    });

    var player = null;
    // IPhone plays the video in its own player
    var isIPhone = !!navigator.userAgent.match(/(iPhone)|(iPod)/i);
    // Android and iPad plays inside the browser, therefore treated differently
    var isAndroidAndIpad = !!navigator.userAgent.match(/(iPad)|(Android)/i);

    var previousStatus = null;

    // Functions.
    function __hoverIn() {
        // Only fade in if we are currently playing.
        if (player.getPlayerState() !== YT.PlayerState.PLAYING) {
            return;
        }

        _fadeIn(button);
    }

    function __hoverOut() {
        // Only fade out if we are currently playing.
        if (player.getPlayerState() !== YT.PlayerState.PLAYING) {
            return;
        }

        _fadeOut(button);
    }

    function __play() {
        fadedElements.forEach(_fadeOut);

        // Wait for the element to fade out.
        setTimeout(function () {
            button
                .removeClass(_classes.button.play)
                .addClass(_classes.button.pause);

            if (!(isIPhone || isAndroidAndIpad)) {
                // Play now to pick up from where we left off.
                player.playVideo();
            }

            overlay
                .css("background-image", "none")
                .hover(__hoverIn, __hoverOut);
        }, _timeoutDuration);
    }

    function __pause() {
        button
            .removeClass(_classes.button.pause)
            .addClass(_classes.button.play);

        fadedElements.forEach(_fadeIn);

        if (!(isIPhone || isAndroidAndIpad)) {
            player.pauseVideo();
        }

        overlay.css("background-image", backgroundImage);
    }

    function __changePlayerState(e) {
        // If it is Android and iPad, getPlayerState() returns the state after the click event.
        previousStatus = isAndroidAndIpad ? previousStatus : player.getPlayerState();
        // If the video is playing, pause it,
        // otherwise always try to play it.
        // When playing after paused on iOS, preventDefault has to be called
        // to get overlay back on display
        switch (previousStatus) {
            case YT.PlayerState.PLAYING:
                __pause(player);
                break;
            case YT.PlayerState.UNSTARTED:
                __play(player);
                break;
            default:
                // If preventDefault is not called for iPhone
                // it displays the overlay and get rid of it soon after
                if (isIPhone) {
                    e.preventDefault();
                }

                __play(player);
                break;
        }
        previousStatus = player.getPlayerState();
    }

    // Create the player!
    player = new YT.Player(videoContainer[0], {
        events: {
            // Remove the video container and button on fail.
            onError: function () {
                // An error here is likely to due to a prolem with the requested video itself.
                // For example, the original video ID was 1ER-hNTUVz4, which was made private,
                // and resulted in unhelpful, unrelated errors such as:
                // "Failed to execute 'postMessage' on 'DOMWindow': target/origin mismatch".
                hero.find(".video--responsive").remove();
                button.remove();
            },

            onReady: function () {
                // Disable overlay click events for mobile environment
                // Can't do this for normal browsers due to pausing delay
                // And pause button not displaying while playing
                if (isIPhone || isAndroidAndIpad) {
                    overlay.css("pointer-events", "none");
                    player.addEventListener("onStateChange", __changePlayerState);
                } else {
                    // Use .mute() now in the future if sound should be disabled.
                    overlay.click(__changePlayerState);
                }
            }
        },

        playerVars: YouTubeAPIBaseConfig,
        videoId: videoId,
        width: "100%"
    });
}

function _init() {
    "use strict";
    var heroes = $(".home-hero--video");

    // Bomb out if no video heroes are present.
    if (heroes.length < 1) {
        return;
    }

    // Load the IFrame Player API asynchronously.
    $("script")
        .first()
        .before($("<script>").attr("src", "//www.youtube.com/player_api"));

    // Register a global function called by YouTube.
    window.onYouTubePlayerAPIReady = function () {
        heroes.each(_enhanceHero);
    };
}

module.exports = {
    init: _init
};

},{"../config/youtube-api-base-config.json":4}],13:[function(require,module,exports){
var _settings = {
    matchHeightClasses: [
        // Any element with the utility class of .match-height.
        ".match-height",

        // The top-content wrapper for the spotlights, to ensure the CTA links line up.
        ".spotlight-item__top-content",

        // The outisde container of the spotlight elements.
        ".spotlight-item"
    ]
};

var $allMatchHeightElements;

var _matchHeightMod = {
    init: function () {
        "use strict";
        // Populate the elements.
        $allMatchHeightElements = [];

        // For each match height class in the settings,
        // add it to the array of elements to be height matched.
        for (var i = 0; i < _settings.matchHeightClasses.length; i++) {
            $allMatchHeightElements.push($(_settings.matchHeightClasses[i]));
        }

        _matchHeightMod.matchHeights();
        $(window).on("throttledresize", _matchHeightMod.matchHeights);
        $("body").on("TRIGGER_MATCH_HEIGHTS", _matchHeightMod.matchHeights);
    },

    matchHeights: function () {
        "use strict";

        for (var i = 0; i < $allMatchHeightElements.length; i++) {
            $allMatchHeightElements[i].matchHeight();
        }
    }
};

module.exports = {
    init: _matchHeightMod.init
};

},{}],14:[function(require,module,exports){
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

},{}],15:[function(require,module,exports){
// jscs:disable maximumNumberOfLines
var Breakpoints = require("./breakpointsModule");

var $body;
var $html;
var $megaMenuItems;

var _settings = {
    focusClass: "js-focus",
    logInClass: "log-in-open",
    logInToggleSelector: "js-log-in-toggle",
    mainMenuToggleSelector: "js-main-menu-toggle",
    megaMenuClass: ".section-nav__item--megamenu",
    mobileMainMenuClass: "mainmenu-open",
    mobileMegaMenuClass: "megamenu-open",
    mobileMegaMenuOverflowClass: "megamenu-overflow",
    searchClass: "search-open",
    searchCloseClass: "js-search-close",
    searchOverflowClass: "search-overflow",
    searchToggleSelector: "js-search-toggle"
};

var _menuModule = {
    closeSearchMenu: function () {
        "use strict";
        $body.removeClass(_settings.searchOverflowClass);
        var _delay = 0.2;

        setTimeout(function () {
            $body.removeClass(_settings.searchClass);
        }, _delay);
    },

    // Slight delay before removing the overflow visible class from the mobile mega menu.
    // Prevents the megamenu being clipped before the transform is complete.
    delayRemoveMegaMenuOverflowClass: function (delay) {
        "use strict";
        delay = delay || 0;

        setTimeout(function () {
            $body.removeClass(_settings.mobileMegaMenuOverflowClass);
        }, delay);
    },

    delaySearchNoMaxHeight: function (delay) {
        "use strict";
        setTimeout(function () {
            $body.addClass(_settings.searchOverflowClass);
        }, delay || 0);
    },

    initMainMobile: function () {
        "use strict";
        // Tab index helpers - megamenu accessibility.
        $megaMenuItems = $(_settings.megaMenuClass);

        // Tab focus megamenu fix.
        $body.on("keydown", function (e) {
            // If tab pressed.
            if (e.keyCode === 9) {
                setTimeout(function () {
                    _menuModule.onTabCheckMegamenuFocus();
                    _menuModule.onTabCheckLoginFocus();
                }, 0.25);
            }
        });

        $("." + _settings.mainMenuToggleSelector).click(_menuModule.onMobileMenuButtonPressed);
        $("." + _settings.logInToggleSelector).click(_menuModule.onLogInButtonPressed);
        $("." + _settings.searchToggleSelector).click(_menuModule.onSearchButtonPressed);
        $("." + _settings.searchCloseClass).click(_menuModule.closeSearchMenu);

        // Temp.
        $(".log-in").click(function (e) {
            e.stopPropagation();
        });

        // Megamenu toggle for mobile.
        $megaMenuItems.click(_menuModule.onMobileMegaMenuSelect);

        // Megamenu toggle focus for opening on click of heading rather than hover.
        $megaMenuItems.click(_menuModule.onMegaMenuOpenTouchLarge);
    },

    // Toggle the log in panel.
    onLogInButtonPressed: function (e) {
        "use strict";
        e.preventDefault();
        e.stopPropagation();

        // Close the search if open.
        _menuModule.closeSearchMenu();

        if ($body.hasClass(_settings.logInClass)) {
            $body.removeClass(_settings.logInClass);
        } else {
            $body.addClass(_settings.logInClass);

            // Close the main menu if open.
            if ($body.hasClass(_settings.mobileMainMenuClass)) {
                _menuModule.onMobileMenuButtonPressed();
            }
        }
    },

    // Megamenu touch events: for large sceen layouts, but with no mouse eg. iPads.
    onMegaMenuOpenTouchLarge: function (e) {
        "use strict";

        if (!Modernizr.touchevents || !Breakpoints.min.tablet.test()) {
            return;
        }

        event.stopPropagation();

        // If this menu already has focus, follow the link to the overview landing page.
        if ($(this).hasClass(_settings.focusClass)) {
            return;
        }

        // Prevent the click-through to the overview landing page.
        e.preventDefault();

        // Otherwise, remove focus from any other megamenus.
        $("." + _settings.focusClass).removeClass(_settings.focusClass);

        // Open this megamenu.
        $(this).addClass(_settings.focusClass);

        // Add listener for clicking anything other than the megamenu, to close it again.
        $html.click(_menuModule.onTouchOutsideOpenMegaMenu);
    },

    // Mobile mega menu open and close.
    onMobileMegaMenuSelect: function (e) {
        "use strict";

        if (!Breakpoints.max.tablet.test()) {
            return;
        }

        var $this = $(this);
        var $target = $(e.target);

        // Check if the section is already open.
        if ($this.hasClass(_settings.focusClass)) {
            // Check for the back button.
            if (($target.hasClass("megamenu__back"))) {
                e.preventDefault();
                e.stopPropagation();
                $body.removeClass(_settings.mobileMegaMenuClass);
                _menuModule.delayRemoveMegaMenuOverflowClass(500);
            }

            // Remove all active sections.
            $("." + _settings.focusClass).removeClass(_settings.focusClass);

            // Otherwise, no action - follow the link :)
            return;
        }

        // Open the mega menu.
        e.preventDefault();
        e.stopPropagation();
        $body.addClass(_settings.mobileMegaMenuClass);
        $body.addClass(_settings.mobileMegaMenuOverflowClass);

        // Remove other active sections.
        $("." + _settings.focusClass).removeClass(_settings.focusClass);
        $(this).addClass(_settings.focusClass);
    },

    // The mobile toggle menu button.
    onMobileMenuButtonPressed: function (e) {
        "use strict";

        if (e) {
            e.preventDefault();
            e.stopPropagation();
        }

        if ($body.hasClass(_settings.mobileMainMenuClass)) {
            $body.removeClass(_settings.mobileMainMenuClass);

            // Remove all active sections.
            $("." + _settings.focusClass).removeClass(_settings.focusClass);

            // Remove open megamenu toggle.
            $body.removeClass(_settings.mobileMegaMenuClass);
            _menuModule.delayRemoveMegaMenuOverflowClass();
        } else {
            $body.addClass(_settings.mobileMainMenuClass);

            // Close the search and login panels if open.
            _menuModule.closeSearchMenu();

            $body.removeClass(_settings.logInClass);
        }
    },

    onSearchButtonPressed: function (e) {
        "use strict";
        e.preventDefault();
        e.stopPropagation();

        // Close the log in panel if open.
        $body.removeClass(_settings.logInClass);

        if ($body.hasClass(_settings.searchClass)) {
            _menuModule.closeSearchMenu();
        } else {
            $body.addClass(_settings.searchClass);
            _menuModule.delaySearchNoMaxHeight(750);

            // Close the main menu if open.
            if ($body.hasClass(_settings.mobileMainMenuClass)) {
                _menuModule.onMobileMenuButtonPressed();
            }
        }
    },

    // Tab buttons for Log In menu.
    onTabCheckLoginFocus: function () {
        "use strict";
        var loginIcon = $("." + _settings.logInToggleSelector);

        // Check if a child element has focus.
        var hasFocus = (loginIcon.find(":focus").length > 0);

        // Conditionally add or remove the class.
        if (hasFocus) {
            loginIcon.addClass(_settings.focusClass);
            $body.addClass(_settings.logInClass);
        } else {
            loginIcon.removeClass(_settings.focusClass);
            $body.removeClass(_settings.logInClass);
        }
    },

    // Tab button focus megamenu for accessibility.
    onTabCheckMegamenuFocus: function () {
        "use strict";
        var count = 0;

        $.each($megaMenuItems, function () {
            var mmItem = $(this);

            // Check if a child element has focus.
            var hasFocus = (mmItem.find(":focus").length > 0);

            // Conditionally add or remove the class.
            if (hasFocus) {
                mmItem.addClass(_settings.focusClass);
                count++;
            } else {
                mmItem.removeClass(_settings.focusClass);
            }
        });

        if (count === 0) {
            $body.removeClass(_settings.mobileMegaMenuClass);
            _menuModule.delayRemoveMegaMenuOverflowClass();
        } else {
            $body
                .addClass(_settings.mobileMegaMenuClass)
                .addClass(_settings.mobileMegaMenuOverflowClass);
        }
    },

    onTouchOutsideOpenMegaMenu: function () {
        "use strict";
        $("." + _settings.focusClass).removeClass(_settings.focusClass);

        // Remove listener for clicking anything other than the megamenu, to close it again.
        $html.off("click", _menuModule.onTouchOutsideOpenMegaMenu);
    },

    // If touch outside of the open menu on mobile,
    // close it, unless it is a menu link to follow.
    onTouchOutsideOpenMobileMenu: function (e) {
        "use strict";
        var target = $(e.target);

        if (!target.is("a")) {
            // Trigger a click to close the menu.
            $("." + _settings.mainMenuToggleSelector).trigger("click");

            // Remove listener for clicking anything other than the megamenu, to close it again.
            $html.off("click", _menuModule.onTouchOutsideOpenMobileMenu);
        }
    }
};

module.exports = {
    init: function () {
        "use strict";
        $body = $("body");
        $html = $("html");

        _menuModule.initMainMobile();
    }
};

},{"./breakpointsModule":8}],16:[function(require,module,exports){
var Breakpoints = require("./breakpointsModule");

var settings = {
    breakpoint: Breakpoints.max.tablet,
    footer: null,
    footerBody: null,
    footerHeader: null,
    hiddenClass: "quote-footer--body__hidden",
    isCollapsed: false,
    isExpanded: false,
    pageFooter: null
};

/**
 * @description
 *   Adapts the quote footer based on a media query.
 *   For backwards-compatibility, the mql is optional,
 *   so this can be fired from window.matchMedia or window.resize.
 * @param {MediaQueryListEvent} [mql] From window.matchMedia.
 * @private
 */
function _adapt(mql) {
    "use strict";

    if (settings.isExpanded) {
        return;
    }

    if ((mql && mql.matches) || settings.breakpoint.test()) {
        if (!settings.isCollapsed) {
            // Cache the collapsed state and hide.
            settings.isCollapsed = true;
            _hide();
        }
    } else {
        settings.isCollapsed = false;
        _show();
    }
}

function _adaptPageFooter(height) {
    "use strict";
    // Note: setTimeout cannot be moved to this function!
    settings.pageFooter.css("padding-bottom", (height + 20) + "px");
}

function _hide() {
    "use strict";
    settings.footerBody.addClass(settings.hiddenClass);

    setTimeout(function () {
        _adaptPageFooter(settings.footerHeader.outerHeight());
    }, 350);
}

function _show() {
    "use strict";
    settings.footerBody.removeClass(settings.hiddenClass);

    setTimeout(function () {
        _adaptPageFooter(settings.footer.outerHeight());
    }, 350);
}

function _toggle() {
    "use strict";
    settings.isExpanded = !settings.isExpanded;
    return settings.isExpanded ? _show() : _hide();
}

module.exports = {
    init: function () {
        "use strict";
        settings.footer = $(".quote-footer");

        // Ignore if no footer found, or it is hidden in Experience Editor.
        if (!settings.footer.length || settings.footer.is(":hidden")) {
            return null;
        }

        settings.footerBody = $(".quote-footer--body");
        settings.footerHeader = settings.footer.find(".quote-footer--tab");
        settings.pageFooter = $("footer:last-of-type");

        // If only a single button is present,
        // hide the tab and permanently show the button.
        if (settings.footerBody.children().length < 2) {
            settings.footerHeader.hide();
            return _show();
        }

        // For multiple buttons, register events and adapt the footer.
        settings.footerHeader.find("a").click(_toggle);
        _adapt();

        // Attach the adapt event to the matchMedia listener
        // if possible, to prevent it from being called every
        // time the window resizes, which is the failover for old browsers.
        if (window.matchMedia) {
            return window
                .matchMedia(settings.breakpoint.value)
                .addListener(_adapt);
        }

        return $(window).resize(_adapt);
    }
};

},{"./breakpointsModule":8}],17:[function(require,module,exports){
var _settings = {
    searchInputClass: ".js-search-input",
    searchMatchesOutput: ".js-search-matches",
    searchStringOutput: ".js-search-string"
};

var $searchInput;
var $searchMatches;
var $searchOutput;

var _searchModule = {
    init: function () {
        "use strict";
        $searchInput.on("input", function () {
            var searchString = $(this).val();
            $searchOutput.html(searchString);
            var m = Math.round(Math.random() * 10);
            $searchMatches.html(m);

            $(".search-panel__search-results").show();
            $(".search-panel__search-details").show();
        });

        // Prevent scrolling of the large input text.
        $searchInput.on("mousewheel DOMMouseScroll", function (e) {
            e.stopPropagation();
            e.preventDefault();
            return false;
        });
    }
};

module.exports = {
    init: function () {
        "use strict";
        $searchInput = $(_settings.searchInputClass);
        $searchOutput = $(_settings.searchStringOutput);
        $searchMatches = $(_settings.searchMatchesOutput);

        _searchModule.init();
    }
};

},{}],18:[function(require,module,exports){
var _settings = {
    socialSharingLinkSelector: ".js-sharing-links"
};

var _socialShareModule = {
    configureShareData: function ($anchor) {
        "use strict";
        var socialChannel = $anchor.data("type");
        var shareUrl = $anchor.attr("href");

        switch (socialChannel) {
            case "facebook":
                window.open(shareUrl, "", "width=626,height=436");
                break;
            case "twitter":
                window.open(shareUrl, "", "width=575,height=400");
                break;
            case "linkedin":
                window.open(shareUrl, "", "width=974,height=510");
                break;
            default:
                break;
        }
    }
};

module.exports = {
    init: function () {
        "use strict";
        var $shareComponents = $(_settings.socialSharingLinkSelector);

        $shareComponents.on("click", function (e) {
            e.preventDefault();
            _socialShareModule.configureShareData($(this));
        });
    }
};

},{}],19:[function(require,module,exports){
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

},{"./accordionModule":6,"./breakpointsModule":8}]},{},[5]);
