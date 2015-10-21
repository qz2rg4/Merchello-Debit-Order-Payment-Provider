/**
 * @ngdoc controller
 * @name Merchello.Plugin.GatewayProviders.Payments.Dialogs.DebitOrderGatewayProviderController
 * @function
 * 
 * @description
 * The controller for managing the Purchase Order Settings on the Gateway Providers page
 */
angular.module('merchello.plugins.DebitOrder').controller('Merchello.Plugin.GatewayProviders.Payments.Dialogs.DebitOrderGatewayProviderController',
    ['$scope', 'DebitOrderProviderSettingsBuilder',
        function ($scope, DebitOrderProviderSettingsBuilder) {

            $scope.DebitOrderSettings = {};

            /**
           * @ngdoc method 
           * @name init
           * @function
           * 
           * @description
           * Method called on intial page load.  Loads in data from server and sets up scope.
           */
            function init() {
                var json = JSON.parse($scope.dialogData.provider.extendedData.getValue('DebitOrderProcessorSettings'));
                $scope.DebitOrderSettings = DebitOrderProviderSettingsBuilder.transform(json);

                $scope.$watch(function () {
                    return $scope.DebitOrderSettings;
                }, function (newValue, oldValue) {
                    $scope.dialogData.provider.extendedData.setValue('DebitOrderProcessorSettings', angular.toJson(newValue));
                }, true);
            }

            // initialize the controller
            init();

        }]);