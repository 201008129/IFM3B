<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="LeagueTeams.aspx.cs" Inherits="SportsManagementSystem.LeagueTeams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      
        <link href="vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />
    <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/TeamList.js"></script>
    <!-- page content -->
    <div class="nav-md" ng-app="TeamList_App" ng-controller="cntrl_TeamList">
        <div class="container body">
            <div class="main_container">
                <div class="right_col" role="main">
                    <div class="">
                        <div class="page-title">
                            <div class="title_left">
                                <h3>Create League</h3>
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
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="x_panel">
                                    
                                    <div class="x_content">
                                        <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                            <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                                <li role="presentation" class=""><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">League Info</a></li>
<%--                                                <li role="presentation" class=""><a href="#tab_content2" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">Winning Price</a></li>--%>
                                                <li role="presentation" class="active"><a href="#tab_content3" role="tab" id="profile-tab2" data-toggle="tab" aria-expanded="false">Team Selection</a>
                                                </li>
                                            </ul>
                                            <div id="myTabContent" class="tab-content">
                                                <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">
                                                    <div class="form-horizontal form-label-left">

                                                      
                                                    </div>
                                                </div>
                                                <%--<div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="profile-tab">
                                                    <p>
                                                        Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee. Qui photo
                                                        booth letterpress, commodo enim craft beer mlkshk aliquip
                                                    </p>
                                                </div>--%>
                                                <div role="tabpanel" class="tab-pane fade" id="tab_content3" aria-labelledby="profile-tab">
                                                    <p>Please check select teams for the league</p>
                                                    <p><b>Soccer Teams</b></p>
                                                    <div class="table-responsive">
                                                        <table class="table table-striped jambo_table bulk_action">
                                                            <thead>
                                                                <tr class="headings">
                                                                    <th>
                                                                    </th>
                                                                    <th class="column-title">Team Name </th>
                                                                    <th class="column-title">Team Manager </th>
                                                                    <th class="column-title">Team Logo </th>
                                                                    <th class="bulk-actions" colspan="3">
                                                                        <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                                                    </th>
                                                                </tr>
                                                            </thead>

                                                            <tbody>
                                                                <tr class="even pointer" ng-repeat="Soc in soccer">
                                                                    
                                                                    <td class=" ">{{Soc.Name}}
                                                                        <asp:TextBox ID="soc_TeamName" runat="server" Visible="false">{{Soc.Name}}</asp:TextBox>
                                                                    </td>
                                                                    <td class=" ">{{Soc.ManagerName}}</td>
                                                                    <td class=" ">
                                                                        <ul class="list-inline"><li><img src="{{Soc.ImagePath}}" class="avatar" alt="Avatar"/></li></ul>
                                                                    </td>
                                                                    <td runat="server" id="tdRedirectSoccer" class="a-center"><a href="TeamAdding.aspx?teamName={{Soc.Name}}" class="btn btn-success" name="table_records">Add Team</a></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <%-- Rugby Teams --%>
                                                    <p><b>Rugby Teams</b></p>
                                                    <div class="table-responsive">
                                                        <table class="table table-striped jambo_table bulk_action">
                                                            <thead>
                                                                <tr class="headings">
                                                                    <th>
                                                                    </th>
                                                                    <th class="column-title">Team Name </th>
                                                                    <th class="column-title">Team Manager </th>
                                                                    <th class="column-title">Team Logo </th>
                                                                    <th class="bulk-actions" colspan="3">
                                                                        <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                                                    </th>
                                                                </tr>
                                                            </thead>

                                                            <tbody>
                                                                <tr class="even pointer" ng-repeat="Rug in rugby">
                                                                    <td class=" ">{{Rug.Name}}
                                                                        <asp:TextBox class=" " ID="rug_TeamName" runat="server" Visible="False">{{Rug.Name}}</asp:TextBox></td>
                                                                    <td class=" ">{{Rug.ManagerName}}</td>
                                                                    <td class=" ">
                                                                        <ul class="list-inline"><li><img src="{{Rug.ImagePath}}" class="avatar" alt="Avatar"/></li></ul>
                                                                    </td>
                                                                    <td runat="server" id="tdRedirectRugby" class="a-center"><a href="TeamAdding.aspx?teamName={{Rug.Name}}" class="btn btn-success" name="table_records">Add Team</a></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                     <%-- Cricket Teams --%>
                                                    <p><b>Cricket Teams</b></p>
                                                    <div class="table-responsive">
                                                        <table class="table table-striped jambo_table bulk_action">
                                                            <thead>
                                                                <tr class="headings">
                                                                    <th>
                                                                    </th>
                                                                    <th class="column-title">Team Name </th>
                                                                    <th class="column-title">Team Manager </th>
                                                                    <th class="column-title">Team Logo </th>
                                                                    <th class="bulk-actions" colspan="3">
                                                                        <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                                                    </th>
                                                                </tr>
                                                            </thead>

                                                            <tbody>
                                                                <tr class="even pointer" ng-repeat="Crick in cricket">
                                                                    <td class=" " runat="server">{{Crick.Name}}
                                                                        <asp:TextBox ID="Crick_TeamName" runat="server" Visible="False">{{Crick.Name}}</asp:TextBox>
                                                                    </td>
                                                                    <td class=" ">{{Crick.ManagerName}}</td>
                                                                    <td class=" ">
                                                                        <ul class="list-inline"><li><img src="{{Crick.ImagePath}}" class="avatar" alt="Avatar"/></li></ul>
                                                                    </td>
                                                                      <td class="a-center" runat="server" id="tdRedirectCricket"><a href="TeamAdding.aspx?teamName={{Crick.Name}}" class="btn btn-success" name="table_records">Add Team</a></td>
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
                </div>
            </div>
        </div>
        <!-- /page content -->
    </div>
        <!-- /page content -->
<!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
<%--    <script src="../vendors/fastclick/lib/fastclick.js"></script>--%>
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>
    <!-- Dropzone.js -->
<%--    <script src="vendors/dropzone/dist/min/dropzone.min.js"></script>--%>
    <script src="vendors/dropzone/dist/min/dropzone.min.js"></script>
    <script src="vendors/dropzone/dist/min/dropzone-amd-module.min.js"></script>
    <script src="vendors/dropzone/dist/dropzone.js"></script>
    <link href="vendors/dropzone/dist/dropzone.css" rel="stylesheet" />
    <script src="vendors/dropzone/dist/dropzone-amd-module.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>

</asp:Content>
