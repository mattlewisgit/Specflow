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

var init = function () {
    "use strict";
    var $shareComponents = $(_settings.socialSharingLinkSelector);

    $shareComponents.on("click", function (e) {
        e.preventDefault();
        _socialShareModule.configureShareData($(this));
    });
};

module.exports = {
    init: init
};
