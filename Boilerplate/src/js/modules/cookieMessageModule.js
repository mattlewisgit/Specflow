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
