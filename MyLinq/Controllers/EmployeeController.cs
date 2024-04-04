using MyLinq.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLinq.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeIndex()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var list = db.Employees.ToList();

            return View();
        }
        [HttpGet]

        public ActionResult EmployeeUpdate(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirEmployee = db.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();

            return View(getirEmployee);

        }
        [HttpPost]//post işlemleri; edit,remove,insert...

        public ActionResult EmployeeUpdate(Employees employees)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirEmployee = db.Employees.Where(e => e.EmployeeID == employees.EmployeeID).FirstOrDefault();
            getirEmployee.FirstName = employees.FirstName;

          


            db.SaveChanges();
            return View();
        }
    }
}