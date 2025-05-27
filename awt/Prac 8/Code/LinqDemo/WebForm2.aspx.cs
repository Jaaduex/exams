using LinqDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace LinqDemo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Database1Entities dc = new Database1Entities();
        Database2Entities dc2 = new Database2Entities();
        public void ClearTextBox()
        {
            
            txtcusid.Text = "";
            txtcusname.Text = "";
            txtcusaddress.Text = "";
            txtage.Text = "";
            txtdiv.Text = "";
        }

        public void ShowData()
        {
            try
            {
                IEnumerable < Student > students = dc.Students;
                //var q = dc.Students.ToList();
                gvcustdetails.DataSource = students.ToList();
                gvcustdetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception: " + ex.Message + "');</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student
                {
                    Id = Convert.ToInt32(txtcusid.Text),
                    Name = txtcusname.Text,
                    Age = string.IsNullOrEmpty(txtage.Text) ? null : (int?)Convert.ToInt32(txtage.Text),
                    Div = txtdiv.Text,
                    DreamJob = txtcusaddress.Text
                };

                dc.Students.Add(s);
                dc.SaveChanges();
                ClearTextBox();
                ShowData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Insert Exception: " + ex.Message + "');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtcusid.Text);
                Student s = (from Student in dc.Students 
                            where Student.Id == id 
                            select Student).FirstOrDefault();
                Student ss = dc.Students.Single(x => x.Id == id);
                dc.Students.Remove(s);
                dc.SaveChanges();
                ClearTextBox();
                ShowData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Delete Exception: " + ex.Message + "');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int[] nums = { 1, 2, 3, 4, 5, 6 };
                int id = Convert.ToInt32(txtcusid.Text);
                Student s = dc.Students.Single(x => x.Id == id);
                s.Name = txtcusname.Text;
                s.Age = string.IsNullOrEmpty(txtage.Text) ? null : (int?)Convert.ToInt32(txtage.Text);
                s.Div = txtdiv.Text;
                s.DreamJob = txtcusaddress.Text;

                dc.SaveChanges();
                ClearTextBox();
                ShowData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Update Exception: " + ex.Message + "');</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtcusid.Text);
                Student s = dc.Students.Single(x => x.Id == id);

                txtcusname.Text = s.Name;
                txtage.Text = s.Age?.ToString();
                txtdiv.Text = s.Div;
                txtcusaddress.Text = s.DreamJob;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Search Exception: " + ex.Message + "');</script>");
            }
        }
    }
}
