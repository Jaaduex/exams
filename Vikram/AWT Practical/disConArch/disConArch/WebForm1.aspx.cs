using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace disConArch
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hiray\source\repos\disConArch\disConArch\App_Data\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectQuery = "select * from student";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "student");
            ds.Tables["student"].PrimaryKey = new DataColumn[] {ds.Tables["student"].Columns["Id"]};
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(20), System.Web.Caching.Cache.NoSlidingExpiration);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}