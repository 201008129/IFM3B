<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="GameManagement.aspx.cs" Inherits="SportsManagementSystem.GameManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/GameTable.js"></script>
    <!-- page content -->
    <div class="right_col" role="main" ng-app="GameManagement_App" ng-controller="cntrl_GameManagement">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Game Management</h3>
                </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
                <div class="col-md-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>Teams</h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">

                            <!-- start team list -->
                            <div class="table-responsive">
                                <table class="table table-striped jambo_table bulk_action">
                                    <thead>
                                        <tr class="headings">
                                            <th>#</th>
                                            <th class="column-title">Team One </th>
                                            <th class="column-title">Team Two </th>
                                            <th class="column-title">League Name </th>
                                            <th class="column-title">Edit </th>
                                            <th class="bulk-actions" colspan="4">
                                                <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <tr class="even pointer" ng-repeat="tm in games">
                                            <td class="a-center ">{{tm.G_ID}}</td>
                                            <td class=" ">{{tm.TeamOne}}</td>
                                            <td class=" ">{{tm.TeamTwo}}</td>
                                            <td class=" ">{{tm.LeaguName}}</td>
                                            <td>
                                                <a href="AddGameStats.aspx?G_ID={{tm.G_ID}}&L_ID={{tm.LeagueID}}" class="btn btn-primary btn-xs"><i class="fa fa-pencil-square-o"></i>Add/Edit Stats </a>
                                                <a href="ViewGameStats.aspx?L_ID={{tm.LeagueID}}&G_ID={{tm.G_ID}}" class="btn btn-info btn-xs"><i class="fa fa-bar-chart-o"></i>View Stats </a>
                                                <a href="DeleteGame.aspx?G_ID={{tm.G_ID}}" class="btn btn-danger btn-xs"><i class="fa fa-trash-o"></i>Remove Game </a>
                                                <%--<a href="Statistics.aspx?gameID={{tm.G_ID}}&leageID={{tm.LeagueID}}" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i> View Full Stats </a>--%>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!-- end team list -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->


</asp:Content>
