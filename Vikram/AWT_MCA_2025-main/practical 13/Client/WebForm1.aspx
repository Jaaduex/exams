<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="num1"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="num2"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Result"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   
                    <td>
                           <asp:Button ID="Button2" runat="server" OnClick="Button1_Click1" Text="call Web service 1" />
                    </td>
                </tr>
                               <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="First name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Last name"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Result"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   
                    <td>
                           <asp:Button ID="Button4" runat="server" OnClick="Button1_Click2" Text="call Web service 2" />
                    </td>
                </tr> 
                                 

            </table>
        </div>
    </form>
</body>
</html>
