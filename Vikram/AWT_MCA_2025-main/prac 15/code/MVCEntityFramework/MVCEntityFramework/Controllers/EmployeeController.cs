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
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        // GET: Employee List
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList(); // Fetch from DB
            return View(employees);
        }

        // GET: Create Employee Form
        public ActionResult Create()
        {
            return View();
        }

        // POST: Save Employee to Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges(); // Save to DB
                TempData["Message"] = "Employee added successfully";
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Delete Employee
        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Confirm Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                TempData["Message"] = "Employee deleted successfully";
            }
            return RedirectToAction("Index");
        }
    }
}