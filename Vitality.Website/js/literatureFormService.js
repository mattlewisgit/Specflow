angular
    .module("LiteratureFormService", [])
    .service("LiteratureFormService", ["$http", function ($http) {
        "use strict";
        var baseUrl = "/api/literature/";
        var cachedPlanTypes = [];
        var cachedDocuments = [];

        this._formState = {
            date: moment(),
            planCode: "",
            planType: "",
        };

        this._planCodes = [];

        var documentProperties = {
            PlanNumber: "PlanNumber",
            PlanType: "PlanType",
            Title: "Title"
        };

        this.getPlanCodes = function () {
            return _.uniq(_.pluck(cachedDocuments, documentProperties.PlanNumber)).sort();
        };

        this.getPlanTypes = function(callback) {
            if (cachedPlanTypes && cachedPlanTypes.length > 0) {
                callback(cachedPlanTypes);
            }

            $http
                .get(baseUrl + window.angularData.literaturePath)
                .error(function() {
                    // ...
                })
                .then(function (response) {
                    cachedDocuments = response.data;
                    cachedPlanTypes = _.uniq(_.pluck(cachedDocuments, documentProperties.PlanType)).sort();
                    callback(cachedPlanTypes);
                });
        };

        this.getDocuments = function () {
            return _.sortBy(cachedDocuments
                .filter(function (document) {
                    // Filter documents based on the plan number, effective date and plan type.
                    return (+document.PlanNumber) === (+this._formState.planCode) &&
                        moment(document.EffectivePlanDate).isAfter(this._formState.date) &&
                        document.PlanType === this._formState.planType;
                }, this)
                .map(function (document) {
                    document.FileType = _.last(document.Document.split(".")).toUpperCase();
                    return document;
                }), documentProperties.Title);
        };

        this.getFormState = function () {
            return this._formState;
        };

        this.setDate = function (date) {
            this._formState.date = date;
        }

        this.setPlanCode = function (planCode) {
            this._formState.planCode = planCode;
        }

        this.setPlanType = function (planType) {
            this._formState.planType = planType;
        }
    }]);
