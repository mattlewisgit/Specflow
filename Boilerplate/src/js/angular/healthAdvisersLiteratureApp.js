angular
    .module("HealthAdvisersSalesLiteratureApp", [])
    .controller("ChooseLiteratureController", function ($scope) {
        $scope.types = [
            {
                name: "Vitality GP"
            },
            {
                name: "Vitality Something"
            }
        ];
    })
    .controller("AvailableLiteratureController", function ($scope) {
        $scope.literature = [
            {
                name: "Health and rewards partners"
            },
            {
                name: "Vitality GP Select"
            },
            {
                name: "Vitality GP"
            },
            {
                name: "Hospital list"
            },
            {
                name: "Discovery company profile"
            }
        ];
    })
    .controller("LiteratureDocumentController", function ($scope) {
        $scope.document = {
            code: "CODE",
            date: "12 July 2016",
            description: "Lorem ipsum descriptivio",
            imageSource: "/src/img/examples/example-pdf.png",
            name: "Healthy Living Rewards and Partners from VitalityHealth"
        };
    });
