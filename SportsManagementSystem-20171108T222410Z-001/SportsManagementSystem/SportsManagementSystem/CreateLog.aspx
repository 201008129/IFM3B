<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="CreateLog.aspx.cs" Inherits="SportsManagementSystem.CreateLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Create/Update Log</h3>
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
                                    <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints" style="width: 50px;" /></a></td>
                                    </tr>
                                         <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_2" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_2" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_2" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_2" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_2" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_2" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_2" style="width: 50px;" /></a></td>
                                    </tr>     <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_3" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_3" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_3" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_3" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_3" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_3" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_3" style="width: 50px;" /></a></td>
                                    </tr>     
                                    
                                    <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_4" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_4" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_4" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_4" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_4" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_4" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_4" style="width: 50px;" /></a></td>
                                    </tr>     
                                    
                                    <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_5" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_5" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_5" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_5" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_5" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_5" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_5" style="width: 50px;" /></a></td>
                                    </tr>     <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_6" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_6" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_6" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_6" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_6" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_6" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_6" style="width: 50px;" /></a></td>
                                    </tr>     <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_7" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_7" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_7" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_7" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_7" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_7" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_7" style="width: 50px;" /></a></td>
                                    </tr>     <tr>
                                        <td><a>
                                            <input runat="server" id="txtPos_8" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtTeam_8" style="width: 50px;" /></a></td>
                                        <td></td>
                                        <td><a>
                                            <input runat="server" id="txtPlays_8" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtDraws_8" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtWins_8" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtLoose_8" style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input runat="server" id="txtPoints_8" style="width: 50px;" /></a></td>
                                    </tr>
                                </tbody>
                            </table>
                            <!-- end Log list -->
                            <div class="ln_solid"></div>

                            <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>

                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                   <%-- <asp:LinkButton class="btn btn-success" ID="lnkAddLeague" runat="server" OnClick="lnkAddLeague_Click">Create Log</asp:LinkButton>--%>
                                    <asp:Button class="btn btn-success" ID="btnUpdate" runat="server" Text="Update Log" OnClick="btnUpdate_Click" />
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
