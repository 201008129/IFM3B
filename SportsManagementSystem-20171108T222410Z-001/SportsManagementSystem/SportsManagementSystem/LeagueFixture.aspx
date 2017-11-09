<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="LeagueFixture.aspx.cs" Inherits="SportsManagementSystem.LeagueFixture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/LeagueFixture.js"></script>
    <!-- page content -->
        <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>League Fixture</h3>
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

            <div class="row" ng-app ="MyGameFixture_App">
            <div class="col-md-12" ng-controller="cntrl_MyGameFixture">
                <div class="x_panel">
                    <div class="x_content">
                        <div class="x_title">
                            <div class='nav navbar-right col-sm-4'>
                                <div class="form-group">
                                    <div class='input-group date' id='myDatepicker2'>
                                        <input type='text' class="form-control" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <!-- start Log list -->
                        <table class="table table-striped projects" >
                            <thead>
                                <tr>
                                    <th></th>
                                    <th style="width: 30%">Team Name</th>
                                    <th></th>
                                    <th style="width: 20%">Date</th>
                                    <th style="width: 20%">Venue</th>
                                    <th style="width: 20%">Ticket</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr ng-repeat="gm in games">
                                    <td>
                                    <img src="{{gm.ImagePath}}" alt="image" style="width:240px; height:170px" />
                                     </td>
                                    <td><a href="ViewGame.aspx?G_ID={{gm.G_ID}}">{{gm.TeamOne}} vs {{gm.TeamTwo}}</a></td>
                                    <td></td>
                                    <td>{{gm.Date}}</td>
                                    <td>{{gm.Venue}}</td>
                                    <td><a>Ticket</a></td>
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
