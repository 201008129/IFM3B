﻿/// <reference path="angular.js" />
/// <reference path="angular-chart.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-chart.min.js" />

BASE_URL = "http://localhost:57567/TeamService.svc/";
var app;
//Module  
(function () {
    app = angular.module("TeamManagement_App", []);
})();

app.controller("cntrl_TeamManagement", function ($scope,TeamList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    var promiseGet1 = TeamList.get();
    $scope.teams = [];
    promiseGet1.then(function (pl) {
        $scope.teams = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//SERVICE================================================================

//Get Managers Teams
app.service("TeamList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getTeamsByUserID/" + getUrlParameter('UserID'));
    };
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
