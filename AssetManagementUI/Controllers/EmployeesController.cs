using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels.HRM;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            var employeeVm = new EmployeeViewModel()
            {
                Organizations = new List<Organization>()
                {

                },
                Branches = new List<Branch>()
                {

                },
                Departments = new List<Department>()
                {

                },
                Designations = new List<Designation>()
                {

                }
            };
            return View("EmployeeForm", employeeVm);
        }

        [HttpPost]
        public ActionResult Save(EmployeeViewModel employeeVm)
        {
            return View("EmployeeForm");
        }

        public ActionResult Edit(int id)
        {
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            return View("Index");
        }
    }
}