using MvcEntityFrameworkApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEntityFrameworkApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities(); // The DbContext instance

        public ActionResult Index()
        {
            var employees = db.Employees.ToList();  // Retrieve employees from database
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee); // Add employee to the Employees DbSet
                db.SaveChanges(); // Save changes to the database
                TempData["Message"] = "Employee added successfully"; // Show success message
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Edit Employee Form
        public ActionResult Edit(int id)
        {
            var employee = db.Employees.Find(id); // Find the employee by Id
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Update Employee
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified; // Mark as modified
                db.SaveChanges(); // Save the changes to the database
                TempData["Message"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/{id}
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id); // Find the employee by Id
            if (employee == null)
            {
                return HttpNotFound(); // If no employee found, return 404
            }
            return View(employee); // Pass the employee to the Delete view
        }


        // POST: Employee/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = db.Employees.Find(id); // Find the employee by Id
            if (employee != null)
            {
                db.Employees.Remove(employee); // Remove the employee
                db.SaveChanges(); // Save changes to the database
            }
            TempData["Message"] = "Employee deleted successfully";
            return RedirectToAction("Index"); // Redirect back to the employee list
        }



    }
}