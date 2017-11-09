
/// <reference path="angular.js" />
/// <reference path="angular-chart.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-chart.min.js" />

BASE_URL = "http://localhost:57567/GameService.svc/";
var app;
//Module  
(function () {
    app = angular.module("GameManagement_App", []);
})();

app.controller("cntrl_GameManagement", function ($scope, GameList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    var promiseGet1 = GameList.get();
    $scope.games = [];
    promiseGet1.then(function (pl) {
        $scope.games = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//SERVICE================================================================

//Get Managers Teams
app.service("GameList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGamesByUserID/" + getUrlParameter('UserID'));
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
//GetAllGamesByUserID