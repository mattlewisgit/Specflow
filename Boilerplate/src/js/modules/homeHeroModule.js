var YouTubeAPIBaseConfig = require("../config/youtube-api-base-config.json");
var YouTubePlayerAPI = require("../api/youtube-player-api");
var HomeHeroHelper = require("../helpers/homeHeroHelper");

var _timeoutDuration = 750;

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
    var isIPhone = navigator.userAgent.match(/(iPhone)|(iPod)/i) !== null;
    var isAndroidAndIpad = navigator.userAgent.match(/(iPad)|(Android)/i) !== null;

    var previousStatus = null;

    // Functions.
    function __hoverIn() {
        // Only fade in if we are currently playing.
        if (player.getPlayerState() !== YouTubePlayerAPI.playerStates.playing) {
            return;
        }

        HomeHeroHelper.fadeIn(button);
    }

    function __hoverOut() {
        // Only fade out if we are currently playing.
        if (player.getPlayerState() !== YouTubePlayerAPI.playerStates.playing) {
            return;
        }

        HomeHeroHelper.fadeOut(button);
    }

    function __play() {
        fadedElements.forEach(HomeHeroHelper.fadeOut);

        // Wait for the element to fade out.
        setTimeout(function () {
            button
                .removeClass(HomeHeroHelper.button.play)
                .addClass(HomeHeroHelper.button.pause);

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
            .removeClass(HomeHeroHelper.button.pause)
            .addClass(HomeHeroHelper.button.play);

        fadedElements.forEach(HomeHeroHelper.fadeIn);

        if (!(isIPhone || isAndroidAndIpad)) {
            player.pauseVideo();
        }

        overlay.css("background-image", backgroundImage);
    }

    function __changePlayerState(e) {
        // If it is Android, getPlayerState() returns the state after the click event.
        previousStatus = isAndroidAndIpad ? previousStatus : player.getPlayerState();
        // If the video is playing, pause it,
        // otherwise always try to play it.
        // When playing after paused on iOS, preventDefault has to be called
        // to get background image back on display
        switch (previousStatus) {
            case YouTubePlayerAPI.playerStates.playing:
                __pause(player);
                break;
            case YouTubePlayerAPI.playerStates.unstarted:
                __play(player);
                break;
            default:
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
                // Disable overlay click events on iOs and Android
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
