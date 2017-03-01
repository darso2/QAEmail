<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

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
        <asp:Button ID="makeMail" runat="server" Text="Compose" Height="25px" Width="100px" OnClick="make_click" />
    </div>
    </form>
</body>
</html>
