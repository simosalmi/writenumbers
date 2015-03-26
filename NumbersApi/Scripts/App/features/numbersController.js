"use strict";

app.controller('numbersController', ['$scope', 'numbersService', 'alertService', function numbersController($scope, numbersService, alertService) {

    $scope.numberToWrite = {
        value: null,
        cultureName: 'en-Gb',
        allowCultureFallback: false
    };

    $scope.sendNumber = function (e) {
        
        numbersService.writeNumber($scope.numberToWrite).then(function (data) {
            alertService.show('success', $scope.numberToWrite.value, data.value);
        }, function (err) {
            alertService.show('danger', 'Error', err.data.message);
            
        });
    };
}]);