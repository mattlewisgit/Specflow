var mockData = {
    documents: [
        {
            "Title": "Vitality GP Select",
            "Description": "Vitality GP Select with VitalityHealth",
            "PublishDate": "2016-06-01T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/guide-to-business-healthcare---january-2015-print-friendly.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/client_fic.gif",
            "Code": "PHU1234",
            "Category": "Sales Literature",
            "Key": "vitality-gp-select",
            "AvailableLiterature": []
        },
        {
            "Title": "Vitality GP",
            "Description": "Vitality GP with VitalityHealth",
            "PublishDate": "2016-07-06T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/essentials_life_policysum.gif",
            "Code": "PHU1294A",
            "Category": "Sales Literature",
            "Key": "vitality-gp",
            "AvailableLiterature": []
        },
        {
            "Title": "Health and rewards partners",
            "Description": "Health and rewards partners with VitalityHealth",
            "PublishDate": "2016-06-01T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/adviser_education.gif",
            "Code": "PHU1234",
            "Category": "Sales Literature",
            "Key": "health-and-rewards-partners",
            "AvailableLiterature": []
        },
        {
            "Title": "Personal Healthcare sales aid",
            "Description": "Personal Healthcare with VitalityHealth",
            "PublishDate": "2016-07-06T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/essentials_life_policysum.gif",
            "Code": "PHU1294A",
            "Category": "Personal healthcare literature",
            "Key": "personal-healthcare-sales-aid",
            "AvailableLiterature": []
        },
        {
            "Title": "Guide to Cover - Personal Healthcare 2015",
            "Description": "Personal Healthcare with VitalityHealth",
            "PublishDate": "2016-06-01T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/adviser_education.gif",
            "Code": "PHU1234",
            "Category": "Personal healthcare literature",
            "Key": "guide-to-cover---personal-healthcare-2015",
            "AvailableLiterature": []
        },
        {
            "Title": "Guide to Cover - Business Healthcare 2015",
            "Description": "Business Healthcare with VitalityHealth",
            "PublishDate": "2016-06-01T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/business-healthcare-sales-aid---january-2015.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/wol_faq_thumb.jpg",
            "Code": "PHU1234",
            "Category": "Business and Corporate Healthcare Literature",
            "Key": "guide-to-cover---business-healthcare-2015",
            "AvailableLiterature": []
        },
        {
            "Title": "Business Healthcare sales aid",
            "Description": "Business Healthcare with VitalityHealth",
            "PublishDate": "2016-07-06T23:00:00Z",
            "Document": "dev.vitality.co.uk/media-online/presales/pdf/development/phf-sales-aid-v2.pdf",
            "Thumbnail": "dev.vitality.co.uk/media-online/presales/pdf/development/mortgage_plus_planprov.gif",
            "Code": "PHU1294A",
            "Category": "Business and Corporate Healthcare Literature",
            "Key": "business-healthcare-sales-aid",
            "AvailableLiterature": []
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

        this.searchDocuments = function (text) {
            return mockData.documents.filter(function (document) {
                return document.Title.toLowerCase().indexOf(text) > -1;
            });
        };
    });
