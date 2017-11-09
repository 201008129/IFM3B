<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="LeagueList.aspx.cs" Inherits="SportsManagementSystem.LeagueList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/LeagueList.js"></script>
    <!-- page content -->
        <div class="right_col" role="main" ng-app="MyLeagueList_App" ng-controller="cntrl_MyLeagueList">
          <div class="" >
            <div class="page-title">
              <div class="title_left">
                <h3>League Management</h3>
              </div>

              <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                  
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
                        <th class="column-title">League Name </th>
                        <th class="column-title">League Logo </th>
                        <th class="column-title">Manage </th>
                        <th class="bulk-actions" colspan="4">
                            <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                        </th>
                    </tr>
                </thead>

                <tbody>
                    <tr class="even pointer" ng-repeat="tm in league">
                        <td class="a-center ">{{tm.ID}}</td>
                        <td class=" ">{{tm.Name}}</td>
                        <td class=" ">
                            <ul class="list-inline">
                                <li><img src="{{tm.ImagePath}}" class="avatar" alt="Avatar" /></li>
                            </ul>
                        </td>
                        <td> 
                            <a href="AddGame.aspx?LeagueID={{tm.ID}}" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>New Game </a>
                            <a href="CreateLog.aspx?LeagueID={{tm.ID}}" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>Create/Update Log </a>
                            <a href="DeleteLeague.aspx?LeagueID={{tm.ID}}" class="btn btn-danger btn-xs"><i class="fa fa-trash-o"></i> Delete </a>
                            <a href="Statistics.aspx?leageID={{tm.ID}}" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i> View Stats </a>
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
