<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTeam.aspx.cs" Inherits="SportsManagementSystem.AddTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Team</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtType" runat="server" Text="Type"></asp:TextBox><br/>
        <asp:TextBox ID="txtName" runat="server" Text="Name"></asp:TextBox><br/>
        <asp:TextBox ID="txtNumPlayers" runat="server" TextMode="Number" Text="Number of Players"></asp:TextBox><br/>
        <asp:TextBox ID="txtDesc" runat="server" Text="Team Background" TextMode="MultiLine"></asp:TextBox><br/><br/>
        <asp:FileUpload ID="flTeamImage" runat="server" />Upload Team Image <br/>
        <asp:Button ID="btnAdd" runat="server" Text="Add Team" OnClick="btnAdd_Click" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit Team" OnClick="btnEdit_Click" /><br/><br/><br/>
    </div>
        <div>
            Adding League <br/>
            <asp:TextBox ID="txtLeagueName" runat="server" Text="League Name" ></asp:TextBox><br/>
            <asp:TextBox ID="txtPrice" runat="server" Text="Winning Price" ></asp:TextBox><br/>
            <asp:TextBox ID="txtLeagueDesc" runat="server" Text="Description" TextMode="MultiLine"></asp:TextBox><br/>
            <asp:TextBox ID="txtStartDate" runat="server" type="datetime2" TextMode="DateTimeLocal" >StartDate</asp:TextBox><br/>
            <asp:TextBox ID="txtEndDate" runat="server" type="datetime2" TextMode="DateTimeLocal">End Date</asp:TextBox><br/>
            Add League Image<asp:FileUpload ID="flLeague" runat="server" /><br/>

            <asp:Button ID="btnLeague" runat="server" Text="Add League" OnClick="btnLeague_Click" /><br/><br/><br/>

        </div>
        <div>
            Add League Teams <br/>
            <asp:TextBox ID="txtT_Name" runat="server" Text="Team Name"></asp:TextBox><br/>
            <asp:TextBox ID="txtL_Name" runat="server" Text="League Name"></asp:TextBox><br/>
            <asp:Button ID="btnRegTeam" runat="server" Text="Add Team" OnClick="btnRegTeam_Click" />
        </div><br/><br/>

        <div>
            Add Games <br/>
            <asp:TextBox ID="txtTeamOne" Text="Team One" runat="server"></asp:TextBox><br/>
            <asp:TextBox ID="txtTeamTwo" Text="Team Two" runat="server"></asp:TextBox><br/>
            <asp:TextBox ID="txtGameDate" Text="Match Date"  type="datetime2" TextMode="DateTimeLocal" runat="server"></asp:TextBox><br/>
            <asp:TextBox ID="txtVenue" Text="Venue" runat="server"></asp:TextBox><br/>
            <asp:TextBox ID="txtGameType" Text="Type" runat="server"></asp:TextBox><br/>
            Game Image <asp:FileUpload ID="flGameImage" runat="server" /><br/>
            <asp:Button ID="btnMatch" runat="server" Text="Add Match" OnClick="btnMatch_Click" />
        </div><br/><br /><br />
        <div>
            Game Stats <br />
            <asp:TextBox ID="txtBPlayer" Text="Best Player" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtT1_Pos" Text="Team One Position" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtT1_Foul" Text="Team One Fouls" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtT2_Pos" Text="Team Two Position" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtT2_Foul" Text="Team Two Fouls" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtGameID" Text="Game ID"  runat="server"></asp:TextBox><br />
            <asp:Button ID="btnStats"  runat="server" Text="Submit Stats" OnClick="btnStats_Click" />
        </div><br/><br /><br />

         <div>
            Game Tickets <br />
            <asp:TextBox ID="txtTicketPrice" Text="Price" TextMode="Number" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtTicketDate" Text="Ticket Date"  type="datetime2" TextMode="DateTimeLocal" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtQuantity" Text="Number of Tickets" TextMode="Number" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtTicketGameID" Text="Team Two Position" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1"  runat="server" Text="Game Ticket" OnClick="Button1_Click" />
        </div><br/><br /><br />

        <div>
            League: Add Log <br />
            <asp:TextBox ID="txtL_TeamName" Text="Team Name" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtL_Pos" Text="Position" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtL_MPlayed" Text="Match Played"  runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtL_Wins" Text="Wins" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtL_Lose" Text="Lose" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtL_Draws" Text="Draws" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtL_Points" Text="Points" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnAddLog"  runat="server" Text="Add Log" OnClick="btnAddLog_Click" />
        </div><br/><br /><br />

         <div>
            Update Log <br />
            <asp:TextBox ID="txtLU_TeamName" Text="Team Name" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtLU_Pos" Text="Position" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtLU_MPlayed" Text="Match Played"  runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtLU_Wins" Text="Wins" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtLU_Lose" Text="Lose" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtLU_Draws" Text="Draws" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtLU_Points" Text="Points" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnUpdateLog"  runat="server" Text="Update Log" OnClick="btnUpdateLog_Click" />
        </div><br/><br /><br />
    </form>
</body>
</html>
