<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="LinqDemo.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Cust id" ID="label1"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtcusid" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Name" ID="label2"></asp:Label></td>
                    <td>            <asp:TextBox ID="txtcusname" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Age" ID="label3"></asp:Label></td>
                    <td>
                                    <asp:TextBox ID="txtage" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Div" ID="label4"></asp:Label></td>
                    <td>            <asp:TextBox ID="txtdiv" runat="server" />
</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Address" ID="label5"></asp:Label></td>
                    <td>            <asp:TextBox ID="txtcusaddress" runat="server" />
</td>
                </tr>
            </table>
            <br />

            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />

            <asp:GridView ID="gvcustdetails" runat="server" AutoGenerateColumns="true" />

        </div>
    </form>
</body>
</html>
