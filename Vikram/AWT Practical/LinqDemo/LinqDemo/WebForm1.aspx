<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LinqDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            Name&nbsp;
            <asp:TextBox ID="nameTextBox" runat="server" Width="130px"></asp:TextBox>
            <br />
            <br />
            Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="adTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Div&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="divTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Insert_Click" Text="Insert" />
        &nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Update_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Delete_Click" Text="Delete" />
&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
    </form>
</body>
</html>
