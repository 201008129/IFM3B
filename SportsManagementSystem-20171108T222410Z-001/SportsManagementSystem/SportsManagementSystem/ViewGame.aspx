<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="ViewGame.aspx.cs" Inherits="SportsManagementSystem.ViewGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <!-- page content -->
        <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3></h3>
              </div>

              <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for">
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
                              <div class="row">
                                  <div class="col-md-12">
                                      <div class="x_panel">
                                          <div class="x_content">
                                              <div class="row">
                                                  <table>
                                                      <tr>
                                                          <td>
                                                              <div style="padding-left: 60px; padding-right: 60px;">
                                                                  <div class="thumbnail">
                                                                      <div class="image view view-first" id ="img1Div" runat="server">
                                                                          
                                                                      </div>
                                                                      <div class="caption">
                                                                          <p runat="server" id="T1Name"></p>
                                                                      </div>
                                                                  </div>
                                                              </div>
                                                          </td>
                                                          <td style="width: 100px;">
                                                              <h4 style="padding-left: 25px">VS</h4>
                                                          </td>
                                                          <td>
                                                              <div style="padding-right: 60px; padding-left: 60px;">
                                                                  <div class="thumbnail">
                                                                      <div class="image view view-first" runat="server" id="img2Div">
                                                                      </div>
                                                                      <div class="caption">
                                                                          <p id="t2Name" runat="server"></p>
                                                                      </div>
                                                                  </div>
                                                              </div>
                                                          </td>
                                                      </tr>
                                                      <tr>
                                                          <td>
                                                              <p runat="server" id="T1_Desc"></p>
                                                          </td>
                                                          <td><p runat="server" id="Venue_Time"></p></td>
                                                          <td>
                                                              <p runat="server" id="T2_Desc"></p>
                                                          </td>
                                                      </tr>
                                                      <tr>
                                                          <td>
                                                              <br />
                                                          </td>
                                                      </tr>
                                                  </table>
                                                  <div class="col-md-6 col-sm-6 col-xs-12">
                                                      <div class="x_panel">
                                                          <div class="x_title">
                                                              <h2>Line Up <small>Players</small></h2>
                                                              <ul class="nav navbar-right panel_toolbox">
                                                                  <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                                  </li>
                                                              </ul>
                                                              <div class="clearfix"></div>
                                                          </div>
                                                          <div class="x_content">

                                                              <table class="table">
                                                                  <thead>
                                                                      <tr>
                                                                          <th>Position</th>
                                                                          <th>Player Name</th>
                                                                          <th>Performance</th>
                                                                      </tr>
                                                                  </thead>
                                                                  <tbody runat="server" id="player1">

<%--                                                                      <tr>
                                                                          <th scope="row">2</th>
                                                                          <td>Jacob</td>
                                                                          <td>Thornton</td>
                                                                          <td>Defender</td>
                                                                      </tr>
                                                                      <tr>
                                                                          <th scope="row">45</th>
                                                                          <td>Larry</td>
                                                                          <td>Bird</td>
                                                                          <td>Striker</td>
                                                                      </tr>--%>
                                                                  </tbody>
                                                              </table>

                                                          </div>
                                                      </div>
                                                  </div>

                                                  <div class="col-md-6 col-sm-6 col-xs-12">
                                                      <div class="x_panel">
                                                          <div class="x_title">
                                                              <h2>Line Up <small>Players</small></h2>
                                                              <ul class="nav navbar-right panel_toolbox">
                                                                  <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                                  </li>
                                                              </ul>
                                                              <div class="clearfix"></div>
                                                          </div>
                                                          <div class="x_content">

                                                              <table class="table">
                                                                  <thead>
                                                                      <tr>
                                                                          <th>Position</th>
                                                                          <th>Player Name</th>
                                                                          <th>Performance</th>
                                                                      </tr>
                                                                  </thead>
                                                                  <tbody runat="server" id="player2">
<%--                                                                      <tr>
                                                                          <th scope="row">1</th>
                                                                          <td>Mark</td>
                                                                          <td>Otto</td>
                                                                      </tr>--%>
<%--                                                                      <tr>
                                                                          <th scope="row">2</th>
                                                                          <td>Jacob</td>
                                                                          <td>Thornton</td>
                                                                          <td>Defender</td>
                                                                      </tr>
                                                                      <tr>
                                                                          <th scope="row">3</th>
                                                                          <td>Larry</td>
                                                                          <td>Bird</td>
                                                                          <td>Striker</td>
                                                                      </tr>--%>
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
                      </div>
                  </div>
              </div>
          </div>
        </div>
        <!-- /page content -->

</asp:Content>
