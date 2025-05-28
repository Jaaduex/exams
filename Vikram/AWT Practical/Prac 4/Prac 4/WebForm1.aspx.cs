using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\YASH\source\repos\Prac 4\Prac 4\App_Data\Database1.mdf';Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void display()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer", con);
            con.Open();
            adapt.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script type = 'text/javascript'>alert('No data is present in table');</script>");
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandText = "insert into Customer values('" + txtCname.Text + "','" + txtCMobile.Text + "','" +
            txtCEmail.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            txtCname.Text = "";
            txtCMobile.Text = "";
            txtCEmail.Text = "";
            //display();
            btnShow_Click(sender, e);
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            display();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandText = "delete from Customer where name = '" + txtCname.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            txtCname.Text = "";
            btnShow_Click(sender, e);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandText = "Update Customer set mobile = '" + txtCMobile.Text + "' where name = '" +
            txtCname.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            btnShow_Click(sender, e);
        }
    }
}