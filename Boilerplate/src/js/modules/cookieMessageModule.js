var _container = null;
var _cookieKey = "hasReadCookieMessage";
var _areCookiesDisabled = false;

function init() {
    "use strict";
    // Bomb out if there is no cookie container, or the cookie is set.
    _container = $(".cookie-message");
    _areCookiesDisabled = $("html").hasClass("disable-cookies");

    if (_container.length < 1 || (!_areCookiesDisabled && !!Cookies.get(_cookieKey))) {
        return;
    }

    // Show the message and set the cookie.
    _container.show();

    if (!_areCookiesDisabled) {
        Cookies.set(_cookieKey, true, { expires: 365 });
    }

    // Slide out and hide the message on close.
    _container.find(".box-button").click(function() {
        _container
            .removeClass("slideInDown")
            .addClass("slideOutUp");

        setTimeout(function () {
            _container.hide();
        }, 500);

        return false;
    });
}

module.exports = {
    init: init
};
