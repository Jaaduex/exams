using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Prac_3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection(""+ @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\YASH\source\repos\Prac 3\Prac 3\App_Data\Database1.mdf';Integrated Security=True");
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Customer";

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataTable table = new DataTable();

                table.Columns.Add("Customer Name");
                table.Columns.Add("Contact");
                table.Columns.Add("Email");

                while (dr.Read())
                {
                    DataRow datarow = table.NewRow();
                    datarow["Customer Name"] = dr["name"];
                    datarow["Contact"] = dr["mobile"];
                    datarow["Email"] = dr["email"];

                    table.Rows.Add(datarow);
                }

                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }
    }
}