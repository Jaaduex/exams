using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJAXExample
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGetTime_Click(object sender, EventArgs e)
        {
            lblTime.Text = "Server Time: " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}