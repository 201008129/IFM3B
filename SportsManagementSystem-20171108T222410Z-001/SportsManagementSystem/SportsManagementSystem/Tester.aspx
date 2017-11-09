<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="SportsManagementSystem.Team_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />

    <!-- page content -->
    <div class="nav-md">
        <div class="container body">
            <div class="main_container">
                <div class="right_col" role="main">
                    <div class="">
                        <div class="page-title">
                            <div class="title_left">
                                <h3>Add Team</h3>
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
                                                <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Team Info</a></li>
<%--                                                <li role="presentation" class=""><a href="#tab_content2" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">Winning Price</a></li>--%>
                                                <li role="presentation" class=""><a href="#tab_content3" role="tab" id="profile-tab2" data-toggle="tab" aria-expanded="false">Team Players</a>
                                                </li>
                                            </ul>
                                            <div id="myTabContent" class="tab-content">
                                                <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">
                                                    <div class="form-horizontal form-label-left">

                                                        <div class="item form-group">
                                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="teamName">Team Name </label>
                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                <input id="txtName" name="teamName" runat="server" required="required" class="form-control col-md-7 col-xs-12" />
                                                            </div>
                                                        </div>

                                                        <%--<div class="item form-group">
                                                            <label class="control-label col-md-3">Coach</label>
                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                <input id="txtPrice" runat="server" type="number" class="form-control col-md-7 col-xs-12" />
                                                            </div>
                                                        </div>--%>

                                                        <div class="item form-group">
                                                            <label class="control-label col-md-3">Team Description</label>
                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                <textarea id="txtDesc" runat="server" row="3" class="form-control col-md-7 col-xs-12" required="required"></textarea>
                                                            </div>
                                                        </div>

                                                        <div class="item form-group">
                                                            <label class="control-label col-md-3">Number of Players</label>
                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                <input id="txtPrice" runat="server" type="number" class="form-control col-md-7 col-xs-12" />
                                                            </div>
                                                        </div>

                                                        <div class="item form-group">
                                                            <label class="control-label col-md-3">Category</label>
                                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                                <select class="select2_single form-control" tabindex="-1">
                                                                    <option></option>
                                                                    <option value="cricket">Cricket</option>
                                                                    <option value="rugby">Rugby</option>
                                                                    <option value="soccer">Soccer</option>
                                                                </select>
                                                            </div>
                                                        </div>

                                                        <div class="item form-group">
                                                            <label class="control-label col-md-3">Upload Team Image</label>
                                                            <%-- <asp:FileUpload ID="flImage" runat="server" class="btn btn-success col-md-6 col-sm-6 col-xs-12" />--%>
                                                            <div class="item form-group">
                                                                <div action="Tester.aspx" class="dropzone col-md-6 col-sm-6 col-xs-12"></div>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                            </div>
                                                        </div>

                                                   
                                                        <div class="ln_solid"></div>
                                                        <div class="form-group">
                                                            <div class="col-md-6 col-md-offset-3">
                                                                <asp:LinkButton class="btn btn-success" ID="lnkAddLeague" runat="server">Submit Team</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="profile-tab">
                                                    <p>
                                                        Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee. Qui photo
                                                        booth letterpress, commodo enim craft beer mlkshk aliquip
                                                    </p>
                                                </div>--%>
                                                <div role="tabpanel" class="tab-pane fade" id="tab_content3" aria-labelledby="profile-tab">
                                                    <p>Please add the team players information</p>
                                                    <div class="table-responsive">
                                                        <table class="table table-striped jambo_table bulk_action">
                                                            <thead>
                                                                <tr class="headings">
                                                                    <th class="column-title">Name </th>
                                                                    <th class="column-title">Position </th>
                                                                    <th class="column-title">Perfomance Rate </th>
                                                                    <th class="column-title">Description </th>
                                                                    <th class="bulk-actions" colspan="3">
                                                                        <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                                                    </th>
                                                                </tr>
                                                            </thead>

                                                            <tbody>
                                                                <tr class="even pointer">
                                                                    <td class=" "><input /></td>
                                                                    <td class=" "><input /></td>
                                                                    <td class=" "><input /></td>
                                                                    <td class=" "><input /> </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <div class="item form-group">
                                                            <label class="control-label col-md-3">Upload Players Spreadsheet</label>
                                                            <%-- <asp:FileUpload ID="flImage" runat="server" class="btn btn-success col-md-6 col-sm-6 col-xs-12" />--%>
                                                            <div class="item form-group">
                                                                <div action="Tester.aspx" class="dropzone col-md-6 col-sm-6 col-xs-12"></div>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
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
