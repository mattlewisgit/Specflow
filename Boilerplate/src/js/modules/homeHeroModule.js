// jscs:disable maximumNumberOfLines
var YouTubeAPIBaseConfig = require("../config/youtube-api-base-config.json");

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

var _timeoutDuration = 750;

function _fadeOut(element) {
    "use strict";
    return element && element
        .removeClass(_classes.fade.in)
        .addClass(_classes.fade.out);
}

function _fadeIn(element) {
    "use strict";
    return element && element
        .removeClass(_classes.fade.out)
        .addClass(_classes.fade.in);
}

function _enhanceHero(i, el) {
    "use strict";

    // State.
    // Replace the container with a player iframe,
    // using the video data attribute as the ID.
    var hero = $(el);

    var overlay = hero.find(".home-hero--static");
    var backgroundImage = overlay.css("background-image");

    var paragraph = hero.find("p");
    var header = hero.find(".header");
    var button = hero.find(".home-hero--static__button");
    var videoContainer = hero.find(".youtube-video");

    var videoId = videoContainer.data("youtube-id");

    // Set the element to always animate.
    var fadedElements = [header, paragraph, button];

    fadedElements.forEach(function (element) {
        element.addClass("animated");
    });

    var player = null;
    // IPhone plays the video in its own player
    var isIPhone = !!navigator.userAgent.match(/(iPhone)|(iPod)/i);
    // Android and iPad plays inside the browser, therefore treated differently
    var isAndroidAndIpad = !!navigator.userAgent.match(/(iPad)|(Android)/i);

    var previousStatus = null;

    // Functions.
    function __hoverIn() {
        // Only fade in if we are currently playing.
        if (player.getPlayerState() !== YT.PlayerState.PLAYING) {
            return;
        }

        _fadeIn(button);
    }

    function __hoverOut() {
        // Only fade out if we are currently playing.
        if (player.getPlayerState() !== YT.PlayerState.PLAYING) {
            return;
        }

        _fadeOut(button);
    }

    function __play() {
        fadedElements.forEach(_fadeOut);

        // Wait for the element to fade out.
        setTimeout(function () {
            button
                .removeClass(_classes.button.play)
                .addClass(_classes.button.pause);

            if (!(isIPhone || isAndroidAndIpad)) {
                // Play now to pick up from where we left off.
                player.playVideo();
            }

            overlay
                .css("background-image", "none")
                .hover(__hoverIn, __hoverOut);
        }, _timeoutDuration);
    }

    function __pause() {
        button
            .removeClass(_classes.button.pause)
            .addClass(_classes.button.play);

        fadedElements.forEach(_fadeIn);

        if (!(isIPhone || isAndroidAndIpad)) {
            player.pauseVideo();
        }

        overlay.css("background-image", backgroundImage);
    }

    function __changePlayerState(e) {
        // If it is Android and iPad, getPlayerState() returns the state after the click event.
        previousStatus = isAndroidAndIpad ? previousStatus : player.getPlayerState();
        // If the video is playing, pause it,
        // otherwise always try to play it.
        // When playing after paused on iOS, preventDefault has to be called
        // to get background image back on display
        switch (previousStatus) {
            case YT.PlayerState.PLAYING:
                __pause(player);
                break;
            case YT.PlayerState.UNSTARTED:
                __play(player);
                break;
            default:
                // If preventDefault is not called for iPhone
                // it displays the overlay and get rid of it soon after
                if (isIPhone) {
                    e.preventDefault();
                }

                __play(player);
                break;
        }
        previousStatus = player.getPlayerState();
    }

    // Create the player!
    player = new YT.Player(videoContainer[0], {
        events: {
            // Remove the video container and button on fail.
            onError: function () {
                // An error here is likely to due to a prolem with the requested video itself.
                // For example, the original video ID was 1ER-hNTUVz4, which was made private,
                // and resulted in unhelpful, unrelated errors such as:
                // "Failed to execute 'postMessage' on 'DOMWindow': target/origin mismatch".
                hero.find(".video--responsive").remove();
                button.remove();
            },

            onReady: function () {
                // Disable overlay click events for mobile environment
                // Can't do this for normal browsers due to pausing delay
                // And pause button not displaying while playing
                if (isIPhone || isAndroidAndIpad) {
                    overlay.css("pointer-events", "none");
                    player.addEventListener("onStateChange", __changePlayerState);
                } else {
                    // Use .mute() now in the future if sound should be disabled.
                    overlay.click(__changePlayerState);
                }
            }
        },

        playerVars: YouTubeAPIBaseConfig,
        videoId: videoId,
        width: "100%"
    });
}

function _init() {
    "use strict";
    var heroes = $(".home-hero--video");

    // Bomb out if no video heroes are present.
    if (heroes.length < 1) {
        return;
    }

    // Load the IFrame Player API asynchronously.
    $("script")
        .first()
        .before($("<script>").attr("src", "//www.youtube.com/player_api"));

    // Register a global function called by YouTube.
    window.onYouTubePlayerAPIReady = function () {
        heroes.each(_enhanceHero);
    };
}

module.exports = {
    init: _init
};
