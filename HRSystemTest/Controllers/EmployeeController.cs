using HRSystemTest.Entities;
using HRSystemTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSystemTest.Controllers
{
    public class EmployeeController : Controller
    {
        private HRSystemDBEntities db = new HRSystemDBEntities();
        public ActionResult Index()
        {
            var empl = db.Departments.ToList();
            return View(empl);
        }

        #region Add Department
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department dep)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(dep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Add Role
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Add Employee
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            CreateEmployeeModel createEmployeeModel = new CreateEmployeeModel();
            createEmployeeModel.Employee = new Employee();


            List<SelectListItem> departments = db.Departments
               .OrderBy(m => m.Name)
               .Select(m => new SelectListItem
               {
                   Value = m.Id.ToString(),
                   Text = m.Name,
                   Selected = false
               }).ToList();
            createEmployeeModel.Departments = departments;

            return View(createEmployeeModel);
        }

        [HttpPost]
        public ActionResult CreateEmployee(CreateEmployeeModel createEmployeeModel)
        {
            createEmployeeModel.Employee.Dep_Id = createEmployeeModel.Employee.Dep_Id;


            db.Employees.Add(createEmployeeModel.Employee);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}