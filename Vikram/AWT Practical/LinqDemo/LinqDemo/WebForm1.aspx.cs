using LinqDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            showData();
        }

        public void showData()
        {
            IEnumerable<Student> stu = db.Students;
            GridView1.DataSource = stu.ToList();
            GridView1.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Student s = new Student
            {
                name = nameTextBox.Text,
                address = adTextBox.Text,
                div = divTextBox.Text
            };
            db.Students.Add(s);
            db.SaveChanges();
            showData();
            clearData();
        }

        private void clearData()
        {
            nameTextBox.Text = "";
            adTextBox.Text = "";
            divTextBox.Text = "";
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            Student st = (from Student in db.Students
                          where Student.name == name
                          select Student).Single();
            st.name = nameTextBox.Text;
            st.address = adTextBox.Text;
            st.div = divTextBox.Text;
            db.SaveChanges();
            showData();
            clearData();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string name1 = nameTextBox.Text;
            Student s = (from Student in db.Students
                         where Student.name == name1
                         select Student).FirstOrDefault();
            db.Students.Remove(s);
            db.SaveChanges();
            showData();
            clearData();
        }
    }
}