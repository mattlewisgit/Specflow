window.SocialConnectorApp = angular
    .module("SocialConnectorApp", [])
    .directive("popularityCount",
    [
        "$http", function($http) {
            "use strict";
            return {
                restrict: "E",
                scope: {
                    bslEndpoint: "=bslEndpoint",
                    //set the initial count info to Error message
                    countInfo: "=countDisplayText"
                },
                controller:
                [
                    "$scope",
                    function($scope) {
                        var action = "/api/bsl/get?bslendpoint=";

                        $http.get(action + encodeURIComponent($scope.bslEndpoint))
                            .then(function(result) {
                                $scope.countInfo = result.data.BslResponse.Count;
                            });
                    }
                ],
                template: "{{countInfo}}"
            }
        }
    ]);
