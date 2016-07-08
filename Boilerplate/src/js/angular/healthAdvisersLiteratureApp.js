var events = {
    documentedSelected: "documentedSelected",
    typeSelected: "typeSelected"
};

window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersSalesLiteratureApp", [])
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
    .controller("AvailableController", ["$scope", "$rootScope",
        function ($scope, $rootScope) {
            "use strict";
            $scope.literature = [
                {
                    "Key": "guide-to-cover---business-healthcare-2015",
                    "CategoryKey": "business-and-corporate-healthcare-literature",
                    "Title": "Guide to Cover - Business Healthcare 2015",
                    "IsSelected": true
                },
                {
                    "Key": "guide-to-cover---personal-healthcare-2015",
                    "CategoryKey": "personal-healthcare-literature",
                    "Title": "Guide to Cover - Personal Healthcare 2015"
                }
            ];

            // TODO Listen for and set the documents of the selected type.
            $rootScope.$on(events.typeSelected, function (/*event, literatureType*/) {
                $scope.literature = [];
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
    .controller("DocumentController", ["$scope", "$rootScope",
        function ($scope, $rootScope) {
            "use strict";
            $scope.document = {
                "Title": "Personal Healthcare sales aid",
                "Description": "Personal Healthcare with VitalityHealth",
                "PublishDate": "2016-07-06T23:00:00Z",
                "Document": "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
                "Thumbnail": "/src/img/examples/example-pdf.png",
                "Code": "PHU1294A",
                "Category": "Personal healthcare literature",
                "AvailableLiterature": []
            };

            // Display the current document.
            $rootScope.$on(events.documentedSelected, function (event, document) {
                $scope.document.Title = document.Title;
            });
        }]);
