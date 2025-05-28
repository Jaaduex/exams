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
        static List<Stud> students = new List<Stud>()
    {
        new Stud { Id = 1, Name = "Alice", Department = "CSE", Marks = 85 },
        new Stud { Id = 2, Name = "Bob", Department = "ECE", Marks = 72 },
        new Stud { Id = 3, Name = "Charlie", Department = "CSE", Marks = 90 },
        new Stud { Id = 4, Name = "David", Department = "MECH", Marks = 65 },
        new Stud { Id = 5, Name = "Eve", Department = "ECE", Marks = 78 }
    };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(students);
            }
        }

        private void BindGrid(List<Stud> list)
        {
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) &&
                !string.IsNullOrWhiteSpace(txtDept.Text) &&
                int.TryParse(txtMarks.Text, out int marks))
            {
                int newId = students.Max(s => s.Id) + 1;

                students.Add(new Stud
                {
                    Id = newId,
                    Name = txtName.Text,
                    Department = txtDept.Text,
                    Marks = marks
                });

                txtName.Text = txtDept.Text = txtMarks.Text = "";
                lblMessage.Text = "Stud added successfully!";
                BindGrid(students);
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter valid inputs!";
            }
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid(students);
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid(students);
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                var row = GridView1.Rows[e.RowIndex].Cells;

                student.Name = ((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                student.Department = ((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                student.Marks = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text);

                GridView1.EditIndex = -1;
                BindGrid(students);
                lblMessage.Text = "Stud updated successfully!";
            }
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                BindGrid(students);
                lblMessage.Text = "Stud deleted successfully!";
            }
        }
    }
}