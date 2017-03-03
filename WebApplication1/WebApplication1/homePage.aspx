<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="PageBody" runat="server">
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Login" style="position:absolute;top:100px;left:300px" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Create Account"  style="position:absolute;top:100px;left:400px" OnClick="Button2_Click"/>
        <asp:RadioButtonList ID="RadioButtonList1" style="position:absolute;top:130px ;left:320px" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">    
            <asp:ListItem runat="server" id="option1" Value="0">Red</asp:ListItem>
    <asp:ListItem id="option2" runat="server" Value="1">Green</asp:ListItem>
    <asp:ListItem id="option3" runat="server" Value="2">Blue</asp:ListItem>
</asp:RadioButtonList>
    </form>
</body>
</html>
