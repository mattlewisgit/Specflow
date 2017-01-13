angular
    .module("SiteSearchService", [])
    .service("SiteSearchService", ["$http", "$q", "$sce", function($http, $q, $sce) {
        "use strict";
        var baseUrl = "/api/search/" ;
        var searchParams =
        {
            orderBy: "asc",
            pageNo: 1,
            pageSize: 50
        }

        // Move to the controller?
        function highlight(text, term) {
            return $sce.trustAsHtml(text.replace(new RegExp(term, "gi"),
                function(match) {
                    return "<span class=\"text--primary\">" + match + "</span>";
                }));
        }

        this.search = function (term) {
            var deferred = $q.defer();
            searchParams.searchQuery = (term || "").toLowerCase();

            $http
                .post(baseUrl, searchParams)
                .error(function (result) {
                    // Send back an empty dataset.
                    deferred.resolve([]);
                })
                .success(function (data) {
                    // Sanity check the data and ensure it at least has a title.
                    var results = _.map(_.filter(data, function (result) {
                        return !!result.Title;
                    }), function (result) {
                        return {
                            breadcrumb: result.Breadcrumbs,
                            description: highlight(result.Description, term),
                            title: highlight(result.Title, term),
                            url: result.Path
                        };
                    });

                    deferred.resolve(results);
                });

            return deferred.promise;
        };
    }]);
