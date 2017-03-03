<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="WebApplication1.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="PageBody" runat="server">
    <form id="form1" runat="server">
        <div id="main"  runat="server">
            Email:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;@qa.com<br />
            <br />
            Password:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember my password" />
            <br />
            <a href=""> Forgot Password </a>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Login" style="position:absolute;top:160px;left:130px;" OnClick="login_click"/>
        </div>
    </form>
</body>
</html>
