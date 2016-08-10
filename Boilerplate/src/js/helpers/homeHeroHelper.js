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

function fadeOut(element) {
    "use strict";
    return element && element
        .removeClass(_classes.fade.in)
        .addClass(_classes.fade.out);
}

function fadeIn(element) {
    "use strict";
    return element && element
        .removeClass(_classes.fade.out)
        .addClass(_classes.fade.in);
}

module.exports = {
    button: _classes.button,
    fade: _classes.fade,
    fadeIn: fadeIn,
    fadeOut: fadeOut
};
