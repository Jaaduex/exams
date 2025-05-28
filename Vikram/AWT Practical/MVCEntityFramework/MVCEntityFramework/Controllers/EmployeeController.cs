using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
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
                db.Employees.Add(employee);
                db.SaveChanges();
                TempData["Message"] = "Employee added Successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Edit(int id)
        {
            var employee = db.Employees.Find(id); // Find the employee by Id
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Employee Edited Sucessfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id); // Find the employee by Id
            if (employee == null)
            {
                return HttpNotFound(); // If no employee found, return 404
            }
            return View(employee); // Pass the employee to the Delete view
        }
        [HttpPost,ActionName("Delete")]
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