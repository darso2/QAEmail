<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sent.aspx.cs" Inherits="WebApplication1.Sent" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div id="inboxtable" runat="server">
  <!--  <table >
        <tr>
            <td class="auto-style2">From</td> <td class="auto-style1"> Subject</td> <td> Date </td>
        </tr>
    </table> -->
    </div>
        <asp:Button ID="makeMail" runat="server" Text="Compose" Height="25px" Width="100px" OnClick="make_click"  />
        <span style="display:inline-block; margin-left:80px;" id="allmessage" runat="server" > <a href="inbox.aspx">Inbox</a></span>
        <span style="display:inline-block; margin-left:80px;" id="deletemessage" runat="server"><a href="deleted.aspx"> Deleted</a></span>
        <span style="display:inline-block; margin-left:80px;" id="sentmessage" runat="server"><a href="sent.aspx">Sent</a></span>
    </form>
</body>
</html>
