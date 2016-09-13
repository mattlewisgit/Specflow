var events = {
    documentedSelected: "documentedSelected",
    typeSelected: "typeSelected"
};

function randomDate(start, end) {
    end = end || new Date();
    start = start || new Date(end.getFullYear() - 1, end.getMonth(), end.getDate());
    return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
}

var mockData = {
    documents: {
        "guide-to-cover---business-healthcare-2015": {
            AvailableLiterature: [],
            Category: "Business healthcare literature",
            Code: "PHU1294A",
            Description: "Business Healthcare with VitalityHealth",
            Document: "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
            PublishDate: randomDate().toJSON(),
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Business Healthcare sales aid"
        },
        "guide-to-healthy-living-rewards-and-partners-january-2015": {
            AvailableLiterature: [],
            Category: "Business healthcare literature",
            Code: "PHU1294A",
            Description: "Health and Reward partners with VitalityHealth",
            Document: "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
            PublishDate: randomDate().toJSON(),
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Health and Reward partners"
        },
        "guide-to-cover---personal-healthcare-2015": {
            AvailableLiterature: [],
            Category: "Personal healthcare literature",
            Code: "PHU1294A",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
            PublishDate: randomDate().toJSON(),
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare sales aid"
        }
    },
    literature: {
        "Personal healthcare literature": [
            {
                CategoryKey: "business-and-corporate-healthcare-literature",
                Key: "guide-to-cover---business-healthcare-2015",
                Title: "Guide to Cover - Business Healthcare 2015"
            },
            {
                CategoryKey: "personal-healthcare-literature",
                Key: "guide-to-cover---personal-healthcare-2015",
                Title: "Guide to Cover - Personal Healthcare 2015"
            }
        ],
        "Sales literature": [
            {
                CategoryKey: "sales-support-and-literature",
                Key: "guide-to-healthy-living-rewards-and-partners-january-2015",
                Title: "Health and Reward partners"
            }
        ]
    }
};

window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersSalesLiteratureApp", [])
    .factory("dataService", ["$http", function ($http) {
        var _currentDocument = {};

        return {
            currentDocument: function() {
                return _currentDocument;
            },
            getDocument: function (key) {
                return (_currentDocument = mockData.documents[key]);
            },
            getLiterature: function (name) {
                return mockData.literature[name];
            }
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
    .controller("AvailableController", ["$scope", "$rootScope", "dataService",
        function ($scope, $rootScope, dataService) {
            "use strict";
            $rootScope.$on(events.typeSelected, function (event, literatureType) {
                // Fetch the data.
                $scope.literature = dataService.getLiterature(literatureType.Name);

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
    .controller("DocumentController", ["$scope", "$rootScope", "dataService",
        function ($scope, $rootScope, dataService) {
            "use strict";
            $rootScope.$on(events.documentedSelected, function (event, document) {
                $scope.document = dataService.getDocument(document.Key);
            });
        }]);
