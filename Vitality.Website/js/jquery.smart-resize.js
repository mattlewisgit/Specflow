// debouncing function from John Hann
// http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
function debounce(func, threshold, execAsap) {
    var timeout;

    return function debounced() {
        var obj = this, args = arguments;
        function delayed() {
            if (!execAsap)
                func.apply(obj, args);
            timeout = null;
        };

        if (timeout)
            clearTimeout(timeout);
        else if (execAsap)
            func.apply(obj, args);

        timeout = setTimeout(delayed, threshold || 100);
    };
}

// Smart scroll - debounced 
// usage $(window).smartscroll(function() { .. });
(function ($, sr) {

    jQuery.fn[sr] = function (fn) { return fn ? this.bind('scroll', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartscroll');

// Smart resize - debounced
// usage $(window).smartresize(function() { .. });
(function ($, sr) {

    // smartresize 
    jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartresize');