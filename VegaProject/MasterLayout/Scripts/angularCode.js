var app = angular.module("DemoApp", []);

app.controller("SecurityRoleController", function ($scope, $http) {
    $scope.InsertData = function () {
        var action = document.getElementById("btnSave").getAttribute("value");
        if (action == "Submit") {
            debugger;
            $scope.Security = {};
            $scope.Security.Role = $scope.Role;
             $http({
                method: "post",
                 url: "http://localhost:58282/SecurityRole/Insert_Role",
                datatype: "json",
                data: JSON.stringify($scope.Dept)
            }).then(function (response) {
                $scope.GetAllData();
                $scope.Role = "";
               

            }, function () {
                alert("Error Occur");
            });
        }
        else {
            debugger;
            $scope.Security = {};
            $scope.Security.Role = $scope.Role;
            $scope.Security.Id = document.getElementById("RoleID_").value;
            console.log($scope.Security.Id);
            $http({
                method: "post",
                url: "http://localhost:58282/SecurityRole/Update_Role",
                datatype: "json",
                data: JSON.stringify($scope.Security)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Security.Role ="";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Role Details";
            }, function () {
                alert("Error Occur");
            })

        }
    }

    //This is for fetching data from database.
    $scope.GetAllData = function () {
        //debugger;
        $http({
            method: "get",
            url: "/SecurityRole/Get_AllRole"
        }).then(function (response) {
            $scope.Securities = response.data;
            console.log(response.data);
        }, function () {
            alert("Error Occur");
        })

    };

    //This is for deleting the record.
    $scope.DeleteDept = function (Dept) {
        $http({
            method: "post",
            url: "http://localhost:51374/Dept/Delete_Dept",
            datatype: "json",
            data: JSON.stringify(Dept)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        }, function () {
            alert("Error Occur");
        })
    };


    //This is for selecting record on clicking particular record.
    $scope.UpdateDept = function (Security) {
        debugger;
        document.getElementById("RoleID_").value = Security.Id;
        $scope.Role = Security.Role;
         
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";

    };

});

//var app = angular.module("myApp", []);
//app.controller("myCtrl", function ($scope, $http) {
//    debugger;
  
//    $scope.InsertData = function () {
//        $scope.btnText = "Please Wait";
//        $http({
//            method: "post",
//            url: "/SecurityRole/Insert_Role",
//            data: $scope.SecurityRoleModel
//        }).success(function () {
//            $scope.btnText = "Save";
//            $scope.SecurityRoleModel = null;
//        }).error(function () {
//            alert("failed");
//        });
//    }
//    $scope.GetAllData = function () {
//        $http({
//            method: "get",
//            url: "/SecurityRole/Get_AllRole"
//        }).then(function (response) {
//            $scope.SecurityRoleModel = response.data;
//        }, function () {
//            alert("Error Occur");
//        });
//    }
//});
    //$scope.InsertData = function () {
    //    var Action = document.getElementById("btnSave").getAttribute("value");
    //    if (Action == "Submit") {
    //        $scope.roles = {};
    //        $scope.roles.Role = $scope.RoleName;
    //        $scope.roles.IsInactive = $scope.RoleIsInactive;
    //       $http({
    //            method: "post",
    //           url: "/SecurityRole/Insert_Employee",
    //            datatype: "json",
    //           data: JSON.stringify($scope.SecurityRoleModel)
    //        }).then(function (response) {
    //            alert(response.data);
    //            $scope.GetAllData();
    //            $scope.RoleName = "";
    //            $scope.RoleIsInactive = "";
    //         })
    //    } else {
    //        $scope.Role = {};
    //        $scope.Role.Role = $scope.RoleName;
    //        $scope.Role.IsInactive = $scope.RoleIsInactive;
    //        $scope.Role.Id = document.getElementById("RoleID_").value;
    //        $http({
    //            method: "post",
    //            url: "/SecurityRole/ Edit",
    //            datatype: "json",
    //            data: JSON.stringify($scope.SecurityRoleModel)
    //        }).then(function (response) {
    //            alert(response.data);
    //            $scope.GetAllData();
    //            $scope.RoleName = "";
    //            $scope.RoleIsInactive = "";
    //            document.getElementById("btnSave").setAttribute("value", "Submit");
    //            document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
    //            document.getElementById("spn").innerHTML = "Add New Role";
    //        })
    //    }
    //}
  
//    $scope.DeleteEmp = function (Role) {
//        $http({
//            method: "post",
//            url: "/SecurityRole/Delete",
//            datatype: "json",
//            data: JSON.stringify(Emp)
//        }).then(function (response) {
//            alert(response.data);
//            $scope.GetAllData();
//        })
//    };
//    $scope.UpdateEmp = function (Role) {
//        document.getElementById("RoleID_").value = Role.Id;
//        $scope.RoleName = Role.Role;
//        $scope.RoleIsInactive = Role.RoleIsInactive;
//        document.getElementById("btnSave").setAttribute("value", "Update");
//        document.getElementById("btnSave").style.backgroundColor = "Yellow";
//        document.getElementById("spn").innerHTML = "Update Role Information";
//    }
//})  