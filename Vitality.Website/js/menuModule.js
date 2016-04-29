define([
	"jquery",
], function(
	$
){

	'use strict';

	//vars -

	var $megaMenuItems;

	var $body, $html;

	var _settings = {
		megaMenuClass:".section-nav__item--megamenu",

		mainMenuToggleSelector: "js-main-menu-toggle",
		logInToggleSelector : "js-log-in-toggle",
		searchToggleSelector : "js-search-toggle",

		mobileMainMenuClass : "mainmenu-open",

		logInClass : "log-in-open",

		searchClass: "search-open",
		searchOverflowClass : "search-overflow",
		searchCloseClass: "js-search-close",

		mobileMegaMenuClass : "megamenu-open",
		mobileMegaMenuOverflowClass : "megamenu-overflow",


		focusClass : "js-focus",
		breakpoint: '769px'
	};

	//functions -

	var _menuModule = {

		initMobileMenu:function() {
			console.log("_initMobileMenu");
			//Set up toggle click etc on mobile -
		},

		initMainMobile : function() {
			console.log("_initMainMobile");
			//Tab index helpers - megamenu accessibility
			$megaMenuItems = $(_settings.megaMenuClass);

			//Tab focus megamenu fix -
			$body.on("keydown", function(e){
				//If tab pressed -
				if(e.keyCode===9){
					 setTimeout(function () {
						_menuModule.onTabCheckMegamenuFocus();
						_menuModule.onTabCheckLoginFocus();
					},0.25);
				}
			});

			//Main menu toggle for mobile -
			$("."+_settings.mainMenuToggleSelector).on("click", _menuModule.onMobileMenuButtonPressed);

			//Menu toggle for log in pop - up -
			$("."+_settings.logInToggleSelector).on("click", _menuModule.onLogInButtonPressed);

			//Menu toggle for search -
			$("."+_settings.searchToggleSelector).on("click", _menuModule.onSearchButtonPressed);

			//Search close button -
			$("."+_settings.searchCloseClass).on("click", _menuModule.closeSearchMenu);


			//Temp =
			$(".log-in").on("click",function(e){e.stopPropagation();});

			//Megamenu toggle for mobile -
			$megaMenuItems.on("click", _menuModule.onMobileMegaMenuSelect);

			//Megamenu toggle focus for opening on click of heading rather than hover -
			$megaMenuItems.on("click", _menuModule.onMegaMenuOpenTouchLarge);



		},

		//Megamenu touch events - for large sceen layouts, but with no mouse eg. iPads -

		onMegaMenuOpenTouchLarge:function(e){

			if(Modernizr.mq("(min-width : "+_settings.breakpoint+")") && Modernizr.touchevents){


				event.stopPropagation();

				//If this menu already has focus, follow the link to the overview landing page -
				if(!$(this).hasClass(_settings.focusClass)){

					//prevent the clickthrough to the overview landing page -
					e.preventDefault();

					//Otherwise, Remove focus from any other megamenus -
					$("."+_settings.focusClass).removeClass(_settings.focusClass);

					//Open this megamenu -
					$(this).addClass(_settings.focusClass);

					//Add listener for clicking anything other than the megamenu, to close it again -
					$html.on("click", _menuModule.onTouchOutsideOpenMegaMenu);

				}
			}
		},

		//Slight delay before removing the overflow visible class from the mobile mega menu
		//Prevents the megamenu being clipped before the transform is complete
		delayRemoveMegaMenuOverflowClass:function(delay){
			var _delay =  delay ? delay : 0;

			setTimeout(function() {
			    $body.removeClass(_settings.mobileMegaMenuOverflowClass);
			}, _delay);

		},

		onTouchOutsideOpenMegaMenu:function(){
			$("."+_settings.focusClass).removeClass(_settings.focusClass);
			//Remove listener for clicking anything other than the megamenu, to close it again -
			$html.off("click", _menuModule.onTouchOutsideOpenMegaMenu);
		},


		//Tab button focus megamenu for accessibility -

		onTabCheckMegamenuFocus:function(){
			var count = 0;

			//For each mega menu item -
			$.each($megaMenuItems,function(){

				var mmItem = $(this);
				//Check if  a child element has focus -
				var hasFocus = (mmItem.find(':focus').length > 0);

				//And conditionally add or remove the class -
				if(hasFocus){
					mmItem.addClass(_settings.focusClass);
					count++;
				}
				else{
					mmItem.removeClass(_settings.focusClass);
				}

			});

			if(count===0){
				$body.removeClass(_settings.mobileMegaMenuClass);
				_menuModule.delayRemoveMegaMenuOverflowClass();
			}
			else{
				$body.addClass(_settings.mobileMegaMenuClass);
				$body.addClass(_settings.mobileMegaMenuOverflowClass);

			}
		},

		//Tab buttons for Log In Menu =
		onTabCheckLoginFocus:function(){

			var loginIcon = $("."+_settings.logInToggleSelector);
			//Check if  a child element has focus -
			var hasFocus = (loginIcon.find(':focus').length > 0);

			//And conditionally add or remove the class -
			if(hasFocus){
				loginIcon.addClass(_settings.focusClass);
				$body.addClass(_settings.logInClass);
			}
			else{
				loginIcon.removeClass(_settings.focusClass);
				$body.removeClass(_settings.logInClass);
			}
		},

		//The mobile toggle menu button -

		onMobileMenuButtonPressed:function(e){

			if(e){
				e.preventDefault();
				e.stopPropagation();
			}

			if($body.hasClass(_settings.mobileMainMenuClass)){

				$body.removeClass(_settings.mobileMainMenuClass);
				//Remove all active sections -
				$("."+_settings.focusClass).removeClass(_settings.focusClass);

				//Remove open megamenu toggle -
				$body.removeClass(_settings.mobileMegaMenuClass);
				_menuModule.delayRemoveMegaMenuOverflowClass();

				//Add listener for clicking anything other than the megamenu, to close it again -
				//Removed this due to design request to be able to browse the site with the menu open -
				//$html.off("click", _menuModule.onTouchOutsideOpenMobileMenu);
			}
			else{
				$body.addClass(_settings.mobileMainMenuClass);

				//Close the search & login panels if open -
				_menuModule.closeSearchMenu();

				$body.removeClass(_settings.logInClass);

				//Add listener for clicking anything other than the megamenu, to close it again -
				//Removed this due to design request to be able to browse the site with the menu open -
				//$html.on("click", _menuModule.onTouchOutsideOpenMobileMenu);
			}
		},

		//Toggle the log in panel -
		onLogInButtonPressed:function(e){
			e.preventDefault();
			e.stopPropagation();

			//Close the search if open -
			_menuModule.closeSearchMenu();


			if($body.hasClass(_settings.logInClass)){
				$body.removeClass(_settings.logInClass);
			}
			else{
				$body.addClass(_settings.logInClass);

				//Close the main menu if open -
				if($body.hasClass(_settings.mobileMainMenuClass)){
					_menuModule.onMobileMenuButtonPressed();
				}
			}

		},

		onSearchButtonPressed:function(e){
			e.preventDefault();
			e.stopPropagation();

			//Close the log in panel if open -
			$body.removeClass(_settings.logInClass);

			if($body.hasClass(_settings.searchClass)){
				_menuModule.closeSearchMenu();
			}
			else{
				$body.addClass(_settings.searchClass);
				_menuModule.delaySearchNoMaxHeight(750);

				//Close the main menu if open -
				if($body.hasClass(_settings.mobileMainMenuClass)){
					_menuModule.onMobileMenuButtonPressed();
				}
			}
		},

		delaySearchNoMaxHeight:function(delay){
			var _delay =  delay ? delay : 0;

			setTimeout(function() {
			    $body.addClass(_settings.searchOverflowClass);
			}, _delay);

		},

		closeSearchMenu:function(){

			$body.removeClass(_settings.searchOverflowClass);
			var _delay = 0.2;

			setTimeout(function() {
			    $body.removeClass(_settings.searchClass);
			}, _delay);

		},

		//Mobile mega menu open / close

		onMobileMegaMenuSelect:function(e){

			if(Modernizr.mq("(max-width : "+_settings.breakpoint+")")){

				var $this = $(this);
				var $target = $(e.target);

				//If the seciton is already open -
				if($this.hasClass(_settings.focusClass)){

					//if back button -
					if(($target.hasClass("megamenu__back"))){
						e.preventDefault();
						e.stopPropagation();
						$body.removeClass(_settings.mobileMegaMenuClass);
						_menuModule.delayRemoveMegaMenuOverflowClass(500);
					}

					//Remove all active sections -
					$("."+_settings.focusClass).removeClass(_settings.focusClass);

					//otherwise, no action - follow the link :)

				}
				else{
					//Open the mega menu -
					e.preventDefault();
					e.stopPropagation();
					$body.addClass(_settings.mobileMegaMenuClass);
					$body.addClass(_settings.mobileMegaMenuOverflowClass);

					//Remove other active sections -
					$("."+_settings.focusClass).removeClass(_settings.focusClass);
					$(this).addClass(_settings.focusClass);
				}
			}

		},

		//If touch outside of the open menu on mobile - close it -
		//Unless it's a menu link to follow -

		onTouchOutsideOpenMobileMenu:function(e){

			console.log("onTouchOutsideOpenMobileMenu");

			var target = $( e.target );

			if ( !target.is( "a" ) ) {

				//trigger a click to close the menu -
				$("."+_settings.mainMenuToggleSelector).trigger("click");

				//Remove listener for clicking anything other than the megamenu, to close it again -
				$html.off("click", _menuModule.onTouchOutsideOpenMobileMenu);
			}

		}

	};

	/**
     *  initialiser
     */
    var init = function () {
    	console.log("Menu module init");

    	$body = $("body");
    	$html = $("html");

    	_menuModule.initMobileMenu();
    	_menuModule.initMainMobile();
    };

	//Return our public methods -
	return {
		"init":init
	};

});

