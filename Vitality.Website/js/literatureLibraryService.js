angular
    .module("LiteratureLibraryService", [])
    .service("LiteratureLibraryService", [
        "$http",
        function ($http) {
            "use strict";
            var baseUrl = "/api/literature/";
            var cachedDocuments = [];
            var currentDocument = {};

            $http
                .get(baseUrl + "sales-literature")
                .error(function () {
                    debugger;
                })
                .then(function (response) {
                    cachedDocuments = response.data;
                });

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

            this.getLiterature = function (name, callback) {
                $http
                   .get(baseUrl + "sales-literature/" + name)
                   .error(function () {
                       debugger;
                   })
                   .then(function (response) {
                       callback(response.data);
                   });
            };

            this.searchDocuments = function (text) {
                return cachedDocuments.filter(function (document) {
                    return document.Title.toLowerCase().indexOf(text) > -1;
                });
            };
        }
    ]);
