using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class ViewState : System.Web.UI.Page
    {
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["count"] = i;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            i = (int) ViewState["count"];
            Label1.Text = (++i).ToString();
            ViewState["count"] = i;
        }
    }
}