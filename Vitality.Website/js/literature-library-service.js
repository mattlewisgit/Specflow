angular
    .module("LiteratureLibraryService", [])
    .service("LiteratureLibraryService", [
        "$http",
        "$window",
        function ($http) {
            "use strict";
            var baseUrl = "/api/literature/";
            var cachedCategories = [];
            var cachedDocuments = [];
            var currentDocument = {};

            var documentProperties = {
                Category: "Category",
                Title: "Title"
            };

            this.currentDocument = function () {
                return currentDocument;
            };

            this.getDocument = function (key) {
                for (var i = 0; i < cachedDocuments.length; ++i) {
                    var document = cachedDocuments[i];

                    if (document.Key === key) {
                        return document;
                    }
                }
            };

            this.getCategories = function (callback) {
                // Use this to initialise the documents data...
                // Finds every unique category name from the list of documents,
                // and returns a list of objects with those names and a default,
                // deselected flag, then caches the result!
                if (cachedCategories && cachedCategories.length > 0) {
                    callback(cachedCategories);
                }

                $http
                   .get(baseUrl + window.angularData.literaturePath.toLowerCase())
                   .error(function () {
                       // ...
                   })
                   .then(function (response) {
                       cachedDocuments = response.data;

                       cachedDocuments.forEach(function (document) {
                           if (document.EffectivePlanDate) {
                               document.EffectivePlanDate = new Date(document.EffectivePlanDate);
                           }
                       });

                       cachedCategories = Object
                            .keys(cachedDocuments.reduce(function(aggregate, document) {
                                // Use an object so that the key name is unique.
                                aggregate[document.Category] = true;
                                return aggregate;
                            },
                            {}))
                           .sort()
                            .map(function(name) {
                                return {
                                    Name: name,
                                    IsSelected: false
                                };
                            });

                        callback(cachedCategories);
                    });
            };

            this.getDocuments = function (category) {
                return _.sortBy(cachedDocuments.filter(function (document) {
                    return document.Category === category;
                }), documentProperties.Title);
            };

            this.filterByDate = function (filterDate) {
                return _.sortBy(cachedDocuments.filter(function (document) {
                    var planDate = document.EffectivePlanDate;
                    return planDate && planDate >= filterDate;
                }), documentProperties.Title);
            };

            this.searchDocuments = function (text) {
                text = (text || "").toLowerCase();

                return _.sortBy(cachedDocuments.filter(function (document) {
                    return document.Title.toLowerCase().indexOf(text) > -1;
                }), documentProperties.Title);
            };
        }
    ]);
