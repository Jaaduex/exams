﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Prac_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
<table class="auto-style1">
<tr>
<td>
<asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
</td>
<td>
<asp:TextBox ID="username" runat="server" required="true"></asp:TextBox></td>
</tr>
<tr>
<td>
<asp:Label ID="Label6" runat="server" Text="Email ID"></asp:Label>
</td>
<td>
<asp:TextBox ID="EmailID" runat="server" TextMode="Email"></asp:TextBox></td>
</tr>
<tr>
<td>
<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
<td>
<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td>
<asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label></td>
<td>
<asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td>
<asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label></td>
<td>
<asp:RadioButton ID="RadioButton1" runat="server" GroupName="gender" Text="Male" />
<asp:RadioButton ID="RadioButton2" runat="server" GroupName="gender" Text="Female" /></td>
</tr>
<tr>
<td>
<asp:Label ID="Label5" runat="server" Text="Select Course"></asp:Label>s</td>
<td>
<asp:CheckBox ID="CheckBox1" runat="server" Text="J2SEE" />
<asp:CheckBox ID="CheckBox2" runat="server" Text="J2EE" />
<asp:CheckBox ID="CheckBox3" runat="server" Text="Spring Framework" />
</td>
</tr>
<tr>
<td></td>
<td>
<br />
<asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />

</td>
</tr>
</table>
<asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
<asp:Label ID="message1" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
</div>
<table class="auto-style1">
<tr>
<td class="auto-style2">
<asp:Label ID="ShowUserNameLabel" runat="server"></asp:Label></td>
<td>
<asp:Label ID="ShowUserName" runat="server"></asp:Label></td>
</tr>
<tr>
<td class="auto-style2">
<asp:Label ID="ShowEmailIDLabel" runat="server"></asp:Label></td>
<td>
<asp:Label ID="ShowEmail" runat="server"></asp:Label></td>
</tr>
<tr>
<td class="auto-style3">
<asp:Label ID="ShowGenderLabel" runat="server"></asp:Label></td>
<td class="auto-style4">
<asp:Label ID="ShowGender" runat="server"></asp:Label></td>
</tr>
<tr>
<td class="auto-style2">
<asp:Label ID="ShowCourseLabel" runat="server"></asp:Label></td>
<td>
<asp:Label ID="ShowCourses" runat="server"></asp:Label></td>
</tr>
<tr>
<td class="auto-style2">
<asp:Label ID="ShowCalenderLabel" runat="server"></asp:Label></td>
<td>
<asp:Label ID="ShowCalender" runat="server"></asp:Label></td>
</tr>
</table>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
</form>
</div>
</form>
    <p>
        &nbsp;</p>
</body>
</html>
