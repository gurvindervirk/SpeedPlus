(function () {
    'use strict';
    angular
        .module('app').factory('dataServices', ['$http', '$q', function ($http, $q) {
            var service = {};
            service.getRoles = function () {
                var deferred = $q.defer();
                $http.get('/SecurityRole/Index').then(function (result) {
                    deferred.resolve(result.data);
                },
                    function () {
                        deferred.reject();
                    })
                return deferred.promise;
            };

            //Get Role By Id
            service.getRolesById = function (id) {
                var deferred = $q.defer();
                $http.get('/SecurityRole/Details/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            //Create Role
            service.addRoles = function (roles) {
                var deferred = $q.defer();
                $http.post('/SecurityRole/Create', roles).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };
            //Edit Role
            service.editRoles = function (role) {
                var deferred = $q.defer();
                $http.post('/SecurityRole/Edit', role).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };
            //Delete Role
            service.deleteRoles = function (id) {
                var deferred = $q.defer();
                $http.post('/SecurityRole/Delete', { id: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };
                //final block
                return service;
            }]);
 })();
    
//(function () {
//    'use strict';
//        angular
//        .module('app')
//        .factory('dataServices', ['$http', '$q', function ($http, $q) {
//            var service = {};
//            service.getRoles = function () {
//                var deferred = $q.defer();
//                $http.get('/SecurityRole/Index').then(function (result) {
//                    deferred.resolve(result.data);
//                }, function () {
//                    deferred.reject();
//                });
//                return deferred.promise;
//            };
//            return service;
      
//})();
//             //Gell Roles by Id
//            service.getRolesById = function (id) {
//                var deferred = $q.defer();
//                $http.get('/SecurityRole/Details/' + id).then(function (result) {
//                    deferred.resolve(result.data);
//                }, function () {
//                    deferred.reject();
//                });
//                return deferred.promise;
//            };

//            service.addRoles = function (role) {
//                var deferred = $q.defer();
//                $http.post('/SecurityRole/Create', role).then(function () {
//                    deferred.resolve();
//                }, function () {
//                    deferred.reject();
//                    });
//                return deferred.promise;
//            };

//            service.editRoles = function (role) {
//                var deferred = $q.defer();
//                $http.post('/SecurityRole/Edit', role).then(function () {
//                    deferred.resolve();
//                }, function () {
//                    deferred.reject();
//                });
//                return deferred.promise;
//            };

//            service.deleteRoles = function (id) {
//                var deferred = $q.defer();
//                $http.post('/SecurityRole/Delete', { id: id}).then(function () {
//                    deferred.resolve();
//                }, function () {
//                    deferred.reject();
//                });
//                return deferred.promise;
//            };

//            return service;
//        }]);

//})();