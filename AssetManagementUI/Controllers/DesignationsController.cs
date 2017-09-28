using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class DesignationsController : Controller
    {
        private readonly DesignationManager _designationManager;

        public DesignationsController()
        {
            _designationManager = new DesignationManager();
        }

        // GET: Designations
        public ViewResult Index()
        {
            return View();
        }

        // Get All Department
        public JsonResult GetAllDesignation()
        {
            var designations = _designationManager.GetDesignationsWithDepartment();
            return Json(designations, JsonRequestBehavior.AllowGet);
        }


        // GET: Organizations/New
        public ActionResult New()
        {
            return View("DesignationForm");
        }

        // POST: Organization/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DesignationViewModel designationVm)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("DepartmentForm");
            //}
            bool isShortNameExist = _designationManager.IsDesignationShortNameExist(designationVm.ShortName);
            if (isShortNameExist)
            {
                ViewBag.CssClass = "alert alert-warning";
                ViewBag.MessageType = "Warning! ";
                ViewBag.Message = "This Organization Short Name already Exist";
                return View("DesignationForm");
            }
            if (designationVm.Id == 0)
            {
                var designation = new Designation()
                {
                    DepartmentId = designationVm.DepartmentId,
                    Name = designationVm.Name,
                    ShortName = designationVm.ShortName
                };
                _designationManager.Add(designation);

                ModelState.Clear();
                return View("DesignationForm");
            }

            var designationInDb = _designationManager.SingleDesignation(designationVm.Id);
            designationInDb.DepartmentId = designationInDb.DepartmentId;
            designationInDb.Name = designationInDb.Name;
            designationInDb.ShortName = designationInDb.ShortName;

            _designationManager.Update(designationInDb);

            ModelState.Clear();
            return View("Index");


        }


        // GET: /Organizations/Edit/1
        public ActionResult Edit(int id)
        {
            var designation = _designationManager.SingleDesignation(id);
            if (designation == null)
                return HttpNotFound();

            DesignationViewModel designationVm = null;
            designationVm = new DesignationViewModel
            {
                DepartmentId = designationVm.DepartmentId,
                Name = designationVm.Name,
                ShortName = designationVm.ShortName
            };
            return View("DesignationForm", designationVm);
        }


        // GET: /Organizations/Delete/1

        public ActionResult Delete(int id)
        {
            var department = _designationManager.Get(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            _designationManager.Remove(department);
            return View("Index");
        }
    }
}