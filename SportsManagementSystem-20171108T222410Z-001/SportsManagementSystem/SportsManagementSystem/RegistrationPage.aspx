<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="SportsManagementSystem.RegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="nav-md">
        <div class="right_col" role="main">
            <div class="">
                <div class="page-title">
                    <div class="title_left">
                        <h3>Create Account</h3>
                    </div>

                    <div class="title_right">
                        <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="Search " />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_content">

                                <div class="form-horizontal form-label-left">

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Name</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="name" runat="server" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" required="required" type="text" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="surname">Surname</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input type="text" id="surname" runat="server" name="surname" required="required" class="form-control col-md-7 col-xs-12" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Email </label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input type="email" id="email" runat="server" name="email" required="required" class="form-control col-md-7 col-xs-12" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label for="password" class="control-label col-md-3">Password</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="password" type="password" runat="server" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label for="password2" class="control-label col-md-3 col-sm-3 col-xs-12">Repeat Password</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="password2" type="password" runat="server" name="password2" data-validate-linked="password" class="form-control col-md-7 col-xs-12" required="required" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="role">Role</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="role" type="text" runat="server" name="Role" data-validate-length-range="5,20" class="optional form-control col-md-7 col-xs-12" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="role">Upload Picture</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:FileUpload ID="flUserImge" runat="server" CssClass="btn btn-success" />
                                        </div>
                                    </div>

                                    <div class="ln_solid"></div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-3">
                                            <asp:LinkButton class="btn btn-success" ID="lnkReg" runat="server" OnClick="lnkReg_Click">Register</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="item form-group">
                                        <small style="padding-left: 450px;">Already have an account?<a href="LoginPage.aspx">Login</a></small>
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
    <!-- jQuery -->

</asp:Content>
