var events = {
    dateSubmit: "dateSubmit",
    planCodeSubmit: "planCodeSubmit",
    planTypeSubmit: "planTypeSubmit",
    restart: "restart"
};

window.healthAdvisersSalesLiteratureApp = angular
    .module("HealthAdvisersFormApp", ["LiteratureFormService"])
    .controller("PlanTypeStepController", [
        "$scope",
        "$rootScope",
        "LiteratureFormService",
        function ($scope, $rootScope, LiteratureFormService) {
            "use strict";
            $scope.isVisible = true;
            $scope.planTypes = LiteratureFormService.getCategories();
            $scope.selectedPlanType = $scope.planTypes[1];

            $rootScope.$on(events.restart, function (event) {
                $scope.isVisible = true;
            });

            $scope.typeSelected = function () {
                this.isVisible = false;
                LiteratureFormService.setPlanType(this.selectedPlanType);
                $rootScope.$broadcast(events.planTypeSubmit);
            };
        }
    ])
    .controller("DateStepController", [
        "$scope",
        "$rootScope",
        function ($scope, $rootScope) {
            "use strict";
            $scope.isVisible = false;

            $rootScope.$on(events.planTypeSubmit, function (event) {
                $scope.isVisible = true;
            });

            $scope.dateEntered = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.dateSubmit);
            };
        }
    ])
    .controller("PlanCodeController", [
        "$scope",
        "$rootScope",
        "LiteratureFormService",
        function ($scope, $rootScope, LiteratureFormService) {
            "use strict";
            $scope.isVisible = false;
            $scope.planCodes = [];
            $scope.selectedPlanCode = "";

            $rootScope.$on(events.dateSubmit, function (event) {
                $scope.planCodes = LiteratureFormService.getPlanCodes();
                $scope.selectedPlanCode = $scope.planCodes[0];
                $scope.isVisible = true;
            });

            $scope.planCodeSubmit = function () {
                this.isVisible = false;
                LiteratureFormService.setPlanCode(this.selectedPlanCode);
                $rootScope.$broadcast(events.planCodeSubmit);
            };
        }
    ])
    .controller("ResultsController", [
        "$scope",
        "$rootScope",
        "LiteratureFormService",
        function ($scope, $rootScope, LiteratureFormService) {
            "use strict";
            $scope.badges = [];
            $scope.documents = [];

            $scope.isVisible = false;

            $rootScope.$on(events.planCodeSubmit, function (event) {
                var formState = angular.copy(LiteratureFormService.getFormState());
                formState.date = formState.date.toDateString();
                $scope.badges = _.values(formState);
                $scope.documents = LiteratureFormService.getDocuments();
                $scope.isVisible = true;
            });

            $scope.restart = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.restart);
            };
        }
    ]);
