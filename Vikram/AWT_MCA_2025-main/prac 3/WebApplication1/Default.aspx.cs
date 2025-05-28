using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\veera\\OneDrive\\Documents\\MCA Stub\\AWT\\AWT 2025\\prac 3\\WebApplication1\\App_Data\\Database1.mdf\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Customer";
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Customer Name");
                table.Columns.Add("Contact");
                table.Columns.Add("Email");
                while (dr.Read())
                {
                    DataRow dataRow = table.NewRow();
                    dataRow["Id"] = dr["Cust_Id"];
                    dataRow["Customer Name"] = dr["Cust_Name"];
                    dataRow["Contact"] = dr["Cust_Mobile"];
                    dataRow["Email"] = dr["Cust_Email"];
                    table.Rows.Add(dataRow);
                }
                GridView2.DataSource = table;
                GridView2.DataBind();
            }
        }
    }
}