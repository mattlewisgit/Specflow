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

            LiteratureFormService.getPlanTypes(function (planTypes) {
                $scope.selectedPlanType = planTypes[0];
                $scope.planTypes = planTypes;
            });

            $rootScope.$on(events.restart, function () {
                $scope.isVisible = true;
            });

            $scope.typeSelected = function () {
                this.isVisible = false;
                LiteratureFormService.formState.planType = this.selectedPlanType;
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
                LiteratureFormService.formState.date = actualDate;
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
                LiteratureFormService.formState.planCode = +this.selectedPlanCode;
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
            $scope.documents = [];
            $scope.formState = {};
            $scope.isVisible = false;

            $rootScope.$on(events.planCodeSubmit, function () {
                // Take a copy of the form state in case it is edited.
                $scope.formState = angular.copy(LiteratureFormService.formState);
                $scope.documents = LiteratureFormService.getDocuments();
                $scope.isVisible = true;
            });

            // Links from the labels to their associated steps.
            $scope.goToDateStep = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.planTypeSubmit);
            };

            $scope.goToPlanCodeStep = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.dateSubmit);
            };

            $scope.goToPlanTypeStep = function () {
                this.isVisible = false;
                $rootScope.$broadcast(events.restart);
            };

            $scope.restart = $scope.goToPlanTypeStep;
        }
    ]);
