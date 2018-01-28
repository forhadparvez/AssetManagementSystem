using Asset.BisnessLogic.Library.HRM;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.HrModels;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagement.Mvc.Models.ViewModels.HumanResorce;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManager _employeeManager;
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;

        public EmployeesController()
        {
            _employeeManager = new EmployeeManager();
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
        }

        public JsonResult GetAllEmployee()
        {
            var employees = _employeeManager.GetEmployeesWithOrganization();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchByOrgId(int orgId)
        {
            var branchs = _branchManager.GetBranchByOrgId(orgId);
            return Json(branchs, JsonRequestBehavior.AllowGet);
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View("EmployeeList");
        }

        public ActionResult New()
        {
            var employeeVm = new EmployeeViewModel()
            {
                Organizations = _organizationManager.GetAll(),
                Branchs = new List<Branch>()
            };

            return View("EmployeeForm", employeeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeViewModel employeeVm)
        {
            var employeeVmDropdown = new EmployeeViewModel()
            {
                Organizations = _organizationManager.GetAll(),
                Branchs = new List<Branch>()
            };

            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (employeeVm.Id == 0)
                {
                    var employee = new Employee()
                    {
                        FirstName = employeeVm.FirstName,
                        LastName = employeeVm.LastName,
                        ContactNo = employeeVm.ContactNo,
                        Email = employeeVm.Email,
                        Address = employeeVm.Address,
                        Code = employeeVm.Code,
                        OrganizationId = employeeVm.OrganizationId,
                        BranchId = employeeVm.BranchId,
                        Department = employeeVm.Department,
                        Designation = employeeVm.Designation
                    };

                    _employeeManager.Add(employee);
                    ModelState.Clear();
                    return View("EmployeeForm", employeeVmDropdown);
                }
                var employeeInDb = _employeeManager.Get(employeeVm.Id);
                employeeInDb.Id = employeeVm.Id;
                employeeInDb.FirstName = employeeVm.FirstName;
                employeeInDb.LastName = employeeVm.LastName;
                employeeInDb.ContactNo = employeeVm.ContactNo;
                employeeInDb.Email = employeeVm.Email;
                employeeInDb.Address = employeeVm.Address;
                employeeInDb.Code = employeeVm.Code;
                employeeInDb.OrganizationId = employeeVm.OrganizationId;
                employeeInDb.BranchId = employeeVm.BranchId;
                employeeInDb.Department = employeeVm.Department;
                employeeInDb.Designation = employeeVm.Designation;

                _employeeManager.Update(employeeInDb);
                ModelState.Clear();
                return View("EmployeeList");
            }

            return View("EmployeeForm", employeeVmDropdown);
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeManager.Get(id);
            if (employee == null)
                return HttpNotFound();

            var employeeVm = new EmployeeViewModel()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ContactNo = employee.ContactNo,
                Email = employee.Email,
                Address = employee.Address,
                Code = employee.Code,
                OrganizationId = employee.OrganizationId,
                BranchId = employee.BranchId,
                Department = employee.Department,
                Designation = employee.Designation,
                Organizations = _organizationManager.GetAll(),
                Branchs = _branchManager.GetBranchByOrgId(employee.OrganizationId)
            };

            return View("EmployeeForm", employeeVm);
        }

        public ActionResult Delete(int id)
        {
            var employee = _employeeManager.Get(id);
            if (employee == null)
                return HttpNotFound();

            _employeeManager.Remove(employee);
            return View("EmployeeList");
        }
    }
}