// Filterable functionality
/*
    When a ".filter-options__item" is clicked,
    Look up it"s data-filter attribute.

    Fade out the ".filtered-container",
    Set it"s children to visibile or invisible based on if they match the filter data

    Then fade it back in.

    Any filter names can be used, other than "all" which is a reserved word, used to show all items
*/

//vars -
var _settings = {
    filterOptionClass: ".js-filter-options",
    filterOptionItemClass: ".js-filter-options__item",

    defaultFilterOptionItemClass: ".js-filter-options__item--default",

    filteredContainerClass: ".js-filtered-container",
    filteredContainerItemClass: ".js-filtered-container__item",

    filterDataName: "filter",
    focusClass: "js-focus"
};

var currentFilter = "all";

var $filterOptionContainer;
var $filterOptionItems;
var $filteredContainer;
var $filteredContainerItems;

var animtionHandler;

//functions -
var _filterModule = {
    initFilterSection: function () {
        "use strict";
        // On clicking a filter control -
        $filterOptionContainer.on("click", "a", _filterModule.filterSelected);

        //If there is a default option - set the focus class -
        if ($(_settings.defaultFilterOptionItemClass)) {
            $(_settings.defaultFilterOptionItemClass).find("a").addClass(_settings.focusClass);
        }
    },

    filterSelected: function () {
        "use strict";
        // Look up the filter data -
        var selectedFilter = $(this).data(_settings.filterDataName);

        //Remove any focused filters -
        $filterOptionContainer.find("." + _settings.focusClass).removeClass(_settings.focusClass);

        //Add the focus class to this filter -
        $(this).addClass(_settings.focusClass);

        //If it"s changed, call the filter function -
        if (currentFilter !== selectedFilter) {
            _filterModule.filterItemsBy(selectedFilter);
            currentFilter = selectedFilter;
        }
    },

    //Filter the items by the data name -
    filterItemsBy: function (filterName) {
        "use strict";
        if (animtionHandler) {
            animtionHandler.stop();
        }

        //Fade out the container -
        $filteredContainer.fadeOut("fast", function () {
            //Check if the filter name is "all" - a reserved word which will always show all the items -
            var showAll = false;

            //Check for reserved words -
            if (filterName === "all") {
                showAll = true;
            }

            //For each filterable item -
            $.each($filteredContainerItems, function () {
                //Remove the animation class to stop odd animations on filter -
                $(this).removeClass("animate-on-scroll").removeClass("fadeInUp").removeAttr("style");

                //If "all" selected, show them all -
                if (showAll) {
                    $(this).show();
                } else {
                    //Otherwise, check if their filter data matches the selected filter -
                    var show = ($(this).data(_settings.filterDataName) === filterName);

                    if (show) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                }
            });

            $filteredContainer.fadeIn("fast");
            $("body").trigger("TRIGGER_MATCH_HEIGHTS");
        });
    }
};

var init = function (wowInstance) {
    "use strict";
    //Set a reference to the main animaiton handler -
    animtionHandler = wowInstance;

    //If there is a filterable section on the page -
    if ($(_settings.filterOptionClass).length > 0) {
        //Look up and set up some dom vars -
        $filterOptionContainer = $(_settings.filterOptionClass);
        $filterOptionItems = $(_settings.filterOptionItemClass);

        $filteredContainer = $(_settings.filteredContainerClass);
        $filteredContainerItems = $(_settings.filteredContainerItemClass);

        //And init the module -
        _filterModule.initFilterSection();
    }

};

module.exports = {
    init: init
};
