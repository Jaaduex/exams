<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AJAXExample.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2>Current Server Time using AJAX</h2>
                <asp:Label ID="lblTime" runat="server" Font-Size="Large" />
                <br /><br />
                <asp:Button ID="btnGetTime" runat="server" Text="Get Time" OnClick="btnGetTime_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
