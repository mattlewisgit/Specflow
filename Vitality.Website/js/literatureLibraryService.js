angular
    .module("LiteratureLibraryService", [])
    .service("LiteratureLibraryService", [
        "$http",
        function ($http) {
            "use strict";
            var baseUrl = "/api/literature/";
            var cachedCategories = [];
            var cachedDocuments = [];
            var currentDocument = {};

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
                    return cachedCategories;
                }

                $http
                   .get(baseUrl + "sales-literature")
                   .error(function () {
                       debugger;
                   })
                   .then(function (response) {
                       cachedDocuments = response.data;

                        cachedCategories = Object
                            .keys(cachedDocuments.reduce(function(aggregate, document) {
                                // Use an object so that the key name is unique.
                                aggregate[document.Category] = true;
                                return aggregate;
                            },
                            {}))
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
                return cachedDocuments.filter(function (document) {
                    return document.Category === category;
                }); 
            };

            this.searchDocuments = function (text) {
                return cachedDocuments.filter(function (document) {
                    return document.Title.toLowerCase().indexOf(text) > -1;
                });
            };
        }
    ]);
