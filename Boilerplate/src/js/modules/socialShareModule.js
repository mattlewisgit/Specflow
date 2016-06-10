define([
    "jquery"
], function (
    $
) {
    "use strict";

    //vars -
    var _settings = {
        socialSharingLinkSelector: ".js-sharing-links"
    };

    //functions -
    var _socialShareModule = {
        configureShareData: function ($anchor) {

            var socialChannel = $anchor.data("type");
            //var shareTitle = encodeURIComponent($anchor.data("title"));
            //var shareDescription = encodeURIComponent($anchor.data("description"));
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
            }
        }
    };


    /**
     *  initialiser
     */
    var init = function () {
        var $shareComponents = $(_settings.socialSharingLinkSelector);

        $shareComponents.on("click", function (e) {
            e.preventDefault();
            _socialShareModule.configureShareData($(this));
        });
    };

    //Return our public methods -
    return {
        "init": init
    };
});
