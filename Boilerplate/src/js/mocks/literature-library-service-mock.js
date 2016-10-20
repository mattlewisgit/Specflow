// jscs:disable maximumLineLength
var mockData = {
    documents: [
        // Deliberately missing the Thumbnail and Description attributes.
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1234",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/guide-to-business-healthcare---january-2015-print-friendly.pdf",
            EffectivePlanDate: new Date("2015-07-06T23:00:00Z"),
            Key: "vitality-gp-select",
            PublishDate: "2016-06-01T23:00:00Z",
            Title: "Vitality GP Select"
        },
        {
            // Deliberately empty Thumbnail and Description attributes.
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1294A",
            Description: "",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            EffectivePlanDate: new Date("2016-01-06T23:00:00Z"),
            Key: "vitality-gp",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "",
            Title: "Vitality GP"
        },
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1234",
            Description: "Health and rewards partners with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            EffectivePlanDate: new Date("2016-04-20T23:00:00Z"),
            Key: "health-and-rewards-partners",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Health and rewards partners"
        },
        {
            AvailableLiterature: [],
            Category: "Personal healthcare literature",
            Code: "PHU1294A",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            EffectivePlanDate: new Date("2016-03-06T23:00:00Z"),
            Key: "personal-healthcare-sales-aid",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare sales aid"
        },
        {
            AvailableLiterature: [],
            Category: "Personal healthcare literature",
            Code: "PHU1234",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            EffectivePlanDate: new Date("2017-07-06T23:00:00Z"),
            Key: "guide-to-cover---personal-healthcare-2015",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Guide to Cover - Personal Healthcare 2015"
        },
        {
            AvailableLiterature: [],
            Category: "Business and Corporate Healthcare Literature",
            Code: "PHU1234",
            Description: "Business Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            EffectivePlanDate: new Date("2016-02-01T23:00:00Z"),
            Key: "guide-to-cover---business-healthcare-2015",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Guide to Cover - Business Healthcare 2015"
        },
        {
            AvailableLiterature: [],
            Category: "Business and Corporate Healthcare Literature",
            Code: "PHU1294A",
            Description: "Business Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            EffectivePlanDate: new Date("2016-12-22T23:00:00Z"),
            Key: "business-healthcare-sales-aid",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Business Healthcare sales aid"
        }
    ]
};

angular
    .module("LiteratureLibraryService", [])
    .service("LiteratureLibraryService", function () {
        "use strict";
        var categories = [];
        var currentDocument = {};

        var documentProperties = {
            Category: "Category",
            Title: "Title"
        };

        this.currentDocument = function () {
            return currentDocument;
        };

        this.getCategories = function (callback) {
            // Finds every unique category name from the list of documents,
            // and returns a list of objects with those names and a default,
            // deselected flag, then caches the result!
            callback((categories.length > 0 && categories) ||
                (categories = Object
                    .keys(mockData.documents.reduce(function (aggregate, document) {
                        // Use an object so that the key name is unique.
                        aggregate[document.Category] = true;
                        return aggregate;
                    }, {})))
                    .sort()
                    .map(function(name) {
                        return {
                            Name: name,
                            IsSelected: false
                        };
                    }));
        };

        this.getDocument = function (key) {
            return (currentDocument = mockData.documents.filter(function (document) {
                return document.Key === key;
            })[0]);
        };

        this.getDocuments = function (category) {
            return _.sortBy(mockData.documents.filter(function (document) {
                return document.Category === category;
            }), documentProperties.Title);
        };

        this.getLiterature = function(category) {
            return _.sortBy(mockData.documents.filter(function(document) {
                return document.Category === category;
            }), documentProperties.Category);
        };

        this.filterByDate = function (filterDate) {
            return _.sortBy(mockData.documents.filter(function (document) {
                var planDate = document.EffectivePlanDate;
                return planDate && planDate > filterDate;
            }), documentProperties.Title);
        };

        this.searchDocuments = function (text) {
            text = (text || "").toLowerCase();

            return _.sortBy(mockData.documents.filter(function (document) {
                return document.Title.toLowerCase().indexOf(text) > -1;
            }), documentProperties.Title);
        };
    });
