<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="prac6_7.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server" style="margin-left: 101px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Roll No"></asp:Label>
            <asp:TextBox ID="RollTextBox" runat="server" style="margin-left: 88px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>
            <asp:TextBox ID="AgeTextBox" runat="server" style="margin-left: 109px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Div"></asp:Label>
            <asp:TextBox ID="DivTextBox" runat="server" style="margin-left: 114px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server" style="margin-left: 105px"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
        </div>
        <asp:Button ID="InsertButton" runat="server" Text="Insert Data" OnClick="InsertButton_Click" />
        <br />
        <br />
        <asp:Label ID="ResultLabel" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
