window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersFormApp", ["LiteratureLibraryService"])
    .controller("PlanTypeStepController", [
        "$scope",
        "$rootScope",
        function($scope, $rootScope) {
            "use strict";
            $scope.planTypes = [
                "Business",
                "Personal",
                "Corporate"
            ];

            $scope.selectedPlanType = $scope.planTypes[1];

            $scope.typeSelected = function (data) {
                debugger;
                //$scope.selectedPlanType
                //$rootScope.$broadcast(events.dateFilter, actualDate);
            };
        }
    ]);
