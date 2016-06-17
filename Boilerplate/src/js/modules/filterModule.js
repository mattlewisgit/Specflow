/*
Filterable functionality

When a ".filter-options__item" is clicked,
Look up its data-filter attribute.

Fade out the ".filtered-container",
Set it"s children to visibile or invisible based on if they match the filter data

Then fade it back in.

Any filter names can be used, other than "all" which is a reserved word, used to show all items

There is a little added complexity for ensuring the matched-heights functionality works after filtering,
Though if there are no .js-match-height class instacns in the items, this will not be effected.
*/
define([
    "jquery",
    "modules/animationDelayModule",
    "smart-resize",
    "libraries/wow"
], function (
    $,
    AnimationDelayModule
) {
    "use strict";

    //vars -
    var _settings = {
        filterOptionClass: ".js-filter-options",
        filterOptionItemClass: ".js-filter-options__item",

        defaultFilterOptionItemClass: ".js-filter-options__item--default",

        filteredContainerClass: ".js-filtered-container",
        filteredContainerItemClass: ".js-filtered-container__item",

        filterDetailsClass: ".js-filter-section__details",
        filterCountClass: ".js-filter-matches",
        filterShowClass: "filter-show-item",
        filterStringClass: ".js-filter-string",

        filterDataName: "filter",
        focusClass: "js-focus"
    };

    var currentFilter = "all";
    var animationMode = "fast";
    var $filterOptionContainer;
    var $filterOptionItems;
    var $filteredContainer;
    var $filteredContainerItems;

    var $filterDetails;
    var $filterCount;
    var $filterString;

    var animationHandler;

    var firstFilter = true;

    function init(wowInstance) {
        // Set a reference to the main animaiton handler.
        animationHandler = wowInstance;

        if ($(_settings.filterOptionClass).length < 1) {
            return;
        }

        // Look up and set up some DOM vars.
        $filterOptionContainer = $(_settings.filterOptionClass);
        $filterOptionItems = $(_settings.filterOptionItemClass);

        $filteredContainer = $(_settings.filteredContainerClass);
        $filteredContainerItems = $(_settings.filteredContainerItemClass);

        $filterDetails = $(_settings.filterDetailsClass);
        $filterCount = $(_settings.filterCountClass);
        $filterString = $(_settings.filterStringClass);

        // ...and init the module.
        _initFilterSection();
    }

    function _initFilterSection() {
        $filterOptionContainer.on("click", "a", _filterSelected);
        var filterOption = $(_settings.defaultFilterOptionItemClass);
        
        if (filterOption) {
            filterOption.find("a").addClass(_settings.focusClass);
        }

        // On resize, set the match heights.
        $(window).smartresize(_matchHeightsOfFilteredItems);
    }

    function _filterSelected(e) {
        var target = $(e.target);
        e.preventDefault();

        // Look up the filter data.
        var selectedFilter = target.data(_settings.filterDataName);

        // Remove any focused filters.
        $filterOptionContainer
            .find("." + _settings.focusClass)
            .removeClass(_settings.focusClass);

        // Add the focus class to this filter.
        target.addClass(_settings.focusClass);

        // If it has changed, call the filter function.
        if (currentFilter !== selectedFilter) {
            _filterItemsBy(selectedFilter);
            currentFilter = selectedFilter;
        }
    }

    function _resetHeightMatchClasses(suffix) {
        suffix = suffix || "";

        $filteredContainer
            .find(".js-match-height" + suffix)
            .removeClass("js-match-height" + suffix)
            .addClass("js-filter-match-height" + suffix);
    }

    // Filter the items by the data name.
    function _filterItemsBy(filterName) {
        if (animationHandler) {
            animationHandler.stop();
        }

        $filterDetails.fadeTo(animationMode, 0);

        // Fade out the container.
        $filteredContainer.fadeTo(animationMode, 0, function() {
            // If this is the first time we are filtering, reset the match height functions.
            if (firstFilter) {
                firstFilter = false;

                // Remove the any match height classes, as they will be overriden.
                _resetHeightMatchClasses();
                _resetHeightMatchClasses("--2");

                // Reset the main match height function to no longer include these items.
                $("body").trigger("RESET_MATCH_HEIGHTS");
            }

            // Show all if the reserved word is matched.
            var showAll = filterName === "all";
            var count = 0;

            // Reset which filter items are selected
            $("." + _settings.filterShowClass).removeClass(_settings.filterShowClass);

            $.each($filteredContainerItems, function(i, element) {
                element = $(element);
                element.attr("data-wow-delay", "");

                if (showAll) {
                    return element
                        .show()
                        .addClass(_settings.filterShowClass);
                }

                // Otherwise, check if their filter data matches the selected filter.
                var show = (element.data(_settings.filterDataName) === filterName);

                if (show) {
                    element.show().addClass(_settings.filterShowClass);
                    return count++;
                }

                return element.hide();
            });

            if (!showAll) {
                $filterCount.html(count);
                $filterString.html(filterName);
                $filterDetails.fadeTo(animationMode, 1);
            }

            // Fade the conatiner back in.
            $filteredContainer.fadeTo(animationMode, 1);
            _matchHeightsOfFilteredItems();
        });
    }

    function _matchHeightsOfFilteredItems() {
        var showItem = $("." + _settings.filterShowClass);
        showItem.find(".js-filter-match-height").matchHeight();
        showItem.find(".js-filter-match-height--2").matchHeight();

        AnimationDelayModule.init(showItem);

        if (Modernizr.mq("(min-width : 770px)")) {
            new WOW({
                boxClass: "js-animate-on-scroll"
            }).init();
        }
    }

    return {
        init: init
    };
});
