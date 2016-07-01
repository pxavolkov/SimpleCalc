(function () {

    'use strict';

    function mainController($scope, mainService) {
        $scope.allOperations = new Array();
        
        //initialize model and dictionary of operations
        $scope.init = function () {
            //load all possible operations
            mainService.getOperations()
                .success(function (response) {
                    $scope.allOperations = response;
                });

            $scope.clear();
        };

        //clear model
        $scope.clear = function() {
            $scope.currentExpr = "0";
            $scope.operand = 0;
            $scope.result = 0;
            $scope.resultConverted = 0;
            $scope.operation = null;
        };

        //reaction to action button click
        $scope.action = function(sign) {
            if ($scope.operation === null) {
                $scope.result = $scope.operand;
                $scope.operand = 0;
                $scope.currentExpr = $scope.result + sign;
            }
            //if operation is already started - complete it
            else {
                $scope.eq(sign);
            }
                        
            $scope.operation = $scope.allOperations[sign];
        };

        //complete operation
        $scope.eq = function(newSign) {
            if ($scope.operation === null)
                return;
            
            mainService.calculate($scope.result, $scope.operand, $scope.operation)
                .success(function (response) {
                    $scope.result = response;
                    //add sign to current expression if this parameter is present
                    $scope.currentExpr = $scope.result + (newSign ? newSign : "");
                })
                //placeholder for error handling
                .error(function () {
                    alert("Error while calculate");
                });
            $scope.operand = 0;
            $scope.operation = null;
        };

        //call conversion service
        $scope.convert = function() {
            mainService.convert($scope.result, "USD", "GBP")
                .success(function (response) {
                    $scope.resultConverted = response;
                })
                .error(function () {
                    alert("Error while conversion");
                });
        };

        $scope.init();
    };

    mainController.$inject = ['$scope', 'mainService'];
    angular.module('CalcApp').controller('mainController', mainController);
})();