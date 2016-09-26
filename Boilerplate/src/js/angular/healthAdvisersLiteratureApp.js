var events = {
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
        "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            // Initialise the date model with today.
            var today = new Date();

            $scope.filterDate = {
                "day": today.getDate(),
                "month": today.getMonth() + 1,
                "year": today.getFullYear()
            };

            // Broadcast the type and update the view state.
            $scope.filterAction = function (filterDate) {
                debugger;
                var actualDate = new Date(filterDate.year, filterDate.month - 1, filterDate.day);
                // TODO Use Moment.js to validate
                // TODO Fire a new broadcast event and filter the docs
            };
        }
    ])
    .controller("ChooseController", [
        "$scope",
        "$rootScope",
        "literatureTypes",
        function ($scope, $rootScope, literatureTypes) {
            "use strict";
            $scope.types = literatureTypes;

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
            $rootScope.$on(events.typeSelected, function (event, literatureType) {
                // Clear out the literature if none provided.
                if (!literatureType) {
                    return ($scope.literature = []);
                }

                // Fetch the data.
                $scope.literature = LiteratureLibraryService.getLiterature(literatureType.Name);

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
                    document.IsSelected = document.Key === documentToLoadKey;
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
                $scope.$apply();
            });
        }
    ]);
