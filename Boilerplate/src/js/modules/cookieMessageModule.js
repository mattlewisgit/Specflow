var _container = null;
var _cta = null;

function init() {
    "use strict";
    // Find the elements or bomb out if they are not present.
    _container = $(".cookie-message");

    if (_container.length < 1) {
        return;
    }

    _cta = _container.find(".box-button");

    // TODO Determine whether to continue based on a cookie.
    _container.show();

    // Hide and set the cookie on close.
    _cta.click(function() {
        _container
            .removeClass("slideInDown")
            .addClass("slideOutUp");

        setTimeout(function () {
            // TODO Set the cookie.
            _container.hide();
        }, 500);

        return false;
    });
}

module.exports = {
    init: init
};
