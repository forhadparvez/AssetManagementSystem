using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
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
        public ViewResult Index()
        {
            return View();
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
            var branchVm = new BranchViewModel();
            branchVm.Organizations = _organizationManager.GetAll();

            return View("BranchForm", branchVm);
        }

        // POST: Organization/Save
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BranchViewModel branchVm)
        {
            var branchVm2 = new BranchViewModel();
            branchVm2.Organizations = _organizationManager.GetAll();

            if (branchVm.Branch.Id == 0)
            {
                bool isShortNameExist = _branchManager.IsBranchShortNameExist(branchVm.Branch.ShortName);
                if (isShortNameExist)
                {
                    ViewBag.CssClass = "alert alert-warning";
                    ViewBag.MessageType = "Warning! ";
                    ViewBag.Message = "This Organization Short Name already Exist";


                    return View("BranchForm", branchVm2);
                }

                var branch = new Branch()
                {
                    OrganizationId = branchVm.Branch.OrganizationId,
                    Name = branchVm.Branch.Name,
                    ShortName = branchVm.Branch.ShortName,
                    BranchCode = branchVm.Branch.BranchCode
                };
                _branchManager.Add(branch);

                ModelState.Clear();
                return View("BranchForm", branchVm2);
            }

            var branchInDb = _branchManager.SingleBranch(branchVm.Branch.Id);
            branchInDb.OrganizationId = branchVm.Branch.OrganizationId;
            branchInDb.Name = branchVm.Branch.Name;
            branchInDb.ShortName = branchVm.Branch.ShortName;
            branchInDb.BranchCode = branchVm.Branch.BranchCode;
            _branchManager.Update(branchInDb);
            ModelState.Clear();
            return View("Index");


        }


        // GET: /Organizations/Edit/1
        public ActionResult Edit(int id)
        {
            var branch = _branchManager.SingleBranch(id);
            if (branch == null)
                return HttpNotFound();

            var branchVm = new BranchViewModel()
            {
                Branch = branch,
                Organizations = _organizationManager.GetAll()
            };
            return View("BranchForm", branchVm);
        }


        // GET: /Organizations/Delete/1

        public ActionResult Delete(int id)
        {
            var organization = _branchManager.Get(id);
            if (organization == null)
            {
                return HttpNotFound();
            }

            _branchManager.Remove(organization);
            return View("Index");
        }
    }
}