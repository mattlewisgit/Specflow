angular
    .module("HealthAdvisersSalesLiteratureApp", [])
    .controller("ChooseController", ["$scope", "$window", function($scope, $window) {
        "use strict";
        $scope.types = $window.AvailableLiteratureTypes;
    }])
    .controller("AvailableController", function ($scope) {
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
    })
    .controller("DocumentController", function ($scope) {
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
    });
