define([
	"jquery",
], function(
	$
){

	// --------------------------------------------------------------------Debug
	'use strict';

	var init = function() {

		console.log("helpers init!");

		// Avoid `console` errors in browsers that lack a console.
		(function() {
			var method;
			var noop = function() {};
			var methods = [
				'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
				'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
				'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
				'timeStamp', 'trace', 'warn'
			];
			var length = methods.length;
			var console = (window.console = window.console || {});

			while (length--) {
				method = methods[length];

				// Only stub undefined methods.
				if (!console[method]) {
					console[method] = noop;
				}
			}
		}());

		// --------------------------------------------------------------------Block Heights

		// Usage $('.block').equalizeHeights();
		$.fn.equalizeHeights = function() {
			return this.height(Math.max.apply(this, $(this)
				.map(function(i, e) {
					return $(e)
						.height();
				})
				.get()));
		};
		// --------------------------------------------------------------------Form clear

		// Usage $('input[type="text"]').clrInput();

		$.fn.clrInput = function() {
			return this.focus(function() {
				if (this.value === this.defaultValue) {
					this.value = '';
				}
			}).blur(function() {
				if (!this.value.length) {
					this.value = this.defaultValue;
				}
			});
		};

		// --------------------------------------------------------------------IE 11 Check

		if (navigator.userAgent.match(/Trident.*rv:11\./)) {
			$('body').addClass('ie11');
		}
	};

	// --------------------------------------------------------------------Scroll To Element
	var scrollToElement = function(el, off, dur) {

		dur = typeof dur !== 'undefined' ? dur : 500;
		off = typeof off !== 'undefined' ? off : 0;

		// $(el).velocity('scroll', off);

		$('body').scrollTo(el, dur, {
			offset: -off,
			queue: false
		});
	};

		// --------------------------------------------------------------------Get viewport sizes
	var getViewport = function(){

		var viewPortWidth;
		var viewPortHeight;

		// the more standards compliant browsers (mozilla/netscape/opera/IE7) use window.innerWidth and window.innerHeight
		if (typeof window.innerWidth !== 'undefined') {
			viewPortWidth = window.innerWidth;
			viewPortHeight = window.innerHeight;

			// IE6 in standards compliant mode (i.e. with a valid doctype as the first line in the document)
		} else if (typeof document.documentElement !== 'undefined' && typeof document.documentElement.clientWidth !== 'undefined' && document.documentElement.clientWidth !== 0) {
			viewPortWidth = document.documentElement.clientWidth;
			viewPortHeight = document.documentElement.clientHeight;

			// older versions of IE
		} else {
			viewPortWidth = document.getElementsByTagName('body')[0].clientWidth;
			viewPortHeight = document.getElementsByTagName('body')[0].clientHeight;
		}

		return [viewPortWidth, viewPortHeight];
	};

	//Return our public methods -

	return {
		"init":init,
		"scrollToElement":scrollToElement,
		"getViewport":getViewport
	};

});