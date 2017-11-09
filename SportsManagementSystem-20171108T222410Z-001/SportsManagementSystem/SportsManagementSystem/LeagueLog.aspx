<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="LeagueLog.aspx.cs" Inherits="SportsManagementSystem.LeagueLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/GameList.js"></script>
    
    <!-- page content -->
        <div class="right_col" role="main" ng-app ="GameList_App">
          <div class="" ng-controller="cntrl_LogList" >
            <div class="page-title">
              <div class="title_left">
                <h3>League Log</h3>
              </div>

              <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search"/>
                    <span class="input-group-btn">
                      <button class="btn btn-default" type="button">Go!</button>
                    </span>
                  </div>
                </div>
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
                          <th style="width: 1%">Pos</th>
                          <th style="width: 20%">Team</th>
                          <th></th>
                          <th>P</th>
                          <th>D</th>
                          <th>W</th>
                          <th>L</th>
                          <th>Pts</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr ng-repeat="tm in teams">
                          <td>{{tm.Position}} </td>
                          <td><a>{{tm.TeamName}}</a></td>
                          <td></td>
                          <td><a>{{tm.MatchPlayed}}</a></td>
                          <td><a>{{tm.Draws}}</a></td>
                          <td><a>{{tm.Wins}}</a></td>
                          <td><a>{{tm.Loose}}</a></td>
                          <td><a>{{tm.Points}}</a></td>
                        </tr>
                      </tbody>
                    </table>
                    <!-- end Log list -->

                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
    <!-- /page content -->
    

</asp:Content>
