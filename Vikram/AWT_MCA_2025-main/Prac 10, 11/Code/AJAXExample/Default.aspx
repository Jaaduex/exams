<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AJAXExample._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2>Current Server Time using AJAX</h2>
                <asp:Label ID="lblTime" runat="server" Font-Size="Large" />
                <br /><br />
                <asp:Button ID="btnGetTime" runat="server" Text="Get Time" OnClick="btnGetTime_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </main>

</asp:Content>
