<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Login" style="position:absolute;top:100px;left:300px"/>
        <asp:Button ID="Button2" runat="server" Text="Create Account"  style="position:absolute;top:100px;left:400px" OnClick="Button2_Click"/>
    </form>
</body>
</html>
