<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SportsManagementSystem.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="nav-md">
   <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Login</h3>
              </div>
                
              <div class="title_right">
                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search"/>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Email </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="email" id="email" name="email" runat="server" class="form-control col-md-7 col-xs-12"/>
                        </div>
                      </div>
                      
                      <div class="item form-group">
                        <label for="password" class="control-label col-md-3">Password</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="password" runat="server" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required"/>
                        </div>
                      </div>

                      <div class="item form-group"> 
                        <small style="padding-left:450px;">New to Site?<a href="RegistrationPage.aspx"> Create Account</a></small>
                      </div>
                        
                      <div class="item form-group">
                        
                      </div>

                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <%--<button type="submit" class="btn btn-primary" runat="server">Cancel</button>
                          <button id="send" type="submit" class="btn btn-success" runat="server">Submit</button>--%>
                          <%--<asp:Button ID="Cancel" runat="server" class="btn btn-primary" Text="Cancel" OnClick="Cancel_Click"/>--%>
                          <%--<asp:Button ID="btnLogin" class="btn btn-success" runat="server" Text="Login" OnClick="btnLogin_Click" /><br/>--%>
                            <asp:LinkButton class="btn btn-success" ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">Login</asp:LinkButton>
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
    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- validator -->
<%--    <script src="../vendors/validator/validator.js"></script>--%>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

</asp:Content>
