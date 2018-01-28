using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagement.Mvc.Models.ViewModels.Organizations;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly OrganizationManager _organizationManager;

        public OrganizationsController()
        {
            _organizationManager = new OrganizationManager();
        }

        // GET: Organizations
        public ActionResult Index()
        {
            return View("OrgList");
        }

        // Get All Organization
        public JsonResult GetAllOrganization()
        {
            var organizations = _organizationManager.GetAll();
            return Json(organizations, JsonRequestBehavior.AllowGet);
        }

        // check ShortName
        public JsonResult IsShortNameExist(string shortName)
        {
            bool isShortNameExist = _organizationManager.IsShortNameExist(shortName);
            return Json(isShortNameExist, JsonRequestBehavior.AllowGet);
        }

        // GET: Organizations/New
        public ActionResult New()
        {
            return View("OrganizationForm");
        }

        // POST: Organization/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(OrganizationViewModel organizationVm)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (organizationVm.Id == 0)
                {
                    bool isShortNameExist = _organizationManager.IsShortNameExist(organizationVm.ShortName);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This Organization Short Name already Exist";
                        return View("OrganizationForm");
                    }
                    var organization = new Organization()
                    {
                        Name = organizationVm.Name,
                        ShortName = organizationVm.ShortName,
                        Location = organizationVm.Location,
                        Description = organizationVm.Description
                    };
                    _organizationManager.Add(organization);

                    ModelState.Clear();
                    return View("OrganizationForm");
                }

                var organizationInDb = _organizationManager.SingleOrganization(organizationVm.Id);
                if (organizationInDb == null)
                    return HttpNotFound();

                organizationInDb.Name = organizationVm.Name;
                organizationInDb.ShortName = organizationVm.ShortName;
                organizationInDb.Description = organizationVm.Description;
                organizationInDb.Location = organizationVm.Location;

                _organizationManager.Update(organizationInDb);

                ModelState.Clear();
                return View("OrgList");
            }

            return View("OrganizationForm", organizationVm);

        }


        // GET: /Organizations/Edit/1
        public ActionResult Edit(int id)
        {
            var organization = _organizationManager.SingleOrganization(id);
            if (organization == null)
                return HttpNotFound();

            var organizationVm = new OrganizationViewModel()
            {
                Name = organization.Name,
                ShortName = organization.ShortName,
                Location = organization.Location,
                Description = organization.Description
            };
            return View("OrganizationForm", organizationVm);
        }


        // GET: /Organizations/Delete/1

        public ActionResult Delete(int id)
        {
            var organization = _organizationManager.Get(id);
            if (organization == null)
            {
                return HttpNotFound();
            }

            _organizationManager.Remove(organization);
            return View("OrgList");
        }
    }
}