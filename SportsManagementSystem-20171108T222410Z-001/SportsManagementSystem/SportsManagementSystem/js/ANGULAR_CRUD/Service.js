/// <reference path="Module.js" />
/// <reference path="../angular.js" />
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
