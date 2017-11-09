<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="ViewGameStats.aspx.cs" Inherits="SportsManagementSystem.ViewGameStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="scripts/AAF/angular.min.js"></script>
    <script src="scripts/AAF/Chart.min.js"></script>
    <script src="scripts/AAF/angular-chart.min.js"></script>
    <script src="scripts/scripts/GameStatsReport.js"></script>

    <!-- page content -->
        <div class="right_col" role="main" ng-app ="My_GameStats_Report">
        <div class="" >
            <div class="page-title">
                <div class="title_left">
                    <h2>Game Statistics</h2>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="row" ng-controller="cntrl_MyGameStats">
                <div class="col-md-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <!-- start Log list -->
                            <table class="table table-striped projects">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody ng-repeat="stat in games">
                                    <tr>
                                        <td>
                                            <ul class="list-inline">
                                                <li>
                                                    <img src="{{stat.TeamOneImage}}" class="avatar" alt="Avatar" />
                                                </li>
                                            </ul>
                                        </td>
                                        <td>{{stat.TeamOne}}</td>
                                        <td>VS</td>
                                        <td>{{stat.TeamTwo}}</td>
                                        <td>
                                            <ul class="list-inline">
                                                <li>
                                                    <img src="{{stat.TeamTwoImage}}" class="avatar" alt="Avatar" />
                                                </li>
                                            </ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>{{stat.TeamOneGoals}}</td>
                                        <td>Final Score</td>
                                        <td>{{stat.TeamTwoGoals}}</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>{{stat.TeamOnePos}}</td>
                                        <td>Position</td>
                                        <td>{{stat.TeamTwoPos}}</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>{{stat.TeamOneAverage}}</td>
                                        <td>Overal Average</td>
                                        <td>{{stat.TeamTwoAverage}}</td>
                                        <td></td>
                                    </tr>
                                      <tr>
                                        <td></td>
                                        <td>Best Player</td>
                                        <td>{{stat.BestPlayer}}</td>
                                        <td></td>
                                    </tr>
                                </tbody>
                            </table>
                            <!-- end Log list -->
                            
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>

              <%-- Reports For Game --%>

            <div class="row">
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Game Position</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="pieCtrl_GamePosition">
                            <canvas id="pie2" class="chart chart-doughnut"
                                chart-data="[res[0],res[1]]" chart-labels="['Team One','Team Two']" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Goals Scored</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="pieCtrl_Goals">
                            <canvas id="pie2" class="chart chart-doughnut"
                                chart-data="[res[0],res[1]]" chart-labels="['Team One','Team Two']" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Corner Kicks</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="pieCtrl_CornerKick">
                            <canvas id="pie2" class="chart chart-doughnut"
                                chart-data="[res[0],res[1]]" chart-labels="['Team One','Team Two']" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Yellow Cards</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="pieCtrl_YellowCards">
                            <canvas id="pie3" class="chart chart-pie"
                                chart-data="[res[0],res[1]]" chart-labels="['Team One','Team Two']" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Red Cards</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="pieCtrl_RedCards">
                            <canvas id="pie2" class="chart chart-pie"
                                chart-data="[res[0],res[1]]" chart-labels="['Team One','Team Two']" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>

                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Fouls</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content" ng-controller="pieCtrl_GameFouls">
                            <canvas id="pie2" class="chart chart-pie"
                                chart-data="[res[0],res[1]]" chart-labels="['Team One','Team Two']" chart-options="options"></canvas>
                        </div>
                    </div>
                </div>

            </div>



        </div>
    </div>

    <!-- /page content -->
</asp:Content>
