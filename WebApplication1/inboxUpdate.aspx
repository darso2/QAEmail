<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inboxUpdate.aspx.cs" Inherits="WebApplication1.inboxUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="EmailDataSource">
            <Columns>
                <asp:BoundField DataField="fromUser" HeaderText="From" SortExpression="fromUser" />
                <asp:HyperLinkField DataNavigateUrlFields="subject"     DataNavigateUrlFormatString="message.aspx?ID=  HeaderText="Subject" SortExpression="subject" />
                <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                <asp:CheckBoxField DataField="deleted" HeaderText="Deleted" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="EmailDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [fromUser], [subject], [date],[deleted] FROM [Emails] WHERE ([toUser] = @toUser)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="toUser" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
