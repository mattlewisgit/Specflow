define([
	"jquery"
], function(
	$
){

	'use strict';

	//vars -
	var _settings = {
		searchInputClass: ".js-search-input",
		searchStringOutput:".js-search-string",
		searchMatchesOutput:".js-search-matches",

	};

	var $searchInput;
	var $searchOutput;
	var $searchMatches;

	//funcitons -

	var _searchModule = {
		init:function(){

			console.log("init search module!");

			$searchInput.on('input', function() {
				var searchString = $(this).val();
				$searchOutput.html(searchString);
				var m = Math.round(Math.random()*10);
				$searchMatches.html(m);


				$(".search-panel__search-results").show();
				$(".search-panel__search-details").show();

			});

			//Prevent scrolling of the large input text -
			$searchInput.on('mousewheel DOMMouseScroll',function(e){
        e.stopPropagation();
			  e.preventDefault();
			  return false;
    	});
		}
	};


	/**
   *  initialiser
   */
  var init = function () {
  	$searchInput = $(_settings.searchInputClass);
		$searchOutput = $(_settings.searchStringOutput);
		$searchMatches = $(_settings.searchMatchesOutput);

  	_searchModule.init();
  };

	//Return our public methods -
	return {
		"init":init
	};

});