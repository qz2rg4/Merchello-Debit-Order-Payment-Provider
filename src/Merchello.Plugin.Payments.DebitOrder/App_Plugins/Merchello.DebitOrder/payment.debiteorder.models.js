(function () {

    var DebitOrderProviderSettings = function () {
        var self = this;
        self.DebitOrderNumberPrefix = '';
    };

    angular.module('merchello.plugins.DebitOrder').constant('DebitOrderProviderSettings', DebitOrderProviderSettings);

    angular.module('merchello.plugins.DebitOrder').factory('DebitOrderProviderSettingsBuilder',
        ['genericModelBuilder', 'DebitOrderProviderSettings',
        function (genericModelBuilder, DebitOrderProviderSettings) {

            var Constructor = DebitOrderProviderSettings;

            return {
                createDefault: function () {
                    var settings = new Constructor();
                    return settings;
                },
                transform: function (jsonResult) {
                    var settings = genericModelBuilder.transform(jsonResult, Constructor);
                    return settings;
                }
            };
        }]);
}());