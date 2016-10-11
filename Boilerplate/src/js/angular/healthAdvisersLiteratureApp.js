// jscs:disable maximumNumberOfLines
var MomentApi = require("../config/moment-api.json");

var events = {
    dateFilter: "dateFilter",
    documentedSelected: "documentedSelected",
    typeSelected: "typeSelected"
};

window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersSalesLiteratureApp", ["LiteratureLibraryService"])
    .directive("typeahead", [
        "$rootScope",
        "LiteratureLibraryService",
        function ($rootScope, LiteratureLibraryService) {
            "use strict";
            return {
                link: function (scope, element) {
                    $(element)
                        .typeahead({
                            highlight: true,
                            hint: false,
                            minLength: 1
                        },
                        {
                            displayKey: "Title",
                            limit: 10,
                            name: "literature",
                            source: function (text, callback) {
                                callback(LiteratureLibraryService.searchDocuments(text));
                            },
                            templates: {
                                notFound: "<div class=\"tt-no-results\">" +
                                    "Sorry, there are no matching documents.</div>"
                            }
                        })
                        .bind("typeahead:select", function (event, document) {
                            $rootScope.$broadcast(events.documentedSelected, document);
                            $rootScope.$broadcast(events.typeSelected);
                        });
                },
                restrict: "A"
            };
        }
    ])
    .controller("DateController", [
        "$scope",
        "$rootScope",
        function ($scope, $rootScope) {
            "use strict";
            // Initialise the date model with today.
            var today = new Date();

            $scope.filterDate = {
                day: today.getDate(),
                month: today.getMonth() + 1,
                year: today.getFullYear()
            };

            $scope.filterAction = function (dateForm, filterDate) {
                // Generate a date.
                var actualDate = moment([filterDate.year, filterDate.month - 1, filterDate.day]);

                // Reset the validity.
                dateForm.$setValidity("filterDate", true);
                dateForm.day.$setValidity("day", true);
                dateForm.month.$setValidity("month", true);

                // Check for validity and show the first date error where possible.
                if (!actualDate.isValid()) {
                    switch (actualDate.invalidAt()) {
                        case MomentApi.invalidAtUnit.months:
                            dateForm.month.$setValidity("month", false);
                            return;
                        case MomentApi.invalidAtUnit.days:
                            dateForm.day.$setValidity("day", false);
                            return;
                        default:
                            dateForm.$setValidity("filterDate", false);
                            return;
                    }
                }

                // Broadcast the filter event.
                $rootScope.$broadcast(events.dateFilter, actualDate);
            };
        }
    ])
    .controller("ChooseController", [
        "$scope",
        "$rootScope",
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            LiteratureLibraryService.getCategories(function (categories) {
                $scope.types = categories;
            });

            // Update the current selected category when a document is searched.
            $rootScope.$on(events.documentedSelected, function (event, document) {
                if (!document) {
                    return;
                }

                var category = document.Category;

                $scope.types.forEach(function (literatureType) {
                    literatureType.IsSelected =
                        (literatureType.Name === category);
                });
            });

            // Broadcast the type and update the view state.
            this.loadType = function (typeToLoad) {
                $rootScope.$broadcast(events.typeSelected, typeToLoad);
                var typeToLoadName = typeToLoad.Name;

                $scope.types.forEach(function (literatureType) {
                    literatureType.IsSelected =
                        literatureType.Name === typeToLoadName;
                });
            };
        }
    ])
    .controller("AvailableController", [
        "$scope",
        "$rootScope",
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            // Update the current literature list and
            // selected literature when a document is searched.
            $rootScope.$on(events.documentedSelected, function (event, document) {
                if (!document) {
                    return;
                }

                $scope.literature = LiteratureLibraryService.getDocuments(document.Category);

                // Show only the current document as selected.
                var title = document.Title;

                $scope.literature.forEach(function (lit) {
                    lit.IsSelected = (lit.Title === title);
                });
            });

            $rootScope.$on(events.typeSelected, function (event, literatureType) {
                // Clear out the literature if none provided.
                if (!literatureType) {
                    return ($scope.literature = []);
                }

                // Fetch the data.
                $scope.literature = LiteratureLibraryService.getDocuments(literatureType.Name);

                // Deselect all of the documents.
                $scope.literature.forEach(function (document) {
                    document.IsSelected = false;
                });
            });

            $rootScope.$on(events.dateFilter, function (event, filterDate) {
                // Ignore if the date is empty.
                if (!filterDate) {
                    return;
                }

                // Fetch the data.
                $scope.literature = LiteratureLibraryService.filterByDate(filterDate);

                // Deselect all of the documents.
                $scope.literature.forEach(function (document) {
                    document.IsSelected = false;
                });
            });

            // Broadcast the selected document and update the view state.
            this.loadDocument = function (documentToLoad) {
                $rootScope.$broadcast(events.documentedSelected, documentToLoad);
                var documentToLoadKey = documentToLoad.Key;

                $scope.literature.forEach(function (document) {
                    document.IsSelected = (document.Key === documentToLoadKey);
                });
            };
        }
    ])
    .controller("DocumentController", [
        "$scope",
        "$rootScope",
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            $rootScope.$on(events.documentedSelected, function (event, document) {
                $scope.document = LiteratureLibraryService.getDocument(document.Key);

                // Force apply, as the typeahead jQuery event mode update may not re-render!
                // Note this is an anti-pattern and would be resolved by integrating typeahead.js
                // correctly with Angular:
                // https://github.com/angular/angular.js/wiki/Anti-Patterns
                if (!$scope.$$phase) {
                    $scope.$apply();
                }
            });
        }
    ]);
