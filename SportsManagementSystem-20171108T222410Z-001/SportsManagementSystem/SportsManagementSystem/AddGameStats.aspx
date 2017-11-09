<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="AddGameStats.aspx.cs" Inherits="SportsManagementSystem.AddGameStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="js/angular.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/GameTable.js"></script>

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Game Statistics</h3>
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
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <ul class="list-inline">
                                                <li runat="server" id="tmOneImage"></li>
                                            </ul>
                                        </td>
                                        <td runat="server" id="T1"></td>
                                        <td>VS</td>
                                        <td runat="server" id="T2"></td>
                                        <td>
                                            <ul class="list-inline">
                                                <li runat="server" id="tmTwoImage"></li>
                                            </ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td runat="server" id="Td7">
                                            <input runat="server" id="txt1_GS" type="text" />
                                        </td>
                                        <td>Goals Scored</td>
                                        <td runat="server" id="Td8">
                                            <input runat="server" id="txt2_GS" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td></td>
                                        <td runat="server" id="T1Pos">
                                            <input runat="server" id="txt1Position" type="text" />
                                        </td>
                                        <td>Position</td>
                                        <td runat="server" id="T2Pos">
                                            <input runat="server" id="txt2Position" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td runat="server" id="T1Fouls">
                                            <input runat="server" id="txt1Foul" type="text" />
                                        </td>
                                        <td>Fouls</td>
                                        <td runat="server" id="T2Fouls">
                                            <input runat="server" id="txt2Foul" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td runat="server" id="Td1">
                                            <input runat="server" id="txtT1_YC" type="text" />
                                        </td>
                                        <td>Yellow Cards</td>
                                        <td runat="server" id="Td2">
                                            <input runat="server" id="txtT2_YC" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td runat="server" id="Td3">
                                            <input runat="server" id="txtT1_RC" type="text" />
                                        </td>
                                        <td>Red Cards</td>
                                        <td runat="server" id="Td4">
                                            <input runat="server" id="txtT2_RC" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td runat="server" id="Td5">
                                            <input runat="server" id="txtT1_CK" type="text" />
                                        </td>
                                        <td>Corner Kicks</td>
                                        <td runat="server" id="Td6">
                                            <input runat="server" id="txtT2_CK" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>


                                    <tr>
                                        <td></td>
                                        <td runat="server" id="Td10">
                                            <input runat="server" id="txt1Average" type="text" />
                                        </td>
                                        <td>Overal Average</td>
                                        <td runat="server" id="Td11">
                                            <input runat="server" id="txt2Average" type="text" />
                                        </td>
                                        <td></td>
                                    </tr>

                                    <%-- Goal Scorers
                                        TABLE OF TEAM PLAYERS
                                    --%>
                                    <tr>
                                        <td></td>
                                        <td>Best Player</td>
                                        <td runat="server" id="TBstPlayer">
                                            <input runat="server" id="TextBestPlayer" type="text" />
                                        </td>
                                        <td runat="server" id="Td9">
                                            <input runat="server" id="txtBestPlayerGoals" placeholder="Number of Goals" type="Text" />
                                        </td>
                                        <td></td>
                                    </tr>

                                </tbody>
                            </table>
                            <!-- end Log list -->
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:LinkButton class="btn btn-success" ID="lnkAddLeague" runat="server" OnClick="lnkAddLeague_Click">Submit Stats</asp:LinkButton>
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
