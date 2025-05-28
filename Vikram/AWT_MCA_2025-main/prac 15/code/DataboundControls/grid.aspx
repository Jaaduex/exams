<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid.aspx.cs" Inherits="DataboundControls.grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                DeleteCommand="DELETE FROM [ServReg] WHERE [EmpID] = @EmpID"
                InsertCommand="INSERT INTO [ServReg] ([EmpName], [EmpID], [DeptNo]) VALUES 
(@EmpName, @EmpID, @DeptNo)"
                SelectCommand="SELECT * FROM [ServReg]"
                UpdateCommand="UPDATE [ServReg] SET [EmpName] = @EmpName, [DeptNo] = 
@DeptNo WHERE [EmpID] = @EmpID">
                <DeleteParameters>
                    <asp:Parameter Name="EmpID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="EmpName" Type="String" />
                    <asp:Parameter Name="EmpID" Type="Int32" />
                    <asp:Parameter Name="DeptNo" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="EmpName" Type="String" />
                    <asp:Parameter Name="DeptNo" Type="Int32" />
                    <asp:Parameter Name="EmpID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />

        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="EmpID" DataSourceID="SqlDataSource1"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"
                    ShowSelectButton="True" />
                <asp:BoundField DataField="EmpName" HeaderText="EmpName"
                    SortExpression="EmpName" />
                <asp:BoundField DataField="EmpID" HeaderText="EmpID" ReadOnly="True"
                    SortExpression="EmpID" />
                <asp:BoundField DataField="DeptNo" HeaderText="DeptNo"
                    SortExpression="DeptNo" />
            </Columns>
    </asp:G
</body>

</html>
