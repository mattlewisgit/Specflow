var YouTubeAPIBaseConfig = require("../config/youtube-api-base-config.json");
var YouTubePlayerAPI = require("../api/youtube-player-api");

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

var _timeoutDuration = 1000;

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

    fadedElements.forEach(function(element) {
        element.addClass("animated");
    });

    function __play(player) {
        player.playVideo();
        fadedElements.forEach(_fadeOut);

        setTimeout(function() {
            overlay.css("background-image", "none");

            overlay.hover(
                // Hover in.
                function() {
                    _fadeIn(button)
                        .removeClass(_classes.button.play)
                        .addClass(_classes.button.pause);
                },
                // Hover out.
                function() {
                    // Fade out the pause button.
                    _fadeOut(button);

                    // Convert back to a play button after animation.
                    setTimeout(function() {
                        button
                            .removeClass(_classes.button.pause)
                            .addClass(_classes.button.play);
                    }, _timeoutDuration);
                });
        }, _timeoutDuration);
    }

    function __pause(player) {
        _fadeIn(button)
            .removeClass(_classes.button.pause)
            .addClass(_classes.button.play);

        fadedElements.forEach(_fadeIn);
        player.pauseVideo();
        overlay.css("background-image", backgroundImage);
    }

    new YT.Player(videoContainer[0], {
        playerVars: YouTubeAPIBaseConfig,
        videoId: videoId,
        width: "100%",

        events: {
            // Remove the video container and button on fail.
            onError: function() {
                // An error here is likely to due to a prolem with the requested video itself.
                // For example, the original video ID was 1ER-hNTUVz4, which was made private,
                // and resulted in unhelpful, unrelated errors such as:
                // "Failed to execute 'postMessage' on 'DOMWindow': target/origin mismatch".
                hero.find(".video--responsive").remove();
                button.remove();
            },

            onReady: function(e) {
                var player = e.target;

                overlay.click(function() {
                    // If the video is playing, pause it,
                    // otherwise always try to play it.
                    switch(player.getPlayerState()) {
                        case YouTubePlayerAPI.playerStates.playing:
                            __pause(player);
                            break;
                        default:
                            __play(player);
                            break;
                    }
                });
            }
        }
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
    window.onYouTubePlayerAPIReady = function() {
        heroes.each(_enhanceHero);
    };
}

module.exports = {
    init: _init
};
