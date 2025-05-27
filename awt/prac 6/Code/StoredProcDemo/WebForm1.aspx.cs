using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoredProcDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\veera\\OneDrive\\Documents\\MCA Stub\\AWT\\AWT 2025\\prac 6\\Code\\StoredProcDemo\\App_Data\\Database1.mdf\";Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void clearTextFields()
        {
            NameTextBox.Text = string.Empty;
            AgeTextBox.Text = string.Empty;
            RollNoTxtbox.Text = string.Empty;
            DivtextBox.Text = string.Empty; 
            EmailTxtBox.Text = string.Empty;
        }
        public void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Student", conn);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                 DataTable dt = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception e)
            {
                resultLabel.Text = "Exception occured : " + e.Message;

            }
            finally { conn.Close(); }
        }

        protected void InsertData(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = "sp_insertstudentData";
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar,50)).Value = Convert.ToString(NameTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@age", SqlDbType.Int, 50)).Value = Convert.ToInt32(AgeTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@rollno", SqlDbType.Int, 50)).Value = Convert.ToInt32(RollNoTxtbox.Text);
                cmd.Parameters.Add(new SqlParameter("@div", SqlDbType.VarChar, 50)).Value = Convert.ToString(DivtextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50)).Value = Convert.ToString(EmailTxtBox.Text);
                if(conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int s = cmd.ExecuteNonQuery();
                if(s > 0)
                {
                    resultLabel.Text = "Data inserted successfully";
                }
                else
                {
                    resultLabel.Text = "Data not inserted";
                }




            }
            catch (Exception ex)
            {
                resultLabel.Text = "Exception occured : " + ex.Message;

            }
            finally 
            { 
                conn.Close();
                clearTextFields();
                LoadData();
            }
        }
    }
}