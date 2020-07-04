using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_LINQ_SP_MVC.Models;

namespace CRUD_LINQ_SP_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: Employee
        public ActionResult Index()
        {
            // Here we call the store procedure SP_EMP, to select all data

            var getEmRecords =  dc.SP_EMP(null,null,null,null,"SELECT").ToList();

            return View(getEmRecords);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var emDetails = dc.SP_EMP(id,null,null,null,"DETAILS").Single(x => x.EMID == id);
            return View(emDetails);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                dc.SP_EMP(null,employee.emname, employee.email, employee.salary, "INSERT");
                dc.SubmitChanges();
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
            var emDetails = dc.SP_EMP(id, null, null, null, "DETAILS").Single(x => x.EMID == id);
            return View(emDetails);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                dc.SP_EMP(id, employee.emname, employee.email, employee.salary, "UPDATE");
                dc.SubmitChanges();
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
            var emDetails = dc.SP_EMP(id, null, null, null, "DETAILS").Single(x => x.EMID == id);
            return View(emDetails);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                dc.SP_EMP(id,null,null,null,"DELETE");
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
