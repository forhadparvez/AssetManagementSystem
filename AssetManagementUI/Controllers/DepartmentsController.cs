using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentManager _departmentManager;
        private readonly OrganizationManager _organizationManager;

        public DepartmentsController()
        {
            _departmentManager = new DepartmentManager();
            _organizationManager = new OrganizationManager();
        }



        // GET: Department
        public ViewResult Index()
        {
            return View();
        }

        // Get All Department
        public JsonResult GetAllDepartment()
        {
            var departments = _departmentManager.GetDepartmentWithOrganization();

            return Json(departments, JsonRequestBehavior.AllowGet);
        }


        // GET: Organizations/New
        public ActionResult New()
        {
            var departmentVm = new DepartmentViewModel();
            departmentVm.Organizations = _organizationManager.GetAll();
            return View("DepartmentForm", departmentVm);
        }


        // POST: Organization/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DepartmentViewModel departmentVm)
        {
            var departmnet2Vm = new DepartmentViewModel();
            departmnet2Vm.Organizations = _organizationManager.GetAll();

            if (departmentVm.Department.Id == 0)
            {
                bool isShortNameExist = _departmentManager.IsDepartmentShortNameExist(departmentVm.Department.ShortName);
                if (isShortNameExist)
                {
                    ViewBag.CssClass = "alert alert-warning";
                    ViewBag.MessageType = "Warning! ";
                    ViewBag.Message = "This Organization Short Name already Exist";
                    return View("DepartmentForm", departmnet2Vm);
                }

                var organization = new Department()
                {
                    OrganizationId = departmentVm.Department.OrganizationId,
                    Name = departmentVm.Department.Name,
                    ShortName = departmentVm.Department.ShortName,
                    DepartmentCode = departmentVm.Department.DepartmentCode
                };
                _departmentManager.Add(organization);

                ModelState.Clear();
                return View("DepartmentForm", departmnet2Vm);
            }

            var departmentInDb = _departmentManager.SingleDepartment(departmentVm.Department.Id);
            departmentInDb.OrganizationId = departmentVm.Department.OrganizationId;
            departmentInDb.Name = departmentVm.Department.Name;
            departmentInDb.ShortName = departmentVm.Department.ShortName;
            departmentInDb.DepartmentCode = departmentVm.Department.DepartmentCode;
            _departmentManager.Update(departmentInDb);

            ModelState.Clear();
            return View("Index");


        }


        // GET: /Organizations/Edit/1
        public ActionResult Edit(int id)
        {
            var department = _departmentManager.SingleDepartment(id);
            if (department == null)
                return HttpNotFound();

            DepartmentViewModel departmentVm = null;
            departmentVm = new DepartmentViewModel()
            {
                Department = department,
                Organizations = _organizationManager.GetAll()
            };
            return View("DepartmentForm", departmentVm);
        }


        // GET: /Organizations/Delete/1

        public ActionResult Delete(int id)
        {
            var department = _departmentManager.Get(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            _departmentManager.Remove(department);
            return View("Index");
        }
    }
}