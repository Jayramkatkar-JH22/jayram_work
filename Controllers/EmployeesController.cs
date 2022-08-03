using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emp.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> emps = Employees.GetAllEmployees();
            

            return View(emps);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employees emp = Employees.GetDetails(id);
                if(emp==null)
                return RedirectToAction("Index");
            return View(emp);
        }
        
        // GET: Employee/Create
        public ActionResult Create()
        {
            
            return View();
        }
        
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            string Name = collection["Name"];
            int EmpNo = int.Parse(collection["EmpNo"]);
            int DeptNo = int.Parse(collection["DeptNo"]);
            decimal Basic = decimal.Parse(collection["Basic"]);
            Employees obj = new Employees { EmpNo = EmpNo, Name = Name, Basic = Basic, DeptNo = DeptNo };
            try
            {
                // TODO: Add insert logic here
                Employees.AddNewEmployee(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employees emp = Employees.GetDetails(id);
            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            string Name = collection["Name"];
            int EmpNo = id;
            int DeptNo = int.Parse(collection["DeptNo"]);
            decimal Basic = decimal.Parse(collection["Basic"]);
            
            try
            {
                // TODO: Add update logic here
                Employees.UpdateEmployees(id, Name, Basic, DeptNo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employees emp = Employees.GetDetails(id);
            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Employees.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                
                return View();
            }
        }
    }
}
