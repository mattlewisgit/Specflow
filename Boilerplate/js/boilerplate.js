(function() {
    function htmlSpecialChars(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&apos;");
    }

    var examples = $(".example");
    var markups = $(".language-markup");

    for (var i = 0; i < examples.length; ++i) {
        var example = examples[i];
        var htmlAttr = example.className.indexOf("example--outer") > -1
            ? "outerHTML" : "innerHTML";

        markups[i].innerHTML =
            htmlSpecialChars(example[htmlAttr]);
    }
})();
