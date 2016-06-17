// Filterable functionality
/*

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
        filterStringClass: ".js-filter-string",

        filterDataName: "filter",
        focusClass: "js-focus"
    };

    var currentFilter = "all";
    var $filterOptionContainer;
    var $filterOptionItems;
    var $filteredContainer;
    var $filteredContainerItems;

    var $filterDetails;
    var $filterCount;
    var $filterString;

    var animtionHandler;

    var firstFilter = true;

    function init(wowInstance) {
        //Set a reference to the main animaiton handler -
        animtionHandler = wowInstance;

        //If there is a filterable section on the page -
        if ($(_settings.filterOptionClass).length > 0) {

            //Look up and set up some dom vars -
            $filterOptionContainer = $(_settings.filterOptionClass);
            $filterOptionItems = $(_settings.filterOptionItemClass);

            $filteredContainer = $(_settings.filteredContainerClass);
            $filteredContainerItems = $(_settings.filteredContainerItemClass);

            $filterDetails = $(_settings.filterDetailsClass);
            $filterCount = $(_settings.filterCountClass);
            $filterString = $(_settings.filterStringClass);

            //And init the module -
            _initFilterSection();
        }
    }


    function _initFilterSection() {
        // On clicking a filter control -
        $filterOptionContainer.on("click", "a", _filterSelected);

        //If there is a default option - set the focus class -
        if ($(_settings.defaultFilterOptionItemClass)) {
            $(_settings.defaultFilterOptionItemClass).find("a").addClass(_settings.focusClass);
        }

        //On resize, set the match heights -
        $(window).smartresize(_matchHeightsOfFilteredItems);

    }

    function _filterSelected(e) {
        var target = $(e.target);
        e.preventDefault();

        // Look up the filter data -
        var selectedFilter = target.data(_settings.filterDataName);

        //Remove any focused filters -
        $filterOptionContainer.find("." + _settings.focusClass).removeClass(_settings.focusClass);

        //Add the focus class to this filter -
        target.addClass(_settings.focusClass);

        //If it"s changed, call the filter function -
        if (currentFilter !== selectedFilter) {
            _filterItemsBy(selectedFilter);
            currentFilter = selectedFilter;
        }

    }

    //Filter the items by the data name -
    function _filterItemsBy(filterName) {
        if (animtionHandler) {
            animtionHandler.stop();
        }

        $filterDetails.fadeTo("fast", 0);

        //Fade out the container -
        $filteredContainer.fadeTo("fast", 0, function () {

            //If this is the first time we"re filtering, reset the match height functions -
            if (firstFilter) {
                firstFilter = false;

                //Remove the any js-match-height classes - as we will be overriding it -
                $filteredContainer.find(".js-match-height").removeClass("js-match-height").addClass("js-filter-match-height");
                $filteredContainer.find(".js-match-height--2").removeClass("js-match-height--2").addClass("js-filter-match-height--2");

                //Reset the main match height function to no longer include these items -
                $("body").trigger("RESET_MATCH_HEIGHTS");
            }

            //Check if the filter name is "all" - a reserved word which will always show all the items -
            var showAll = false;
            var count = 0;

            //Reset which filter items are selected
            $(".filter-show-item").removeClass("filter-show-item");

            //Check for reserved filter words -
            if (filterName === "all") {
                showAll = true;
            }

            //For each filterable item -
            $.each($filteredContainerItems, function () {

                //Remove the animation class to stop odd animations on filter -
                //$(this).removeClass("js-animate-on-scroll").removeClass("fadeInUp").removeAttr("style");

                $(this).attr("data-wow-delay", "");

                //If "all" selected, show them all -
                if (showAll) {
                    $(this).show();
                    $(this).addClass("filter-show-item");
                }
                else {
                    //Otherwise, check if their filter data matches the selected filter -
                    var show = ($(this).data(_settings.filterDataName) === filterName);

                    if (show) {
                        $(this).show();
                        $(this).addClass("filter-show-item");
                        count++;
                    }
                    else {
                        $(this).hide();
                    }
                }
            });

            if (!showAll) {

                $filterCount.html(count);
                $filterString.html(filterName);
                $filterDetails.fadeTo("fast", 1);
            }

            //Fade the conatiner back in -
            $filteredContainer.fadeTo("fast", 1);

            //Set the match heights -
            _matchHeightsOfFilteredItems();

        });
    }

    function _matchHeightsOfFilteredItems() {

        $(".filter-show-item .js-filter-match-height").matchHeight();
        $(".filter-show-item .js-filter-match-height--2").matchHeight();

        AnimationDelayModule.init($(".filter-show-item"));

        //init wow js  - only for larger screens -
        var wow;
        if (Modernizr.mq("(min-width : 770px)")) {
            wow = new WOW({
                boxClass: "js-animate-on-scroll"
            });
            wow.init();
        }
    }

    //Return our public methods -
    return {
        init: init
    };
});
