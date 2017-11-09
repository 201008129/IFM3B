/// <reference path="angular.js" />
/// <reference path="angular-chart.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-chart.min.js" />

BASE_URL = "http://localhost:57567/GameService.svc/";
LOG_BASE_URL = "http://localhost:57567/LogService.svc/";
var app;
//Module  
(function () {
    app = angular.module("GameList_App", []);
})();

app.controller("cntrl_GameList", function ($scope, SoccerList, CricketList, RugbyList) {

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
//Fixture Controller
app.controller("cntrl_FixtureList", function ($scope, GameFxtureList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = GameFxtureList.get();
    $scope.games = [];
    promiseGet1.then(function (pl) {
        $scope.games = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
//GameLogList
app.controller("cntrl_LogList", function ($scope, GameLogList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = GameLogList.get();
    $scope.teams = [];
    promiseGet1.then(function (pl) {
        $scope.teams = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
//Game Stats by league ID
app.controller("cntrl_GameStats", function ($scope, GameStats) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = GameStats.get();
    $scope.gameStats = [];
    promiseGet1.then(function (pl) {
        $scope.gameStats = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
//SERVICE================================================================
//Soccer List
app.service("SoccerList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGamesByCat/Soccer");
    };
});

//Cricket List
app.service("CricketList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGamesByCat/Cricket");
    };
});

//Rugby List
app.service("RugbyList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGamesByCat/Rugby");
    };
});

//Fixture League
app.service("GameFxtureList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGamesByLeagueID/" + getUrlParameter('L_ID'));
    };
});

//League Log Service 
//L_ID
app.service("GameLogList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(LOG_BASE_URL + "GetLogByLeagueID/" + getUrlParameter('L_ID'));
    };
});

//Game Stats Service by lleague ID 
//L_ID
app.service("GameStats", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGameStatByLeagueID/" + getUrlParameter('L_ID'));
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
