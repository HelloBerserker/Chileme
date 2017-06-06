<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="gv2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="mID" HeaderText="ID" ReadOnly="True" SortExpression="mID" />
                <asp:BoundField DataField="mName" HeaderText="菜名" ReadOnly="True" SortExpression="mName" />
                <asp:BoundField DataField="mInfo" HeaderText="详情" ReadOnly="True" SortExpression="mInfo" />
                <asp:BoundField DataField="mPrice" HeaderText="价格" ReadOnly="True" SortExpression="mPrice" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><asp:Button ID="delete" runat="server" Text="删除啊" OnClick="delete_Click" />
        </p>
    </form>
    <ul>
        <li><a href="main.aspx" target="_blank">main.aspx</a></li>
        <li><a href="main.aspx" target="_blank">index.html</a></li>
        <li><a href="main.aspx" target="_blank">购物车.html</a></li>
        <li><a href="main.aspx" target="_blank">导航栏.html</a></li>
        <li><a href="main.aspx" target="_blank">main.aspx</a></li>
        <li><a href="About.aspx?s=hello" target="_blank">About.aspx?s=hello</a></li>
        </ul>
</body>
</html>
