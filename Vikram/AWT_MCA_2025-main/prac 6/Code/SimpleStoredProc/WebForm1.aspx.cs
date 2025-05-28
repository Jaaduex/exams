using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SimpleStoredProc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["StudentDB"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        DataTable dt = null;

        public void ClearTextBox()
        {
            AgeTxtBox.Text = string.Empty;
            NameTxtBox.Text = string.Empty;
            DivTxtBox.Text = string.Empty;
            DreamJobTxtBox.Text = string.Empty;
        }

        public void LoadData()
        {
            try
            {
                cmd = new SqlCommand("select * from Student", conn);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                dt = new DataTable();
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception e)
            {
                Response.Write("<script type =\"text/javascript\">alert('Exception!' " + e.Message + " );</script>");
            }
            finally
            {
                conn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTxtBox.Text != null && AgeTxtBox.Text != null && DivTxtBox.Text != null && DreamJobTxtBox.Text != null)
                {

                    cmd = new SqlCommand();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    //set command type as stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pass the stored procedure name
                    cmd.CommandText = "sp_insertstudentdata";
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)).Value = Convert.ToString(NameTxtBox.Text);
                    cmd.Parameters.Add(new SqlParameter("@age",SqlDbType.SmallInt)).Value = Convert.ToInt16(AgeTxtBox.Text);
                    cmd.Parameters.Add(new SqlParameter("@div",SqlDbType.VarChar)).Value = DivTxtBox.Text;
                    cmd.Parameters.Add(new SqlParameter("@dreamjob",SqlDbType.VarChar)).Value = DreamJobTxtBox.Text;
                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        Response.Write("<script type =\"text/javascript\">alert('Record inserted successfully!');</script>");
                        ClearTextBox();
                        LoadData();
                    }
                    else
                    {
                        Response.Write("<script type =\"text/javascript\">alert('Record not inserted successfully');</script>");
                    }
                }
                else
                {

                    Response.Write("<script type=\"text/javascript\">alert('Please enter all details properly');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type =\"text/javascript\">alert('Exception! " + ex.Message + " );</ script > ");
            }
            finally
            {
                conn.Close();
                ClearTextBox();
                LoadData();
            }


        }
    }
}