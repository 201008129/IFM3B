<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="ViewTeam.aspx.cs" Inherits="SportsManagementSystem.ViewTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/PlayerList.js"></script>
    <!-- page content -->
    <div class="right_col" role="main" ng-app="TeamPlayers_App" ng-controller="cntrl_TeamPlayers">

        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Team Details</h3>
                </div>

                <div class="title_right">
                    <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Search for" />
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">Go!</button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>

            <div class="row" ng-model="team">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">

                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="product-image" runat="server" id="imgDiv">
                                </div>
                            </div>

                            <div class="col-md-5 col-sm-5 col-xs-12" style="border: 0px solid #e5e5e5;">

                                <h3 class="prod_title" runat="server" id="Name"></h3> <br/>
                                 <h4 class="prod_title" runat="server" id="ManagerName"></h4>
                                <p runat="server" id ="Desc"></p>
                                <br /><br/><br /><br/>

                                <div class="x_panel">
                                    <div class="x_title">
                                        <h2>Team  Players</h2>
                                        <ul class="nav navbar-right panel_toolbox">
                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="x_content">
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>First Name</th>
                                                    <th>Position</th>
                                                    <th>Average Performance</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr ng-repeat="player in players">
                                                    <th scope="row">{{player.ID}}</th>
                                                    <td>{{player.Name}}</td>
                                                    <td>{{player.Desc}}</td>
                                                    <td>{{player.PerformanceRate}}</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->


</asp:Content>
