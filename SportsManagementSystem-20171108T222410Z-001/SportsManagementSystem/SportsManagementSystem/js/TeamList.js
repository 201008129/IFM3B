/// <reference path="angular.js" />
/// <reference path="angular.min.js" />
/// <reference path="Chart.min.js" />


BASE_URL = "http://localhost:57567/TeamService.svc/";
LEAGUE_BAE_URL = "http://localhost:57567/LeagueService.svc/";
var app;
//Module  
(function () {
    app = angular.module("TeamList_App", []);
})();

app.controller("cntrl_TeamList", function ($scope, SoccerList, CricketList, RugbyList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };


    // debugger;
    var promiseGet1 = SoccerList.get();
    $scope.soccer = [];
    promiseGet1.then(function (pl) {
        $scope.soccer = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    var promiseGet1 = RugbyList.get();
    $scope.rugby = [];
    promiseGet1.then(function (pl) {
        $scope.rugby = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    var promiseGet1 = CricketList.get();
    $scope.cricket = [];
    promiseGet1.then(function (pl) {
        $scope.cricket = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});



//Soccer List
app.service("SoccerList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAllTeamByCategory/Soccer");
    };
});

//Cricket List
app.service("CricketList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAllTeamByCategory/Cricket");
    };
});

//Rugby List
app.service("RugbyList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAllTeamByCategory/Rugby");
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