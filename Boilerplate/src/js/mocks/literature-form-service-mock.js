// jscs:disable maximumLineLength
var mockData = {
    documents: [
        {
            AvailableLiterature: [],
            Category: "Business",
            Code: "PHU1234",
            Description: "Vitality GP Select with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/guide-to-business-healthcare---january-2015-print-friendly.pdf",
            DocumentSize: 330,
            EffectivePlanDate: "2015-07-06T23:00:00Z",
            Key: "vitality-gp-select",
            PlanNumber : 10,
            PlanType : "Personal",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare - New Business Only"
        },
        {
            AvailableLiterature: [],
            Category: "Personal",
            Code: "PLU1294A",
            Description: "Vitality GP with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            DocumentSize: 200,
            EffectivePlanDate: "2016-01-06T23:00:00Z",
            Key: "vitality-gp",
            PlanNumber : 10,
            PlanType : "Business",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare - Business Only"
        },
        {
            AvailableLiterature: [],
            Category: "Corporate",
            Code: "NPU1234",
            Description: "Health and rewards partners with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            DocumentSize: 220,
            EffectivePlanDate: "2016-04-20T23:00:00Z",
            Key: "health-and-rewards-partners",
            PlanNumber : 20,
            PlanType : "Business",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare - Moratorium - Business Only"
        },
        {
            AvailableLiterature: [],
            Category: "Corporate",
            Code: "PHU1294A",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            DocumentSize: 1024,
            EffectivePlanDate: "2016-03-06T23:00:00Z",
            Key: "personal-healthcare-sales-aid",
            PlanNumber : 50,
            PlanType : "Corporate",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare - New Business"
        }
    ]
};

angular
    .module("LiteratureFormService", [])
    .service("LiteratureFormService", function () {
        "use strict";
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
            return _.sortBy(mockData.documents
                .filter(function (document) {
                    return document.PlanNumber === this.formState.planCode &&
                        moment(document.EffectivePlanDate).isAfter(this.formState.date) &&
                        document.PlanType === this.formState.planType;
                }, this)
                .map(function (document) {
                    document.FileType = _.last(document.Document.split(".")).toUpperCase();
                    return document;
                }), documentProperties.Title);
        };

        this.getPlanCodes = function (category) {
            return _.uniq(_.pluck(mockData.documents, documentProperties.PlanNumber)).sort();
        };

        this.getPlanTypes = function (callback) {
            return callback(_.uniq(_.pluck(mockData.documents, documentProperties.PlanType)).sort());
        };
    });
