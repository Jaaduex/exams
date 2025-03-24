using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string email = TextBox2.Text;
            string password = TextBox3.Text;
            string confirmPassword = TextBox4.Text;
            string gender = RadioButtonList1.SelectedValue;
            string dob = TextBox5.Text;

            // Get selected courses
            string courses = "";
            foreach (var item in CheckBoxList1.Items)
            {
                if (((System.Web.UI.WebControls.ListItem)item).Selected)
                {
                    courses += ((System.Web.UI.WebControls.ListItem)item).Text + ", ";
                }
            }
            courses = courses.TrimEnd(',', ' ');

            // Handle file upload
            string fileName = "No file uploaded";
            if (FileUpload1.HasFile)
            {
                fileName = FileUpload1.FileName;
            }
            Label17.Text = username;
            Label18.Text = email;
            Label21.Text = gender;
            Label21.Text = courses;
            Label23.Text = dob;
            Label24.Text = fileName;

            result.Visible = true;
            // Display values on the page
           
        }
    }
}