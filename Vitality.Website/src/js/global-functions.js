// Memoize the regex creator to reuse the regex object.
var _getURLParameterRegexCreator = _.memoize(function (name) {
    "use strict";
    return new RegExp("[?&]" + name + "=([^&]*)");
});

function getURLParameter(name, url) {
    "use strict";

    if (!name) {
        return name;
    }

    url = url || window.location.search;
    var match = _getURLParameterRegexCreator(name).exec(url);
    return match && decodeURIComponent(match[1].replace(/\+/g, " "));
}
