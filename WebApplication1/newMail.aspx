<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newMail.aspx.cs" Inherits="WebApplication1.newMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 178px;
        }
        .auto-style2 {
            width: 291px;
            height: 83px;
        }
        .style6{
            
        }
            
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        To:
        <input id="Text1" type="text" class="style6" runat="server" />@qa.com<br />
        <br />
        CC:<input id="Text2" type="text" runat="server"/>@qa.com<br />
        <br />
        Subject:
        <input id="Text3" class="auto-style1" type="text" runat="server"/><br />
        <br />
        Message:<br />
        <textarea id="TextArea1" class="auto-style2" name="S1" runat="server"></textarea><br />
        <br />
    
    </div>
        <asp:Button ID="sendMail" runat="server" Text="Send" OnClick="sendMail_Click" />
    </form>
</body>
</html>
