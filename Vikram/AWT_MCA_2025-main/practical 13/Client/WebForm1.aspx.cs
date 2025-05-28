using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            int result = client.sum(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text));
            TextBox3.Text = result.ToString();
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            string result = client.fullname(Convert.ToString(TextBox4.Text), Convert.ToString(TextBox5.Text));
            TextBox6.Text = result.ToString();

        }
    }
}