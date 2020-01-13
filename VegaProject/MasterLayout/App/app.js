(function () {
    'use strict';
    angular
        .module('app', [
              'ngRoute'
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/', {
                    controller: 'roleCtr',
                    templateUrl: '/app/templates/Roles.html'
                })

            $routeProvider
                .when('/addroles', {
                    controller: 'roleAddCtr',
                    templateUrl: '/app/templates/addRoles.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();