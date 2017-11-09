<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="GeneralGameStats.aspx.cs" Inherits="SportsManagementSystem.GeneralGameStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/GameStats.js"></script>
    <!-- page content -->
        <div class="right_col" role="main" ng-app ="MyGameStats_App">
        <div class="" ng-controller="cntrl_MyGameStats">
            <div class="page-title">
                <div class="title_left">
                    <h3>View Game Stats</h3>
                </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
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
                                        <td>{{stat.TeamOnePos}}</td>
                                        <td>Position</td>
                                        <td>{{stat.TeamTwoPos}}</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>{{stat.TeamOneFouls}}</td>
                                        <td>Fouls</td>
                                        <td>{{stat.TeamTwoFouls}}</td>
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
        </div>
    </div>
    <!-- /page content -->

</asp:Content>
