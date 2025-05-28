<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SimpleStoredProc.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="label1" Text="Display connected stored procedure data"></asp:Label>
        </div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Enter name" ID="NameLabel"></asp:Label>

                </td>
                <td>
                    <asp:TextBox runat="server" ID="NameTxtBox"></asp:TextBox>&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label runat="server" Text="Age:" ID="Label11"></asp:Label>

                </td>
                <td>
                <asp:TextBox runat="server" ID="AgeTxtBox"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label runat="server" Text="Div" ID="Label12"></asp:Label>

                </td>
                <td>
                <asp:TextBox runat="server" ID="DivTxtBox"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
<asp:Label runat="server" Text="Dream job ?" ID="Label13"> </asp:Label>
                </td>
                <td>
<asp:TextBox runat="server" ID="DreamJobTxtBox"></asp:TextBox>                </td>
            </tr>
        </table>
        <div>


         
            <div>&nbsp;</div>
            <div>
                <asp:GridView runat="server" ID="GridView1"></asp:GridView>
                <asp:Button runat="server" Text="Insert data with SP" OnClick="Unnamed6_Click"></asp:Button>
                &nbsp;
            </div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>
    </form>
</body>
</html>
