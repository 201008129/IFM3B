/// <reference path="../../scripts/AAF/angular.min.js" />
/// <reference path="../scripts/AAF/Chart.min.js" />
/// <reference path="../scripts/AAF/angular-chart.min.js" />

var BASE_URL = "http://localhost:57567/ReportService.svc/";
var app;

//Module  
(function () {
    app = angular.module("reportsModule", ['chart.js']);
})();

//Config
app.config(['ChartJsProvider', function (ChartJsProvider) {
    // Configure all charts 
    ChartJsProvider.setOptions({
        chartColors: ["#455C73", "#9B59B6", "#BDC3C7", "#26B99A"],
        responsive: true,
        scales: { yAxes: [{ ticks: { min: 0, stepSize: 1 } }] }

    });
}]);

//League Overall Best Player
//LeagueBestPlayer
//BarCtrl_Location
app.controller("BarCtrl_LeagueBestPlayer", function ($scope, LeagueBestPlayer) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = LeagueBestPlayer.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

   
});

//League Overall Best Performing Team
//BarCtrl_LeagueBestTeam
app.controller("BarCtrl_LeagueBestTeam", function ($scope, BestPerformingTeams) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = BestPerformingTeams.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    $scope.series = ['Average','Team Manager'];
});

//Rank Players
//LeagueBestGoalScorer
//BarCtrl_Location
app.controller("BarCtrl_Ranks", function ($scope, HighestPlayerRanking) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = HighestPlayerRanking.get();
    $scope.res = [];
    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });


    $scope.series = ['Player Average', 'Performance'];
    
});

//Team Average
app.controller("BarCtrl_TeamAve", function ($scope, OveralTeamPerformance) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = OveralTeamPerformance.get();
    $scope.res = [];
    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });


    $scope.series = ['Team Average'];

});

//League Overall Best Player
//LeagueBestGoalScorer
//BarCtrl_Location
app.controller("BarCtrl_LeagueBestGoalScorer", function ($scope, LeagueBestGoalScorer) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = LeagueBestGoalScorer.get();
    $scope.res = [];
    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });


    $scope.series = ['Goals', 'Performance'];
    
});

//AdminLeagueStats
//AllLeagueStats
app.controller("lineCtrl_AdminLeagueStats", function ($scope, AdminLeagueStats) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    stepSize: 0
                }
            }]
        }
    };
    //key-value pair
    // debugger;
    var promiseGet1 = AdminLeagueStats.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    //$scope.data = [[$scope.res[0], $scope.res[1], $scope.res[2], $scope.res[3], $scope.res[4]], [$scope.res[0], $scope.res[1], $scope.res[2], $scope.res[3], $scope.res[4]], [$scope.res[0], $scope.res[1], $scope.res[2], $scope.res[3], $scope.res[4]]];
  //  $scope.labels = [$scope.res[0], $scope.res[1], $scope.res[2], $scope.res[3],$scope.res[4]];
    $scope.series = ['Wins', 'Lose', 'Draws'];
});
app.controller("pieCtrl_YellowCards", function ($scope, YellowCards) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = YellowCards.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_RedCards", function ($scope, RedCards) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = RedCards.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_GameFouls", function ($scope, GameFouls) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = GameFouls.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_GamePosition", function ($scope, GamePosition) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = GamePosition.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_CornerKick", function ($scope, CornerKick) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = CornerKick.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_Goals", function ($scope, Goals) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = Goals.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//SERVICE==============================================================================
//Game Yellow Cards
app.service("YellowCards", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",YellowCards");
    };
});
//Game Red Cards
app.service("RedCards", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",RedCards");
    };
});
//Game Fouls
app.service("GameFouls", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",Fouls");
    };
});
//Game Position
app.service("GamePosition", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",Position");
    };
});
//Game Coner Kicks
app.service("CornerKick", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",CornerKicks");
    };
});
// Goals scored in a game
app.service("Goals", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",GoalsScored");
    };
});
//League Overal Best Player
app.service("LeagueBestPlayer", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_LeagueBestPlayer/" + getUrlParameter('leageID') + ",Average");
    };
});
//League Best Goal Scorer
app.service("LeagueBestGoalScorer", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_LeagueBestPlayer/" + getUrlParameter('leageID') + ",Goals");
    };
});
//League stats for specific admin
app.service("AdminLeagueStats", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_LeaguesStatsForAdmin/" + getUrlParameter('leageID'));
    };
});
//get all leagues statistics
app.service("AllLeagueStats", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_LeaguesStats");
    };
});
//get 5 top performing Teams in the league
app.service("BestPerformingTeams", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_LeagueBestTeam/" + getUrlParameter('leageID'));
    };
});

//top 10 highest ranking players in a team
app.service("HighestPlayerRanking", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_PlayerRanking/" + getUrlParameter('SportID'));
    };
});

//Team average for every league involved in
app.service("OveralTeamPerformance", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_TeamAverage/" + getUrlParameter('SportID'));
    };
});


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