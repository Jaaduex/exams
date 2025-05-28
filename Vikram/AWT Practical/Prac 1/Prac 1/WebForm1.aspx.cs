using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var name = username.Text;
            var email = EmailID.Text;
            var gender = RadioButton1.Checked ? "Male" : "Female";
            List<string> course = new List<string>();
            if (CheckBox1.Checked)
            {
                course.Add("J2SEE");
            }
            if (CheckBox2.Checked)
            {
                course.Add("J2EE");
            }
            if(CheckBox3.Checked)
            {
                course.Add("Spring Framework");
            }
            message.Text = "Hello " + name +"!";
            message1.Text = "You have successfully registered with the following details";
            ShowUserNameLabel.Text = "UserName";
            ShowUserName.Text = name;
            ShowEmailIDLabel.Text = "Email ID";
            ShowEmail.Text = email;
            ShowGenderLabel.Text = "Gender";
            ShowGender.Text = gender;
            ShowCourseLabel.Text = "Course";
            ShowCourses.Text = String.Join("",course);
            ShowCalenderLabel.Text = "Selected Date";
            ShowCalender.Text = Calendar1.SelectedDate.ToString();
        }
    }
}