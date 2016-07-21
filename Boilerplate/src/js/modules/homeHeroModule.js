var YouTubeAPIBaseConfig = require("../config/youtube-api-base-config.json");

function _enhanceHero(i, el) {
    "use strict";
    // Replace the container with a plyeyr iframe,
    // using the video data attribute as the ID.
    var hero = $(el);
    var overlay = hero.find(".home-hero--static");

    var paragraph = hero.find("p");
    var backgroundImage = overlay.css("background-image");
    var header = hero.find(".header");
    var playButton = hero.find(".home-hero--static__play");
    var videoContainer = hero.find(".youtube-video");

    var videoId = videoContainer.data("youtube-id");

    new YT.Player(videoContainer[0], {
        playerVars: YouTubeAPIBaseConfig,
        videoId: videoId,
        width: "100%",

        events: {
            // Remove the video container and play button on fail.
            onError: function() {
                hero.find(".video--responsive").remove();
                playButton.remove();
            },

            onReady: function(e) {
                playButton.click(function() {
                    e.target.playVideo();
                    header.addClass("animated fadeOut");
                    paragraph.addClass("animated fadeOut");
                    playButton.addClass("animated fadeOut");

                    setTimeout(function() {
                        overlay.css("background-image", "none");

                        overlay.click(function() {
                            overlay.css("background-image", backgroundImage);
                            header.removeClass("fadeOut").addClass("fadeIn");
                            paragraph.removeClass("fadeOut").addClass("fadeIn");
                            playButton.removeClass("fadeOut").addClass("fadeIn");
                            overlay.unbind("click");
                            e.target.pauseVideo();
                        });
                    }, 500);
                });
            }
        }
    });
}

function init() {
    "use strict";
    var heroes = $(".home-hero--video");

    // Bonb out if no videos heroes are present.
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
    init: init
};
