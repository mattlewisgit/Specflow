function randomDate(start, end) {
    end = end || new Date();
    start = start || new Date(end.getFullYear() - 1, end.getMonth(), end.getDate());
    return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
}

var mockData = {
    documents: {
        "guide-to-cover---business-healthcare-2015": {
            AvailableLiterature: [],
            Category: "Business healthcare literature",
            Code: "PHU1294A",
            Description: "Business Healthcare with VitalityHealth",
            Document: "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
            Key: "guide-to-cover---business-healthcare-2015",
            PublishDate: randomDate().toJSON(),
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Business Healthcare sales aid"
        },
        "guide-to-healthy-living-rewards-and-partners-january-2015": {
            AvailableLiterature: [],
            Category: "Business healthcare literature",
            Code: "PHU1294A",
            Description: "Health and Reward partners with VitalityHealth",
            Document: "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
            Key: "guide-to-healthy-living-rewards-and-partners-january-2015",
            PublishDate: randomDate().toJSON(),
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Health and Reward partners"
        },
        "guide-to-cover---personal-healthcare-2015": {
            AvailableLiterature: [],
            Category: "Personal healthcare literature",
            Code: "PHU1294A",
            Description: "Personal Healthcare with VitalityHealth",
            Document: "dev.vitality.co.uk/-/media/Presales/pdf/Development/PHF-sales-aid-v2.ashx",
            Key: "guide-to-cover---personal-healthcare-2015",
            PublishDate: randomDate().toJSON(),
            Thumbnail: "/src/img/examples/example-pdf.png",
            Title: "Personal Healthcare sales aid"
        }
    },
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
        var currentDocument = {};

        this.currentDocument = function () {
            return currentDocument;
        };

        this.getDocument = function (key) {
            return (currentDocument = mockData.documents[key]);
        };

        this.getLiterature = function (name) {
            return mockData.literature[name];
        };

        this.searchDocuments = function(text) {
            return Object.keys(mockData.documents)
                .map(function (key) {
                    return mockData.documents[key];
                })
                .filter(function (document) {
                    return document.Title.toLowerCase().indexOf(text) > -1;
                });
        };
});
