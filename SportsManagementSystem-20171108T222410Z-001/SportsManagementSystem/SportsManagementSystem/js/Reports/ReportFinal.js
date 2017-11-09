
/// <reference path="angular.js" />
/// <reference path="angular-chart.js" />
/// <reference path="Chart.js" />
/// <reference path="Chart.min.js" />



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

app.controller("pieCtrl_AccPerCampus", function ($scope, countPerCampus) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = countPerCampus.get();

    $scope.NumCampData = [];

    promiseGet1.then(function (pl) {
        $scope.NumCampData = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G

//Controllers
// Guest Checkins
app.controller("lineCtrl_CheckedGuest", function ($scope, InterVal_One, InterVal_Two, InterVal_Three, InterVal_Four) {
    //GetNumberOfCheckedGuest(string ev)


    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
    };

    // debugger;
    var promiseGet1 = InterVal_One.get();
    var promiseGet2 = InterVal_Two.get();
    var promiseGet3 = InterVal_Three.get();
    var promiseGet4 = InterVal_Four.get();

    $scope.Int_One = [];
    $scope.Int_Two = [];
    $scope.Int_Three = [];
    $scope.Int_Four = [];
    $scope.Hourly = [];

    promiseGet1.then(function (pl) {
        $scope.Int_One = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    promiseGet2.then(function (pl) {
        $scope.Int_Two = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.Int_Three = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    promiseGet4.then(function (pl) {
        $scope.Int_Four = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    $scope.series = ['UncheckedGuest', 'CheckedGuest'];
});//G

//Overall Impression Controller
app.controller("RadarCtrl_OverallSatis", function ($scope, Overall_Satisfation) {
    $scope.labels = ["Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied"];

    $scope.options = {
        title: {
            display: true,

        }
    };

    var promiseGet1 = Overall_Satisfation.get();
    $scope.Satisfaction_Data = [];

    promiseGet1.then(function (pl) {
        $scope.Satisfaction_Data = pl.data;
    },
             function (errorPl) {
                 $log.error('failure loading features', errorPl);
             });
});//N


//First time vs Returning attendees
app.controller("pieCtrl_GuestsVisits", function ($scope, GuestVisitsStatus) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = GuestVisitsStatus.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Future ATTENDANCE posibility
app.controller("pieCtrl_FutureAttendance", function ($scope, gstFutureAttendance) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = gstFutureAttendance.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G
//Recommendations posibility
app.controller("pieCtrl_Recommend", function ($scope, gstRecommendation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = gstRecommendation.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G

//Date Status from survey
app.controller("BarCtrl_Date", function ($scope, gstDate_Satisfation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    //max: $scope.APK,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = gstDate_Satisfation.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

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
});

//AdminLeagueStats
//AllLeagueStats
//lineCtrl_FoodvsVendor
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

    $scope.data = [[res[0].Wins, reares[1].Wins, res[2].Wins, res[3].Wins, res[4].Wins], [res[0].Lose, res[1].Lose, res[2].Lose, res[3].Lose, res[4].Lose], [res[0].Draws, res[1].Draws, res[2].Draws, res[3].Draws, res[4].Draws]];
    $scope.labels = [res[0].LeagueName, res[1].LeagueName, res[2].LeagueName, res[3].LeagueName, res[4].LeagueName];
    $scope.series = ['Wins', 'Lose','Draws'];
});//G



//League Stats
//AllLeagueStats
//lineCtrl_FoodvsVendor
app.controller("lineCtrl_AllLeagueStats", function ($scope, AllLeagueStats) {


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
    var promiseGet1 = AllLeagueStats.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    $scope.data = [[res[0].Wins, reares[1].Wins, res[2].Wins, res[3].Wins, res[4].Wins], [res[0].Lose, res[1].Lose, res[2].Lose, res[3].Lose, res[4].Lose], [res[0].Draws, res[1].Draws, res[2].Draws, res[3].Draws, res[4].Draws]];
    $scope.labels = [res[0].LeagueName, res[1].LeagueName, res[2].LeagueName, res[3].LeagueName, res[4].LeagueName];
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

//SERVICE
//Game Yellow Cards
app.service("YellowCards", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('gameID') + ",YellowCards");
    };
});

//Game Red Cards
app.service("RedCards", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('gameID') + ",RedCards");
    };
});

//Game Fouls
app.service("GameFouls", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('gameID') + ",Fouls");
    };
});

//Game Position
app.service("GamePosition", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('gameID') + ",Position");
    };
});

//Game Coner Kicks
app.service("CornerKick", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('gameID') + ",CornerKicks");
    };
});

// Goals scored in a game
app.service("Goals", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "gt_GameStats/" + getUrlParameter('gameID') + ",GoalsScored");
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

