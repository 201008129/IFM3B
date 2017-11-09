<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="SportsManagementSystem.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="scripts/AAF/angular.min.js"></script>
    <script src="scripts/AAF/Chart.min.js"></script>
    <script src="scripts/AAF/angular-chart.min.js"></script>
    <script src="scripts/scripts/ReportFinal.js"></script>

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="" ng-app="reportsModule">
            <div class="page-title">
                <div class="title_left">
                    <h2>Statistics</h2>
                </div>
            </div>
            <div class="clearfix"></div>
            <%-- Manager Reports --%>
            <div class="row" id="ManagerReports" runat="server">
                <%-- Overal Team Average (Every League) --%>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Overal Team Average (Every League)</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="BarCtrl_TeamAve">
                            <canvas id="Bar" class="chart chart-bar" chart-data="[[res[0].Average,res[1].Average,res[2].Average,res[3].Average,res[4].Average]]"
                                chart-labels="[res[0].LeagueName, res[1].LeagueName,res[2].LeagueName,res[3].LeagueName,res[4].LeagueName]" chart-series="series" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>

                <%-- 5 Highest Ranked Players --%>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>5 Highest Ranked Players</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="BarCtrl_Ranks">
                            <canvas id="Bar" class="chart chart-Bar" chart-data="[[res[0].Average,res[1].Average,res[2].Average,res[3].Average,res[4].Average]]"
                                chart-labels="[res[0].Name, res[1].Name,res[2].Name,res[3].Name,res[4].Name]" chart-series="series" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>
            </div>


            <%-- Administrator Reports --%>
            <div class="" id="AdminReports" runat="server">
                <div class="row">
                    <%-- Leagues 5 top performing teams --%>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Leagues 5 top performing teams</h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content" ng-controller="BarCtrl_LeagueBestTeam">
                                <canvas id="line" class="chart chart-Bar" chart-data="[[res[0].Average,res[1].Average,res[2].Average,res[3].Average,res[4].Average]]"
                                    chart-labels="[res[0].Name, res[1].Name,res[2].Name,res[3].Name,res[4].Name]" chart-series="series" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>

                    <%-- Top 5 League Stats --%>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Top 5 League Stats</h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content" ng-controller="lineCtrl_AdminLeagueStats">
                                <canvas id="line" class="chart chart-line" chart-data="[[res[0].Wins,res[1].Wins,res[2].Wins,res[3].Wins,res[4].Wins],[res[0].Lose,res[1].Lose,res[2].Lose,res[3].Lose,res[4].Lose],[res[0].Draws,res[1].Draws,res[2].Draws,res[3].Draws,res[4].Draws]]"
                                    chart-labels="[res[0].LeagueName, res[1].LeagueName,res[2].LeagueName,res[3].LeagueName,res[4].LeagueName]" chart-series="series" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row">
                    <%-- League Top 5 Overal Best Players --%>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>League Top 5 Overal Best Players</h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content" ng-controller="BarCtrl_LeagueBestGoalScorer">
                                <canvas id="line" class="chart chart-bar" chart-data="[[res[0].Goals,res[1].Goals,res[2].Goals,res[3].Goals,res[4].Goals],[res[0].Average,res[1].Average,res[2].Average,res[3].Average,res[4].Average,]]"
                                    chart-labels="[res[0].Name,res[1].Name,res[2].Name,res[3].Name,res[4].Name]" chart-series="series" chart-options="options"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- page content -->

</asp:Content>
