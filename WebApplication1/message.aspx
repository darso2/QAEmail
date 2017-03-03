<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="WebApplication1.message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div.messagebox {
            margin-right: 300px;
            margin-bottom: 10px;
        }
        .auto-style1 {
            position: absolute;
            left: 300px;
            top: 177px;
            height: 29px;
            width: 56px;
        }
    </style>
</head>
<body id="PageForm" runat="server">
    <form id="form1" runat="server">
        
        <asp:Button ID="back" runat="server" Height="19px" Text="Back" Width="43px" OnClick="back_Click" />
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Button ID="delete" runat="server" Height="19px" Text="Delete" Width="62px" OnClientClick="return confirm('Are you sure? Once deleted it cannot be restored.')" onclick="Delete_Click" />
        
        <br />
        
        <br />
    From:    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span id="from" runat="server"></span>
        <div id="touser" runat="server"> To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div><br /> <br />
    Subject: &nbsp;&nbsp;&nbsp;&nbsp; <span id="subject" runat="server"></span><br /><br />
        Message:
        <div id="textmessage" runat="server" class="messagebox"></div>
        <asp:Button ID="Reply" runat="server" Text="Reply" CssClass="auto-style1" OnClick="Reply_Click"/>
    </form>
</body>
</html>
