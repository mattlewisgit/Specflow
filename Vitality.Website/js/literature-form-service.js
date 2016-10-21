angular
    .module("LiteratureFormService", [])
    .service("LiteratureFormService", ["$http", function ($http) {
        "use strict";
        var baseUrl = "/api/literature/";
        var cachedPlanTypes = [];
        var cachedDocuments = [];

        var documentProperties = {
            PlanNumber: "PlanNumber",
            PlanType: "PlanType",
            Title: "Title"
        };

        this.formState = {
            date: moment(),
            planCode: "",
            planType: "",
        };

        this.getDocuments = function () {
            return _.sortBy(cachedDocuments
                .filter(function (document) {
                    // Filter documents based on the plan number, effective date and plan type.
                    return (+document.PlanNumber) === (+this.formState.planCode) &&
                        moment(document.EffectivePlanDate).isAfter(this.formState.date) &&
                        document.PlanType === this.formState.planType;
                }, this)
                .map(function (document) {
                    document.FileType = _.last(document.Document.split(".")).toUpperCase();
                    return document;
                }), documentProperties.Title);
        };

        this.getPlanCodes = function () {
            return _.uniq(_.pluck(cachedDocuments, documentProperties.PlanNumber)).sort();
        };

        this.getPlanTypes = function(callback) {
            if (cachedPlanTypes && cachedPlanTypes.length > 0) {
                callback(cachedPlanTypes);
            }

            $http
                .get(baseUrl + window.angularData.literaturePath.toLowerCase()+'/')
                .error(function() {
                    // ...
                })
                .then(function (response) {
                    cachedDocuments = response.data;
                    cachedPlanTypes = _.uniq(_.pluck(cachedDocuments, documentProperties.PlanType)).sort();
                    callback(cachedPlanTypes);
                });
        };
    }]);
