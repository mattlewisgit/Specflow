var mockData = [
    {
        breadcrumb: [],
        description: "Vitality is insurance that rewards you for being healthy and saves you " +
            "money at the same time. Find out how Vitality could help you and your family.",
        title: "Health Insurance",
        url: "https://www.vitality.co.uk/health-insurance/"
    },
    {
        breadcrumb: [
            "Rewards",
            "Reward Partners",
            "Travel",
            "British Airways"
        ],
        description: "Get discounts of up to 40% off on return flights in the UK and " +
            "Europe as part of our healthy living rewards for Vitality members.",
        title: "40% British Airways Flights - Health Insurance Rewards - Vitality",
        url: "https://www.vitality.co.uk/rewards/partners/travel/british-airways/"
    },
    {
        breadcrumb: [
            "Support",
            "Tools"
        ],
        description: "Make an informed decision about the benefits of Vitality health "+
            "or life insurance through our tools and calculators.",
        title: "Tools and Calculators - Vitality",
        url: "https://www.vitality.co.uk/support/tools/"
    },
    {
        breadcrumb: [
            "Business",
            "Life Insurance",
            "Shareholder Cover"
        ],
        description: "Shareholder or Partnership Protection helps your keep control of your business " +
            "if a shareholder or business partner dies or suffers a severe illness.",
        title: "Shareholder Cover - Business Life Insurance - Vitality",
        url: "https://www.vitality.co.uk/business/life-insurance/shareholder-cover/"
    }
];

angular
    .module("SiteSearchService", [])
    .service("SiteSearchService", ["$http", "$q", "$sce", function ($http, $q, $sce) {
        "use strict";

        var baseUrl = "/api/search/";
        var searchResults = [];
        var pagesize = 10;
        var orderBy = 'asc';
        var pageNo = 1;

        // Move to the controller?
        function highlight(text, term) {
            return $sce.trustAsHtml(text.replace(new RegExp(term, "gi"),
                function(match) {
                    return "<span class=\"text--primary\">" + match + "</span>";
                }));
        }

        this.search = function (term) {
            var term = (term || "").toLowerCase();

            $http
                .get(baseUrl + '?searchQuery=' + term + '&orderBy=' + orderBy +'&pageSize=' + pagesize + '&pageNo=' + pageNo )
                .error(function () {
                    // ...
                })
                .then(function (response) {
                    debugger;
                    searchResults = response.data;
                    console.log(response);
                });

            var results = _.filter(searchResults, function (datum) {
                return datum.Description.toLowerCase().indexOf(term) > -1 ||
                    datum.Title.toLowerCase().indexOf(term) > -1;
            })
            .map(function (result) {
                    debugger;
                    console.log(result);
                // Map to another object to prevent changes to the original mock data.
                return {
                    breadcrumb: result.Breadcrumbs,
                    description: highlight(result.Description, term),
                    title: highlight(result.Title, term),
                    url: result.Path
                };
            });

            var deferred = $q.defer();
            deferred.resolve(results);
            return deferred.promise;
        };
    }]);
