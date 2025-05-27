using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementDemo
{
    public partial class Cookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (Request.Cookies["number"] != null)
            {
                num = Convert.ToInt32(Request.Cookies["number"].Value) + 1;
            }
            else
            {
                num = 1;
            }
            Response.Cookies["number"].Value = num.ToString();
            Label1.Text = Response.Cookies["number"].Value;
        }
    }
}