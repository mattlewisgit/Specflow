/// <reference path="../node_modules/@types/jquery/index.d.ts" />
var Vitality;
(function (Vitality) {
    var Quote;
    (function (Quote) {
        var ChatWindowPlugin = (function () {
            function ChatWindowPlugin() {
            }
            ChatWindowPlugin.prototype.Register = function () {
                $("*[data-opens-chat-window]")
                    .click(function () { return $(".chat-window").toggleClass("chat-window__hidden"); });
                return this;
            };
            return ChatWindowPlugin;
        }());
        Quote.ChatWindowPlugin = ChatWindowPlugin;
    })(Quote = Vitality.Quote || (Vitality.Quote = {}));
})(Vitality || (Vitality = {}));
/// <reference path="../node_modules/@types/jquery/index.d.ts" />
var Vitality;
(function (Vitality) {
    var Quote;
    (function (Quote) {
        var SwitchImagePlugin = (function () {
            function SwitchImagePlugin() {
            }
            SwitchImagePlugin.prototype.Register = function () {
                $("img[data-" + SwitchImagePlugin._dataKey + "]").click(function (e) {
                    var $element = $(e.target);
                    var currentImage = $element.attr("src");
                    $element.attr("src", $element.data(SwitchImagePlugin._dataKey));
                    $element.data(SwitchImagePlugin._dataKey, currentImage);
                });
                return this;
            };
            SwitchImagePlugin._dataKey = "switch-on-click";
            return SwitchImagePlugin;
        }());
        Quote.SwitchImagePlugin = SwitchImagePlugin;
    })(Quote = Vitality.Quote || (Vitality.Quote = {}));
})(Vitality || (Vitality = {}));
/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/qtip2/index.d.ts" />
var Vitality;
(function (Vitality) {
    var Quote;
    (function (Quote) {
        var ToolTipPlugin = (function () {
            function ToolTipPlugin() {
            }
            ToolTipPlugin.prototype.Register = function () {
                $(".tooltip--link").each(function (i, el) {
                    var $el = $(el);
                    var $content = $el.next(".tooltip--content");
                    var isTooltipLeft = $el.hasClass("tooltip--link__left");
                    $el.qtip({
                        content: {
                            text: $content.html()
                        },
                        hide: {
                            event: "unfocus"
                        },
                        position: {
                            adjust: {
                                x: isTooltipLeft ? -ToolTipPlugin._adjustX : ToolTipPlugin._adjustX
                            },
                            at: (isTooltipLeft ? "left" : "right") + " center",
                            my: (isTooltipLeft ? "right" : "left") + " center",
                        },
                        show: {
                            event: "click"
                        },
                        style: {
                            tip: {
                                corner: (isTooltipLeft ? "right" : "left") + " center",
                                mimic: "center",
                                width: 8
                            }
                        },
                        suppress: true
                    });
                    $content.remove();
                });
                return this;
            };
            ToolTipPlugin._adjustX = 25;
            return ToolTipPlugin;
        }());
        Quote.ToolTipPlugin = ToolTipPlugin;
    })(Quote = Vitality.Quote || (Vitality.Quote = {}));
})(Vitality || (Vitality = {}));
/// <reference path="../node_modules/@types/jquery/index.d.ts" />
$(document).ready(function () {
    [
        new Vitality.Quote.ChatWindowPlugin(),
        new Vitality.Quote.SwitchImagePlugin(),
        new Vitality.Quote.ToolTipPlugin()
    ].forEach(function (p) { return p.Register(); });
});

