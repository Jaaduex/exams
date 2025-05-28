using EmployeeMVCFramework.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeMVCFramework.Controllers
{
    public class EmployeeController : Controller
    {
        // Temporary storage for employees (Simulating database)
        private static List<Employee> _employees = new List<Employee>();

        // GET: Employee List
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"]; // Retrieve success message
            return View(_employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
            {
            if (ModelState.IsValid) 
            {
                employee.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;

                _employees.Add(employee);
                TempData["Message"] = "Employee added successfully";
                return RedirectToAction("Index");
            }

            return View(employee);
        }
    }
}
