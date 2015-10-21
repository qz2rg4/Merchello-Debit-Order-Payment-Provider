(function () {
    angular.module('merchello.plugins.DebitOrder',
        [
            'merchello.models'
        ]);

    angular.module('merchello.plugins').requires.push('merchello.plugins.DebitOrder');
}());