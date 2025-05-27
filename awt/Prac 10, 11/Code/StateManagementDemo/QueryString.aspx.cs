using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementDemo
{
    public partial class QueryString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Request.QueryString["number"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (Request.QueryString["number"] != null)
            {
                num = Convert.ToInt32(Request.QueryString["number"])+1;
            }
            else
            {
                num = 1;
            }
            Response.Redirect("QueryString.aspx?number=" + num);
        }
    }
}