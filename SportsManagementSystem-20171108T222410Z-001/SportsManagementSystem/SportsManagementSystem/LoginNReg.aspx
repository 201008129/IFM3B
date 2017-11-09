<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNReg.aspx.cs" Inherits="SportsManagementSystem.LoginNReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Email" runat="server" Text="Email"></asp:TextBox>
        <asp:TextBox ID="Password" runat="server" Text="Pass"></asp:TextBox>
        <br/>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br/><br/>

        Register User <br/>
        <asp:TextBox ID="txtName" runat="server" Text="Name"></asp:TextBox><br/>
        <asp:TextBox ID="txtSurname" runat="server" Text="Surname"></asp:TextBox><br/>
        <asp:TextBox ID="txtEmail" runat="server" Text="Email"></asp:TextBox><br/>
        <asp:TextBox ID="txtPass" runat="server" Text="Pass"></asp:TextBox><br/>
        <asp:TextBox ID="txtLevel" runat="server" Text="Level"></asp:TextBox><br/>
        <asp:Button ID="btnRegUser" runat="server" Text="Reg User" OnClick="btnRegUser_Click" /> <br/><br/>
        Insert Team Player<br/>
        <asp:TextBox ID="txtPlayerName" runat="server" Text="Name"></asp:TextBox><br/>
        <asp:TextBox ID="txtPosition" runat="server" Text="Surname"></asp:TextBox><br/>
        <asp:TextBox ID="Performance" runat="server" Text="Email"></asp:TextBox><br/>
        <asp:TextBox ID="txtDesc" runat="server" Text="Pass"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="Reg User" /> <br/><br/>
        <asp:Button ID="btnAddTeam" runat="server" Text="Reg User" />
    </div>
    </form>
</body>
</html>
