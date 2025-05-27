using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementDemo
{
    public partial class ApplicationState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"]) + 1;
            Application.UnLock();
            Label1.Text = Application["ActiveUsers"].ToString();
        }
    }
}