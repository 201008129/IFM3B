<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SportsManagementSystem.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/GameList.js"></script>
        <!-- page content -->
        <div class="right_col" role="main" ng-app ="GameList_App">
          <div class="" ng-controller="cntrl_GameList">
            <div class="page-title">
              <div class="title_left">
                <h2>UPCOMING GAMES</h2>
              </div>

              <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search"/ ng-model="searchGame"/>
                  </div>
                </div>
              </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Cricket </h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">

                    <div class="row">

                      <div class="col-md-3" ng-repeat="Crick in cricket | filter:searchGame" >
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="{{Crick.ImagePath}}" alt="image" />
                            <div class="mask">
                                <p>{{Crick.LeaguName}}</p>
                              <div class="tools tools-bottom">
                                <a href="ViewGame.aspx?G_ID={{Crick.G_ID}}"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p><b>{{Crick.TeamOne}} vs {{Crick.TeamTwo}}</b></p>
                            <small>{{Crick.Date}}</small>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

                          <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Soccer </h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <div class="row" >
                      <div class="col-md-3" ng-repeat="Soc in soccer | filter:searchGame">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="{{Soc.ImagePath}}" alt="image" />
                            <div class="mask">          
                            <p><b>{{Soc.LeaguName}}</b></p>
                              <div class="tools tools-bottom">
                                <a href="ViewGame.aspx?G_ID={{Soc.G_ID}}"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">               
                              <p><b>{{Soc.TeamOne}} vs {{Soc.TeamTwo}}</b></p>
                            <small>{{Soc.Date}}</small>
                          </div>
                        </div>
                      </div>


<%--                      <div class="col-md-3">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="assets/img/img-list2.jpg" alt="image" />
                            <div class="mask">
                              <p>Your Text</p>
                              <div class="tools tools-bottom">
                                <a href="#"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p>Snow and Ice Incoming for the South</p>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-3">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="assets/img/img-list3.jpg" alt="image" />
                            <div class="mask">
                              <p>Your Text</p>
                              <div class="tools tools-bottom">
                                <a href="#"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p>Snow and Ice Incoming for the South</p>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-3">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="assets/img/img-list.jpg" alt="image" />
                            <div class="mask">
                              <p>Your Text</p>
                              <div class="tools tools-bottom">
                                <a href="#"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p>Snow and Ice Incoming for the South</p>
                          </div>
                        </div>
                      </div>--%>
                    </div>
                  </div>
                </div>
              </div>
            </div>


                          <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Rugby </h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">

                    <div class="row">
                      <div class="col-md-3" ng-repeat="Rug in rugby | filter:searchGame">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="{{Rug.ImagePath}}" alt="image" />
                            <div class="mask"> 
                            <p><b>{{Rug.LeaguName}}</b></p>
                              <div class="tools tools-bottom">
                                <a href="ViewGame.aspx?G_ID={{Rug.G_ID}}"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">   
                              <p><b>{{Rug.TeamOne}} vs {{Rug.TeamTwo}}</b></p>               
                            <small>{{Rug.Date}}</small>
                          </div>
                        </div>
                      </div>


<%--                      <div class="col-md-3">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="assets/img/img-list2.jpg" alt="image" />
                            <div class="mask">
                              <p>Your Text</p>
                              <div class="tools tools-bottom">
                                <a href="#"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p>Snow and Ice Incoming for the South</p>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-3">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="assets/img/img-list3.jpg" alt="image" />
                            <div class="mask">
                              <p>Your Text</p>
                              <div class="tools tools-bottom">
                                <a href="#"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p>Snow and Ice Incoming for the South</p>
                          </div>
                        </div>
                      </div>
                      <div class="col-md-3">
                        <div class="thumbnail">
                          <div class="image view view-first">
                            <img style="width: 100%; display: block;" src="assets/img/img-list.jpg" alt="image" />
                            <div class="mask">
                              <p>Your Text</p>
                              <div class="tools tools-bottom">
                                <a href="#"><i class="fa fa-link"></i></a>
                              </div>
                            </div>
                          </div>
                          <div class="caption">
                            <p>Snow and Ice Incoming for the South</p>
                          </div>
                        </div>
                      </div>--%>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
