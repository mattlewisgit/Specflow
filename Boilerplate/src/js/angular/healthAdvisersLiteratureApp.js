var events = {
    typeSelecteddocumentedSelected: "documentedSelected",
    typeSelected: "typeSelected"
};

window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersSalesLiteratureApp", ["LiteratureLibraryService"])
    .controller("SearchController", ["$scope", "$rootScope", "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";

            this.search = function (text) {
                $scope.documents = LiteratureLibraryService.searchDocuments(text);
            };

            this.select = function (document) {
                $rootScope.$broadcast(events.documentedSelected, document);
                $rootScope.$broadcast(events.typeSelected);
            };
        }])
    .controller("ChooseController", ["$scope", "$rootScope", "literatureTypes",
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
        }])
    .controller("AvailableController", ["$scope", "$rootScope", "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            $rootScope.$on(events.typeSelected, function (event, literatureType) {
                // Clear out the literature if none provided.
                if (!literatureType) {
                    return $scope.literature = [];
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
        }])
    .controller("DocumentController", ["$scope", "$rootScope", "LiteratureLibraryService",
        function ($scope, $rootScope, LiteratureLibraryService) {
            "use strict";
            $rootScope.$on(events.documentedSelected, function (event, document) {
                $scope.document = LiteratureLibraryService.getDocument(document.Key);
            });
        }]);
