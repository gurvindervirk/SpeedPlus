(function () {
    'use strict';
    angular
        .module('app')
        .controller('roleCtr', ['$scope', 'dataServices', function ($scope, dataServices) {
            $scope.SecurityRoleModel = [];
            getData();
            function getData() {
                dataServices.getRoles().then(function (result) {
                    $scope.roles = result;
                });
            }
        }])

    //Controller RoleCreation
    .controller('roleAddCtr', ['$scope', '$location', 'dataServices', function ($scope, $location, dataServices) {
        $scope.createRoles = function (SecurityRoleModel) {
            dataServices.addRoles(SecurityRoleModel).then(function () {
                 $location.path('/');
             });
         }
      }]);
})();

//.controller('roleAddCtr', ['$scope', '$location', 'dataServices', function ($scope, $location, dataServices) {
     //    $scope.createRole = function (role) {
     //        dataServices.addRoles(role).then(function () {
     //            $location.path('/');
     //        });
     //    }
     // }]);