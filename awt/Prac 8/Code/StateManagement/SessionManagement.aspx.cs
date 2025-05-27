using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class SessionManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["UserName"].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserName"] = Convert.ToString(TextBox1.Text);
            //get the session value
            Label1.Text = Session["UserName"].ToString();
        }
    }
}