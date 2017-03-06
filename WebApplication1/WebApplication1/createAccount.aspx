<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 184px">
    <form id="form1" runat="server">
        <p style="height: 238px">
            Desired Email Address :
            <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; left:200px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; @qa.com<br />
            <br />
            Name:<asp:TextBox ID="TextBox2" runat="server" style="position:absolute; left:200px"></asp:TextBox> <br />
            <br />
            City of Residence:<asp:TextBox ID="TextBox5" runat="server" style="position:absolute; left:200px"></asp:TextBox> 
            <br />
            <br />

            Password :           <asp:TextBox ID="TextBox3" runat="server" style="position:absolute; left:200px"></asp:TextBox><br />
            <br />

            Re-enter password :           <asp:TextBox ID="TextBox4" runat="server" style="position:absolute; left:200px"></asp:TextBox>
            <br /><br />
            Security Question: What is your favourite colour and favourite animal? Please combine and write in the box below.
            <br /> <asp:TextBox ID="TextBox6" runat="server" style="position:absolute; top: 224px; left: 10px; width: 283px;"></asp:TextBox><br />
        </p>

        <asp:Button ID="createbutt" runat="server" text="Create Account" style="position:absolute;left:350px" OnClick="createbutt_Click" />
    </form>
</body>
</html>
