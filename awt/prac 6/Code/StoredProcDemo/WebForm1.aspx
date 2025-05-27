<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="StoredProcDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Display data from stored procedure"></asp:Label>

            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Name"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="NameTextBox"> </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Age"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="AgeTextBox"> </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Rollno"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="RollNoTxtbox"> </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Div"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="DivtextBox"> </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Email"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="EmailTxtBox"> </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div>&nbsp;</div>
            <div>
                <asp:GridView runat="server" ID="GridView1"></asp:GridView>
                &nbsp;</div>
            <div>&nbsp;</div>
        </div>
        <div>
            <asp:Button runat="server" Text="Insert data using SP" OnClick="InsertData"></asp:Button>&nbsp;</div>
        <asp:Label runat="server" Text="" ID="resultLabel"></asp:Label>
    </form>
</body>
</html>
