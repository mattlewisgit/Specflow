window.SocialConnectorApp = angular
    .module("SocialConnectorApp", [])
    .directive("popularityCount",
    [
        "$http", function($http) {
            "use strict";
            return {
                restrict: "E",
                scope: {
                    settingsId: "=settingsId",
                    //set the initial count info to Error message
                    countInfo: "=countDisplayText"
                },
                controller: function($scope) {
                    var baseUrl = "/api/socialmedia/";

                    $http.get(baseUrl + 'popularitycounts?settingsid=' + $scope.settingsId)
                        .then(function(result) {
                            $scope.countInfo = result.data.Count;
                        }); // Ignore errors as we have already setup a initial text and logged the error
                },
                template: "{{countInfo}}"
            }
        }
    ]);


