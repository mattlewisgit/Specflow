// jscs:disable maximumLineLength
var mockData = {
    documents: [
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1234",
            Description: "Vitality GP Select with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/guide-to-business-healthcare---january-2015-print-friendly.pdf",
            Key: "vitality-gp-select",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/client_fic.gif",
            Title: "Vitality GP Select"
        },
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1294A",
            Description: "Vitality GP with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            Key: "vitality-gp",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/essentials_life_policysum.gif",
            Title: "Vitality GP"
        },
        {
            AvailableLiterature: [],
            Category: "Sales Literature",
            Code: "PHU1234",
            Description: "Health and rewards partners with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            Key: "health-and-rewards-partners",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/adviser_education.gif",
            Title: "Health and rewards partners"
        },
        {
            AvailableLiterature: [],
            Category: "Personal healthcare literature",
            Code: "PHU1294A",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            Key: "personal-healthcare-sales-aid",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/essentials_life_policysum.gif",
            Title: "Personal Healthcare sales aid"
        },
        {
            AvailableLiterature: [],
            Category: "Personal healthcare literature",
            Code: "PHU1234",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            Key: "guide-to-cover---personal-healthcare-2015",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/adviser_education.gif",
            Title: "Guide to Cover - Personal Healthcare 2015"
        },
        {
            AvailableLiterature: [],
            Category: "Business and Corporate Healthcare Literature",
            Code: "PHU1234",
            Description: "Business Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            Key: "guide-to-cover---business-healthcare-2015",
            PublishDate: "2016-06-01T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/wol_faq_thumb.jpg",
            Title: "Guide to Cover - Business Healthcare 2015"
        },
        {
            AvailableLiterature: [],
            Category: "Business and Corporate Healthcare Literature",
            Code: "PHU1294A",
            Description: "Business Healthcare with VitalityHealth",
            Document: "http://dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            Key: "business-healthcare-sales-aid",
            PublishDate: "2016-07-06T23:00:00Z",
            Thumbnail: "http://dev.vitality.co.uk/media-online/presales/pdf/development/mortgage_plus_planprov.gif",
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

        this.currentDocument = function () {
            return currentDocument;
        };

        this.getCategories = function () {
            // Finds every unique category name from the list of documents,
            // and returns a list of objects with those names and a default,
            // deselected flag, then caches the result!
            return (categories.length > 0 && categories) ||
                (categories = Object
                    .keys(mockData.documents.reduce(function (aggregate, document) {
                        // Use an object so that the key name is unique.
                        aggregate[document.Category] = true;
                        return aggregate;
                    }, {})))
                    .map(function(name) {
                        return {
                            Name: name,
                            IsSelected: false
                        };
                    });
        };

        this.getDocument = function (key) {
            return (currentDocument = mockData.documents.filter(function (document) {
                return document.Key === key;
            })[0]);
        };

        this.getLiterature = function (category) {
            return mockData.documents.filter(function (document) {
                return document.Category === category;
            });
        };

        this.searchDocuments = function (text) {
            return mockData.documents.filter(function (document) {
                return document.Title.toLowerCase().indexOf(text) > -1;
            });
        };
    });
