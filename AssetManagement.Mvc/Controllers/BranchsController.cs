using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagement.Mvc.Models.ViewModels.Organizations;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class BranchsController : Controller
    {
        private readonly BranchManager _branchManager;
        private readonly OrganizationManager _organizationManager;

        public BranchsController()
        {
            _branchManager = new BranchManager();
            _organizationManager = new OrganizationManager();
        }
        // GET: Branchs
        public ActionResult Index()
        {
            return View("BranchList");
        }

        // Get All Branch
        public JsonResult GetAllBranch()
        {
            var branches = _branchManager.GetBranchWithOrganization();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleOrganizationbyId(int id)
        {
            var org = _organizationManager.Get(id);
            return Json(org, JsonRequestBehavior.AllowGet);
        }

        // GET: Organizations/New
        public ActionResult New()
        {
            var branchVm = new BranchViewModel { Organizations = _organizationManager.GetAll() };

            return View("BranchForm", branchVm);
        }

        // POST: Organization/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BranchViewModel branchVm)
        {
            var branchVm2 = new BranchViewModel();
            branchVm2.Organizations = _organizationManager.GetAll();


            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (branchVm.Id == 0)
                {
                    bool isShortNameExist = _branchManager.IsBranchShortNameExist(branchVm.ShortName, branchVm.OrganizationId);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This Organization Short Name already Exist";

                        return View("BranchForm", branchVm2);
                    }

                    var branch = new Branch()
                    {
                        OrganizationId = branchVm.OrganizationId,
                        Name = branchVm.Name,
                        ShortName = branchVm.ShortName,
                        BranchCode = branchVm.BranchCode
                    };
                    _branchManager.Add(branch);

                    ModelState.Clear();
                    return View("BranchForm", branchVm2);
                }

                var branchInDb = _branchManager.SingleBranch(branchVm.Id);
                if (branchInDb == null)
                    return HttpNotFound();

                branchInDb.OrganizationId = branchVm.OrganizationId;
                branchInDb.Name = branchVm.Name;
                branchInDb.ShortName = branchVm.ShortName;
                branchInDb.BranchCode = branchVm.BranchCode;
                _branchManager.Update(branchInDb);
                ModelState.Clear();
                return View("BranchList");
            }

            return View("BranchForm", branchVm2);
        }

        // GET: /Organizations/Edit/1
        public ActionResult Edit(int id)
        {
            var branch = _branchManager.SingleBranch(id);
            if (branch == null)
                return HttpNotFound();

            var branchVm = new BranchViewModel()
            {
                Id = branch.Id,
                OrganizationId = branch.OrganizationId,
                Organizations = _organizationManager.GetAll(),
                Name = branch.Name,
                ShortName = branch.ShortName,
                BranchCode = branch.BranchCode
            };
            return View("BranchForm", branchVm);
        }

        // GET: /Organizations/Delete/1
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var organization = _branchManager.Get(id);
            if (organization == null)
            {
                return HttpNotFound();
            }

            _branchManager.Remove(organization);
            return View("BranchList");
        }
    }
}