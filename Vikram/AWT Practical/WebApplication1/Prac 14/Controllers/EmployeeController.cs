using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prac_14.Models;

namespace Prac_14.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> _employees = new List<Employee>();
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View(_employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid) // Check if the model is valid
            {
                // Assign a unique ID to each employee
                emp.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;

                _employees.Add(emp);
                TempData["Message"] = "Employee added successfully";
                return RedirectToAction("Index");
            }

            return View(emp);
        }
    }
}