/// <reference path="angular.js" />
/// <reference path="angular-chart.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-chart.min.js" />

BASE_URL = "http://localhost:57567/EmpService.svc/";

var app;
//Module  
(function () {
    app = angular.module("ServiceApp", []);
})();

app.controller("cntrl_Service", function ($scope, crudService) {

    $scope.IsNewRecord = 1; //The flag for the new record

    loadRecords();

    //Function to load all Employee records
    function loadRecords() {
        var promiseGet = crudService.getEmployees(); //The MEthod Call from service

        promiseGet.then(function (pl) { $scope.Employees = pl.data },
              function (errorPl) {
                  $log.error('failure loading Employee', errorPl);
              });
    }



    //The Save scope method use to define the Employee object.
    //In this method if IsNewRecord is not zero then Update Employee else 
    //Create the Employee information to the server
    $scope.save = function () {
        var Employee = {
            EmpNo: $scope.EmpNo,
            EmpName: $scope.EmpName,
            Salary: $scope.Salary,
            DeptName: $scope.DeptName,
            Designation: $scope.Designation
        };
        //If the flag is 1 the it si new record
        if ($scope.IsNewRecord === 1) {
            var promisePost = crudService.post(Employee);
            promisePost.then(function (pl) {
                $scope.EmpNo = pl.data.EmpNo;
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        } else { //Else Edit the record
            var promisePut = crudService.put(Employee);
            promisePut.then(function (pl) {
                $scope.Message = "Updated Successfuly";
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        }



    };

    //Method to Delete
    $scope.delete = function () {
        var promiseDelete = crudService.delete($scope.EmpNo);
        promiseDelete.then(function (pl) {
            $scope.Message = "Deleted Successfuly";
            $scope.EmpNo = 0;
            $scope.EmpName = "";
            $scope.Salary = 0;
            $scope.DeptName = "";
            $scope.Designation = "";
            loadRecords();
        }, function (err) {
            console.log("Err" + err);
        });
    }

    //Method to Get Single Employee based on EmpNo
    $scope.get = function (Emp) {
        var promiseGetSingle = crudService.get(Emp.EmpNo);

        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.EmpNo = res.EmpNo;
            $scope.EmpName = res.EmpName;
            $scope.Salary = res.Salary;
            $scope.DeptName = res.DeptName;
            $scope.Designation = res.Designation;

            $scope.IsNewRecord = 0;
        },
                  function (errorPl) {
                      console.log('failure loading Employee', errorPl);
                  });
    }
    //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope.EmpNo = 0;
        $scope.EmpName = "";
        $scope.Salary = 0;
        $scope.DeptName = "";
        $scope.Designation = "";
    }
});
//Service===============================================================
app.service('crudService', function ($http) {

    BASE_URL = "http://localhost:57567/EmpService.svc/";
    //Create new record
    this.post = function (Employee) {
        var request = $http({
            method: "post",
            url: "http://localhost:57567/EmpService.svc/PostEmployee",
            data: Employee
        });
        return request;
    }
    //Get Single Records
    this.get = function (EmpNo) {
        return $http.get("http://localhost:57567/EmpService.svc/getEmployeeByID/" + EmpNo);
    }

    //Get All Employees
    this.getEmployees = function () {
        return $http.get("http://localhost:57567/EmpService.svc/getAllEmployee");
    }


    //Update the Record
    this.put = function (EmpNo, Employee) {
        var request = $http({
            method: "put",
            url: "http://localhost:57567/EmpService.svc/PutEmployee/",
            data: Employee
        });
        return request;
    }
    //Delete the Record
    this.delete = function (EmpNo) {
        var request = $http({
            method: "delete",
            url: "http://localhost:57567/EmpService.svc/deleteID/" + EmpNo
        });
        return request;
    }

});


//helper functions=====================================================
function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;
    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }
    return res;
}
