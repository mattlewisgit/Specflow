// jscs:disable maximumNumberOfLines
var MomentApi = require("../config/moment-api.json");

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
            $scope.planTypes = LiteratureFormService.getPlanTypes();
            $scope.selectedPlanType = $scope.planTypes[0];

            $rootScope.$on(events.restart, function () {
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
        "LiteratureFormService",
        function ($scope, $rootScope, LiteratureFormService) {
            "use strict";
            // Initialise the date model with today.
            var today = new Date();

            $scope.filterDate = {
                day: today.getDate(),
                month: today.getMonth() + 1,
                year: today.getFullYear()
            };

            $scope.isVisible = false;

            $rootScope.$on(events.planTypeSubmit, function () {
                $scope.isVisible = true;
            });

            $scope.back = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.restart);
            };

            $scope.dateEntered = function (dateForm, filterDate) {
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

                this.isVisible = false;
                LiteratureFormService.setDate(actualDate);
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

            $rootScope.$on(events.dateSubmit, function () {
                $scope.planCodes = LiteratureFormService.getPlanCodes();
                $scope.selectedPlanCode = $scope.planCodes[0];
                $scope.isVisible = true;
            });

            $scope.back = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.planTypeSubmit);
            };

            $scope.planCodeSubmit = function () {
                this.isVisible = false;
                LiteratureFormService.setPlanCode(+this.selectedPlanCode);
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

            $rootScope.$on(events.planCodeSubmit, function () {
                var formState = angular.copy(LiteratureFormService.getFormState());
                formState.date = formState.date.format("d MMM YYYY");
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
