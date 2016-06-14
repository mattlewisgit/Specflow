define(["jquery"], function ($) {
    "use strict";

    var module = {
        isCollapsed: false,
        isExpanded: false,
        footer: null,
        footerBody: null,

        init: function () {
            module.footer = $(".quote-footer");

            if (!module.footer.length) {
                return;
            }

            module.footerBody = $(".quote-footer--body");
            module.footer.find("h6 a").click(module.toggle);
            module.adapt();
            $(window).resize(module.adapt);
        },

        adapt: function () {
            if (module.isExpanded) {
                return;
            }

            if (Modernizr.mq("(max-width: 540px)")) {
                if (!module.isCollapsed) {
                    module.isCollapsed = true;

                    module.footer.css({
                        bottom: "-" + module.footerBody.height() + "px"
                    });
                }
            } else {
                module.isCollapsed = false;
                module.footer.css({
                    bottom: "0"
                });
            }
        },

        toggle: function() {
            module.isExpanded = !module.isExpanded;
            
            if (module.isExpanded) {
                module.footer.css({ bottom: "0" });
            } else {
                module.footer.css({
                    bottom: "-" + module.footerBody.height() + "px"
                });
            }
        }
    };

    return {
        init: module.init
    };
});
