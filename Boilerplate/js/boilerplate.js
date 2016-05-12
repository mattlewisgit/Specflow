(function() {
    function htmlSpecialChars(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&apos;");
    }

    var examples = document.getElementsByClassName("example");
    var markups = document.getElementsByTagName("code");

    for (var i = 0; i < examples.length; ++i) {
        markups[i].innerHTML =
            htmlSpecialChars("    " + examples[i].innerHTML);
    }
})();
