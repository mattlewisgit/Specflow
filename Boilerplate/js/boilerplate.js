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
    var markups = document.getElementsByClassName("language-markup");

    for (var i = 0; i < examples.length; ++i) {
        var example = examples[i];
        var htmlAttr = example.classList.contains("example--outer")
            ? "outerHTML" : "innerHTML";

        markups[i].innerHTML =
            htmlSpecialChars(example[htmlAttr]);
    }
})();
