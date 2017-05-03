window.SocialConnectorApp = angular
    .module("CountdownTimerApp", [])
    .controller("CountdownTimerController",
    [
        "$scope", "$timeout", function($scope, $timeout) {
            "use strict";
            $scope.CountdownFrom = moment.unix(getURLParameter("start")).diff(moment());
            $scope.interval = 1000;
            var queueTick = function() {
                $scope.timer = $timeout(function() {
                        if ($scope.CountdownFrom > 0) {
                            $scope.CountdownFrom -= $scope.interval;

                            if ($scope.CountdownFrom > 0) {
                                queueTick();
                            } else {
                                $scope.CountdownFrom = 0;
                                $scope.active = false;
                            }
                        }
                    },
                    $scope.interval);
            };

            queueTick();

            $scope.$watch("active",
                function(newValue, oldValue) {
                    if (newValue !== oldValue) {
                        if (newValue === true) {
                            if ($scope.CountdownFrom > 0) {
                                queueTick();
                            } else {
                                $scope.active = false;
                            }
                        } else {
                            $timeout.cancel($scope.timer);
                        }
                    }
                });

            var updateTimer = function() {
                $scope.timer = moment($scope.CountdownFrom);
            };
            updateTimer();

            $scope.$watch("CountdownFrom",
                function() {
                    updateTimer();
                });
        }
    ]);
