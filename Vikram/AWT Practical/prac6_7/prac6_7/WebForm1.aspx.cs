using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;

namespace prac6_7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hiray\\Source\\Repos\\prac6_7\\prac6_7\\App_Data\\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from student");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                DataTable dt = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = "sql_insertstudentData";
                cmd.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 50)).Value = Convert.ToString(NameTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@rollno", System.Data.SqlDbType.Int, 50)).Value = Convert.ToInt32(RollTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@age", System.Data.SqlDbType.Int, 50)).Value = Convert.ToInt32(AgeTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@div", System.Data.SqlDbType.VarChar, 50)).Value = Convert.ToString(DivTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar, 50)).Value = Convert.ToString(EmailTextBox.Text);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                int s = cmd.ExecuteNonQuery();
                if (s > 0)
                {
                    ResultLabel.Text = "Data Inserted successfully";
                }
                else
                {
                    ResultLabel.Text = "Data not inserted";
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                conn.Close();
                clearTextFields();
                LoadData();
            }
        }

        private void clearTextFields()
        {
            NameTextBox.Text = String.Empty;
            RollTextBox.Text = String.Empty;
            AgeTextBox.Text = String.Empty;
            DivTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
        }
    }
}