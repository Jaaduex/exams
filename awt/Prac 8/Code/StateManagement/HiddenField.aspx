<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiddenField.aspx.cs" Inherits="StateManagement.HiddenField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                Text="Button" />
        </div>
    </form>
</body>
</html>
