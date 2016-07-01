(function () {

    'use strict';

    //service is used for service interactions
    function mainService($http) {
        var urls = {
            calculation: 'api/Calculation',
            convertion: 'api/Conversion'
        };

        return {
            calculate: function(operandA, operandB, operation) {
                return $http.post(urls.calculation, { OperandA: operandA, OperandB: operandB, Operation: operation });
            },
            convert: function(amount, fromCurrency, toCurrency) {
                return $http.get(urls.convertion, { params: { Amount: amount, FromCurrency: fromCurrency, ToCurrency: toCurrency } });
            },
            getOperations: function () {
                return $http.get(urls.calculation);
            }
        }
    }

    mainService.$inject = ['$http'];
    angular.module('CalcApp').service('mainService', mainService);
})();