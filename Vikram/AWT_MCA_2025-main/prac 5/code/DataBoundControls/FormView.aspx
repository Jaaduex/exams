asp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlasp:DynamicControlanguage="C#" AutoEventWireup="true" CodeBehind="FormView.aspx.cs" Inherits="DataBoundControls.FormView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" AllowPaging="True" DataKeyNames="Id">
                <EditItemTemplate>
                    Id:
                    <asp:DynamicControl DataField="Id" runat="server" ID="IdDynamicControl" Mode="ReadOnly" />
                    <asp:Label runat="server" /><br />
                    Name:
                    <asp:DynamicControl DataField="Name" runat="server" ID="NameDynamicControl" Mode="Edit" />
                    <asp:TextBox runat="server" /><br />
                    Age:
                    <asp:DynamicControl DataField="Age" runat="server" ID="AgeDynamicControl" Mode="Edit" />
                    <asp:TextBox runat="server" /><br />
                    Div:
                    <asp:DynamicControl DataField="Div" runat="server" ID="DivDynamicControl" Mode="Edit" />
                    <asp:TextBox runat="server" /><br />
                    DreamJob:
                    <asp:DynamicControl DataField="DreamJob" runat="server" ID="DreamJobDynamicControl" Mode="Edit" />
                    <asp:TextBox runat="server" /><br />
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" ValidationGroup="Insert" />&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    Name:
                    <asp:DynamicControl DataField="Name" runat="server" ID="NameDynamicControl" Mode="Insert" ValidationGroup="Insert" />
                    <asp:TextBox runat="server" /><br />
                    Age:
                    <asp:DynamicControl DataField="Age" runat="server" ID="AgeDynamicControl" Mode="Insert" ValidationGroup="Insert" />
                    <asp:TextBox runat="server" /><br />
                    Div:
                    <asp:DynamicControl DataField="Div" runat="server" ID="DivDynamicControl" Mode="Insert" ValidationGroup="Insert" />
                    <asp:TextBox runat="server" /><br />
                    DreamJob:
                    <asp:DynamicControl DataField="DreamJob" runat="server" ID="DreamJobDynamicControl" Mode="Insert" ValidationGroup="Insert" />
                    <asp:TextBox runat="server" /><br />
                    <asp:LinkButton runat="server" Text="Insert" CommandName="Insert" ID="InsertButton" CausesValidation="True" ValidationGroup="Insert" />&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="InsertCancelButton" CausesValidation="False" />
                </InsertItemTemplate>
                <ItemTemplate>
                    Id:
                    <asp:DynamicControl DataField="Id" runat="server" ID="IdDynamicControl" Mode="ReadOnly" />
                    <asp:Label runat="server" /><br />
                    Name:
                    <asp:DynamicControl DataField="Name" runat="server" ID="NameDynamicControl" Mode="ReadOnly" />
                    <asp:Label runat="server" /><br />
                    Age:
                    <asp:DynamicControl DataField="Age" runat="server" ID="AgeDynamicControl" Mode="ReadOnly" />
                    <asp:Label runat="server" /><br />
                    Div:
                    <asp:DynamicControl DataField="Div" runat="server" ID="DivDynamicControl" Mode="ReadOnly" />
                    <asp:Label runat="server" /><br />
                    DreamJob:
                    <asp:DynamicControl DataField="DreamJob" runat="server" ID="DreamJobDynamicControl" Mode="ReadOnly" />
                    <asp:Label runat="server" /><br />
                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" ID="EditButton" CausesValidation="False" />&nbsp;<asp:LinkButton runat="server" Text="Delete" CommandName="Delete" ID="DeleteButton" CausesValidation="False" />&nbsp;<asp:LinkButton runat="server" Text="New" CommandName="New" ID="NewButton" CausesValidation="False" />
                </ItemTemplate>
            </asp:FormView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Student] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Student] ([Name], [Age], [Div], [DreamJob]) VALUES (@Name, @Age, @Div, @DreamJob)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Student]" UpdateCommand="UPDATE [Student] SET [Name] = @Name, [Age] = @Age, [Div] = @Div, [DreamJob] = @DreamJob WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Age" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Div" Type="String"></asp:Parameter>
                    <asp:Parameter Name="DreamJob" Type="String"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Age" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Div" Type="String"></asp:Parameter>
                    <asp:Parameter Name="DreamJob" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
