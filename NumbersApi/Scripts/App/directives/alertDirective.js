"use strict";

app.directive("ssAlert", function (alertService) {
    return {
        restrict: 'A',
        templateUrl: "Scripts/app/directives/templates/alertTemplate.html",
        transclude: true,
        scope: {},
        controller: function ($scope) {
            $scope.alert = alertService;
        }
    };
});
