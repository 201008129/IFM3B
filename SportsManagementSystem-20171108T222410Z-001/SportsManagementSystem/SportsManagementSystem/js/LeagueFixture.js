﻿/// <reference path="angular.js" />
/// <reference path="angular-chart.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-chart.min.js" />

BASE_URL = "http://localhost:57567/GameService.svc/";
var app;
//Module  
(function () {
    app = angular.module("MyGameFixture_App", []);
})();

app.controller("cntrl_MyGameFixture", function ($scope, MyGameFixture) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = MyGameFixture.get();
    $scope.games = [];
    promiseGet1.then(function (pl) {
        $scope.games = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
//SERVICE================================================================
//Upcoming Games Service by lleague ID 
//L_ID || Fixture
app.service("MyGameFixture", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGamesByLeagueID/" + getUrlParameter('L_ID'));
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