//# sourceMappingURL=data:application/json;charset=utf8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIl90eXBlc2NyaXB0L0NoYXRXaW5kb3dQbHVnaW4udHMiLCJfdHlwZXNjcmlwdC9Td2l0Y2hJbWFnZVBsdWdpbi50cyIsIl90eXBlc2NyaXB0L1Rvb2xUaXBQbHVnaW4udHMiLCJfdHlwZXNjcmlwdC92aXRhbGl0eS1xdW90ZS1ib2lsZXJwbGF0ZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQSxpRUFBaUU7QUFFakUsSUFBTyxRQUFRLENBU2Q7QUFURCxXQUFPLFFBQVE7SUFBQyxJQUFBLEtBQUssQ0FTcEI7SUFUZSxXQUFBLEtBQUs7UUFDakI7WUFBQTtZQU9BLENBQUM7WUFOVSxtQ0FBUSxHQUFmO2dCQUNJLENBQUMsQ0FBQywyQkFBMkIsQ0FBQztxQkFDekIsS0FBSyxDQUFDLGNBQU0sT0FBQSxDQUFDLENBQUMsY0FBYyxDQUFDLENBQUMsV0FBVyxDQUFDLHFCQUFxQixDQUFDLEVBQXBELENBQW9ELENBQUMsQ0FBQztnQkFFdkUsTUFBTSxDQUFDLElBQUksQ0FBQztZQUNoQixDQUFDO1lBQ0wsdUJBQUM7UUFBRCxDQVBBLEFBT0MsSUFBQTtRQVBZLHNCQUFnQixtQkFPNUIsQ0FBQTtJQUNMLENBQUMsRUFUZSxLQUFLLEdBQUwsY0FBSyxLQUFMLGNBQUssUUFTcEI7QUFBRCxDQUFDLEVBVE0sUUFBUSxLQUFSLFFBQVEsUUFTZDtBQ1hELGlFQUFpRTtBQUVqRSxJQUFPLFFBQVEsQ0FlZDtBQWZELFdBQU8sUUFBUTtJQUFDLElBQUEsS0FBSyxDQWVwQjtJQWZlLFdBQUEsS0FBSztRQUNqQjtZQUFBO1lBYUEsQ0FBQztZQVZVLG9DQUFRLEdBQWY7Z0JBQ0ksQ0FBQyxDQUFDLGNBQVksaUJBQWlCLENBQUMsUUFBUSxNQUFHLENBQUMsQ0FBQyxLQUFLLENBQUMsVUFBQyxDQUFDO29CQUNqRCxJQUFNLFFBQVEsR0FBRyxDQUFDLENBQUMsQ0FBQyxDQUFDLE1BQU0sQ0FBQyxDQUFDO29CQUM3QixJQUFNLFlBQVksR0FBVyxRQUFRLENBQUMsSUFBSSxD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QUNyQyxDQUFDLE9BQU8sQ0FBQyxVQUFDLENBQUMsSUFBSyxPQUFBLENBQUMsQ0FBQyxRQUFRLEVBQUUsRUFBWixDQUFZLENBQUMsQ0FBQztBQUNuQyxDQUFDLENBQUMsQ0FBQyIsImZpbGUiOiJ2aXRhbGl0eS1xdW90ZS1ib2lsZXJwbGF0ZS5qcyIsInNvdXJjZXNDb250ZW50IjpbIi8vLyA8cmVmZXJlbmNlIHBhdGg9XCIuLi9ub2RlX21vZHVsZXMvQHR5cGVzL2pxdWVyeS9pbmRleC5kLnRzXCIgLz5cclxuXHJcbm1vZHVsZSBWaXRhbGl0eS5RdW90ZSB7XHJcbiAgICBleHBvcnQgY2xhc3MgQ2hhdFdpbmRvd1BsdWdpbiBpbXBsZW1lbnRzIFZpdGFsaXR5LlF1b3RlLklQbHVnaW4ge1xyXG4gICAgICAgIHB1YmxpYyBSZWdpc3RlciAoKSA6IFZpdGFsaXR5LlF1b3RlLklQbHVnaW4ge1xyXG4gICAgICAgICAgICAkKFwiKltkYXRhLW9wZW5zLWNoYXQtd2luZG93XVwiKVxyXG4gICAgICAgICAgICAgICAgLmNsaWNrKCgpID0+ICQoXCIuY2hhdC13aW5kb3dcIikudG9nZ2xlQ2xhc3MoXCJjaGF0LXdpbmRvd19faGlkZGVuXCIpKTtcclxuXHJcbiAgICAgICAgICAgIHJldHVybiB0aGlzO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxufVxyXG4iLCIvLy8gPHJlZmVyZW5jZSBwYXRoPVwiLi4vbm9kZV9tb2R1bGVzL0B0eXBlcy9qcXVlcnkvaW5kZXguZC50c1wiIC8+XHJcblxyXG5tb2R1bGUgVml0YWxpdHkuUXVvdGUge1xyXG4gICAgZXhwb3J0IGNsYXNzIFN3aXRjaEltYWdlUGx1Z2luIGltcGxlbWVudHMgVml0YWxpdHkuUXVvdGUuSVBsdWdpbiB7XHJcbiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgcmVhZG9ubHkgX2RhdGFLZXk6IHN0cmluZyA9IFwic3dpdGNoLW9uLWNsaWNrXCI7XHJcblxyXG4gICAgICAgIHB1YmxpYyBSZWdpc3RlciAoKSA6IFZpdGFsaXR5LlF1b3RlLklQbHVnaW4ge1xyXG4gICAgICAgICAgICAkKGBpbWdbZGF0YS0ke1N3aXRjaEltYWdlUGx1Z2luLl9kYXRhS2V5fV1gKS5jbGljaygoZSkgPT4ge1xyXG4gICAgICAgICAgICAgICAgY29uc3QgJGVsZW1lbnQgPSAkKGUudGFyZ2V0KTtcclxuICAgICAgICAgICAgICAgIGNvbnN0IGN1cnJlbnRJbWFnZTogc3RyaW5nID0gJGVsZW1lbnQuYXR0cihcInNyY1wiKTtcclxuICAgICAgICAgICAgICAgICRlbGVtZW50LmF0dHIoXCJzcmNcIiwgJGVsZW1lbnQuZGF0YShTd2l0Y2hJbWFnZVBsdWdpbi5fZGF0YUtleSkpO1xyXG4gICAgICAgICAgICAgICAgJGVsZW1lbnQuZGF0YShTd2l0Y2hJbWFnZVBsdWdpbi5fZGF0YUtleSwgY3VycmVudEltYWdlKTtcclxuICAgICAgICAgICAgfSk7XHJcblxyXG4gICAgICAgICAgICByZXR1cm4gdGhpcztcclxuICAgICAgICB9XHJcbiAgICB9XHJcbn1cclxuIiwiLy8vIDxyZWZlcmVuY2UgcGF0aD1cIi4uL25vZGVfbW9kdWxlcy9AdHlwZXMvanF1ZXJ5L2luZGV4LmQudHNcIiAvPlxyXG4vLy8gPHJlZmVyZW5jZSBwYXRoPVwiLi4vbm9kZV9tb2R1bGVzL0B0eXBlcy9xdGlwMi9pbmRleC5kLnRzXCIgLz5cclxuXHJcbm1vZHVsZSBWaXRhbGl0eS5RdW90ZSB7XHJcbiAgICBleHBvcnQgY2xhc3MgVG9vbFRpcFBsdWdpbiBpbXBsZW1lbnRzIFZpdGFsaXR5LlF1b3RlLklQbHVnaW4ge1xyXG4gICAgICAgIHByaXZhdGUgc3RhdGljIHJlYWRvbmx5IF9hZGp1c3RYOm51bWJlciA9IDI1O1xyXG5cclxuICAgICAgICBwdWJsaWMgUmVnaXN0ZXIgKCkgOiBWaXRhbGl0eS5RdW90ZS5JUGx1Z2luIHtcclxuICAgICAgICAgICAgJChcIi50b29sdGlwLS1saW5rXCIpLmVhY2goKGksIGVsKSA9PiB7XHJcbiAgICAgICAgICAgICAgICBjb25zdCAkZWwgPSAkKGVsKTtcclxuICAgICAgICAgICAgICAgIGNvbnN0ICRjb250ZW50ID0gJGVsLm5leHQoXCIudG9vbHRpcC0tY29udGVudFwiKTtcclxuICAgICAgICAgICAgICAgIGNvbnN0IGlzVG9vbHRpcExlZnQ6Ym9vbGVhbiA9ICRlbC5oYXNDbGFzcyhcInRvb2x0aXAtLWxpbmtfX2xlZnRcIik7XHJcblxyXG4gICAgICAgICAgICAgICAgJGVsLnF0aXAoe1xyXG4gICAgICAgICAgICAgICAgICAgIGNvbnRlbnQ6IHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgdGV4dDogJGNvbnRlbnQuaHRtbCgpXHJcbiAgICAgICAgICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgICAgICAgICBoaWRlOiB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGV2ZW50OiBcInVuZm9jdXNcIlxyXG4gICAgICAgICAgICAgICAgICAgIH0sXHJcbiAgICAgICAgICAgICAgICAgICAgcG9zaXRpb246IHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgYWRqdXN0OiB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB4OiBpc1Rvb2x0aXBMZWZ0ID8gLVRvb2xUaXBQbHVnaW4uX2FkanVzdFggOiBUb29sVGlwUGx1Z2luLl9hZGp1c3RYXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIH0sXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGF0OiAoaXNUb29sdGlwTGVmdCA/IFwibGVmdFwiIDogXCJyaWdodFwiKSArIFwiIGNlbnRlclwiLFxyXG4gICAgICAgICAgICAgICAgICAgICAgICBteTogKGlzVG9vbHRpcExlZnQgPyBcInJpZ2h0XCIgOiBcImxlZnRcIikgKyBcIiBjZW50ZXJcIixcclxuICAgICAgICAgICAgICAgICAgICB9LFxyXG4gICAgICAgICAgICAgICAgICAgIHNob3c6IHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgZXZlbnQ6IFwiY2xpY2tcIlxyXG4gICAgICAgICAgICAgICAgICAgIH0sXHJcbiAgICAgICAgICAgICAgICAgICAgc3R5bGU6IHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgdGlwOiB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBjb3JuZXI6IChpc1Rvb2x0aXBMZWZ0ID8gXCJyaWdodFwiIDogXCJsZWZ0XCIpICsgXCIgY2VudGVyXCIsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBtaW1pYzogXCJjZW50ZXJcIixcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIHdpZHRoOiA4XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgICAgICB9LFxyXG4gICAgICAgICAgICAgICAgICAgIHN1cHByZXNzOiB0cnVlXHJcbiAgICAgICAgICAgICAgICB9KTtcclxuXHJcbiAgICAgICAgICAgICAgICAkY29udGVudC5yZW1vdmUoKTtcclxuICAgICAgICAgICAgfSk7XHJcblxyXG4gICAgICAgICAgICByZXR1cm4gdGhpcztcclxuICAgICAgICB9XHJcbiAgICB9XHJcbn1cclxuIiwiLy8vIDxyZWZlcmVuY2UgcGF0aD1cIi4uL25vZGVfbW9kdWxlcy9AdHlwZXMvanF1ZXJ5L2luZGV4LmQudHNcIiAvPlxyXG5cclxuJChkb2N1bWVudCkucmVhZHkoKCkgPT4ge1xyXG4gICAgW1xyXG4gICAgICAgIG5ldyBWaXRhbGl0eS5RdW90ZS5DaGF0V2luZG93UGx1Z2luKCksXHJcbiAgICAgICAgbmV3IFZpdGFsaXR5LlF1b3RlLlN3aXRjaEltYWdlUGx1Z2luKCksXHJcbiAgICAgICAgbmV3IFZpdGFsaXR5LlF1b3RlLlRvb2xUaXBQbHVnaW4oKVxyXG4gICAgXS5mb3JFYWNoKChwKSA9PiBwLlJlZ2lzdGVyKCkpO1xyXG59KTtcclxuIl19
