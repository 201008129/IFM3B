<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="TeamManagement.aspx.cs" Inherits="SportsManagementSystem.TeamManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/TeamManagement.js"></script>

    <!-- page content -->
    <div class="right_col" role="main" ng-app="TeamManagement_App" ng-controller="cntrl_TeamManagement">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Team Management</h3>
                </div>

                <div class="title_right">
                    <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Search" />
                        </div>
                    </div>
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
                                            <th class="column-title">Team Name </th>
                                            <th class="column-title">Team Logo </th>
                                            <th class="column-title">Edit </th>
                                            <th class="bulk-actions" colspan="4">
                                                <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <tr class="even pointer" ng-repeat="tm in teams">
                                            <td class="a-center ">{{tm.s_ID}}</td>
                                            <td class=" ">{{tm.TeamName}}</td>
                                            <td class=" ">
                                                <ul class="list-inline">
                                                    <li>
                                                        <img src="{{tm.ImagePath}}" class="avatar" alt="Avatar" /></li>
                                                </ul>
                                            </td>
                                            <td>
                                                <a href="ViewTeam.aspx?SportID={{tm.s_ID}}" class="btn btn-primary btn-xs"><i class="fa fa-folder-o"></i>View </a>
                                                <a href="UpdateTeam.aspx?SportID={{tm.s_ID}}" class="btn btn-info btn-xs"><i class="fa fa-pencil-square-o"></i>Edit </a>
                                                <a href="DeleteTeam.aspx?SportID={{tm.s_ID}}" class="btn btn-danger btn-xs"><i class="fa fa-trash-o"></i>Delete </a>
                                                <a href="Statistics.aspx?SportID={{tm.s_ID}}" class="btn btn-info btn-xs"><i class="fa fa-bar-chart-o"></i>View Stats </a>
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
