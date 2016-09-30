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
                            },
                            templates: {
                                notFound: "<div class=\"tt-no-results\">Sorry, there are no matching documents.</div>"
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
    .controller("ChooseController", [
        "$scope",
        "$rootScope",
        "$window",
        function ($scope, $rootScope, $window) {
            "use strict";
            $scope.types = $window.angularData.literatureTypes;

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
                LiteratureLibraryService.getLiterature(literatureType.Name, function(data) {
                    $scope.literature = data;
                });

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
