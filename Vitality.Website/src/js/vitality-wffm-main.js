(function($) {
    // This is a copy of the Sitecore WFFM main.js file,
    // with one important difference: the omission of jQuery no conflict mode.
    $(document).ready(function() {
        $("form[data-wffm]").each(function() {
            $(this).wffmForm();
        });
    });
})(jQuery);
