// jscs:disable maximumLineLength
var mockData = {
    documents: [
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1234",
            Description: "Vitality GP Select with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/guide-to-business-healthcare---january-2015-print-friendly.pdf",
            EffectivePlanDate: new Date("2015-07-06T23:00:00Z"),
            Key: "vitality-gp-select",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Vitality GP Select"
        },
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1294A",
            Description: "Vitality GP with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            EffectivePlanDate: new Date("2016-01-06T23:00:00Z"),
            Key: "vitality-gp",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "/src/img/examples/example-pdf.png",
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
    ],
    literature: {
        "Personal healthcare literature": [
            {
                CategoryKey: "business-and-corporate-healthcare-literature",
                Key: "guide-to-cover---business-healthcare-2015",
                Title: "Guide to Cover - Business Healthcare 2015"
            },
            {
                CategoryKey: "personal-healthcare-literature",
                Key: "guide-to-cover---personal-healthcare-2015",
                Title: "Guide to Cover - Personal Healthcare 2015"
            }
        ],
        "Sales literature": [
            {
                CategoryKey: "sales-support-and-literature",
                Key: "guide-to-healthy-living-rewards-and-partners-january-2015",
                Title: "Health and Reward partners"
            }
        ]
    }
};

angular
    .module("LiteratureLibraryService", [])
    .service("LiteratureLibraryService", function () {
        "use strict";
        var currentDocument = {};

        this.currentDocument = function () {
            return currentDocument;
        };

        this.getDocument = function (key) {
            return (currentDocument = mockData.documents.filter(function (document) {
                return document.Key === key;
            })[0]);
        };

        this.getLiterature = function (name) {
            return mockData.literature[name];
        };

        this.filterByDate = function (filterDate) {
            return mockData.documents.filter(function (document) {
                var planDate = document.EffectivePlanDate;
                return planDate && planDate > filterDate;
            });
        };

        this.searchDocuments = function (text) {
            return mockData.documents.filter(function (document) {
                return document.Title.toLowerCase().indexOf(text) > -1;
            });
        };
    });
