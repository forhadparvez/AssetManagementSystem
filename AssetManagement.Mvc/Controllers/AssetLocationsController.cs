using Asset.BisnessLogic.Library.AssetSetups;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagement.Mvc.Models.ViewModels.Organizations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class AssetLocationsController : Controller
    {
        private readonly AssetLocationManager _assetLocationManager;
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;

        public AssetLocationsController()
        {
            _assetLocationManager = new AssetLocationManager();
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
        }

        // GET: AssetLocations
        public ActionResult Index()
        {
            return View("LocationList");
        }

        public JsonResult GetAllAssetLocation()
        {
            var locations = _assetLocationManager.GetAllByOrgAndBroanc();
            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleOrgById(int orgId)
        {
            var org = _organizationManager.FindById(orgId);
            return Json(org, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchByOrgId(int orgId)
        {
            var branchs = _branchManager.GetBranchByOrgId(orgId);
            return Json(branchs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleBranchById(int branchId)
        {
            var branch = _branchManager.FindById(branchId);
            return Json(branch, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var assetLocationVm = new AssetLocationViewModel()
            {
                Organizations = _organizationManager.GetAll(),
                Branches = new List<Branch>()
                {

                }
            };
            return View("LocationForm", assetLocationVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AssetLocationViewModel assetLocationVm)
        {
            var assetLocationVmDropdown = new AssetLocationViewModel()
            {
                Organizations = _organizationManager.GetAll(),
                Branches = new List<Branch>()
                {

                }
            };

            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (assetLocationVm.Id == 0)
                {
                    bool isShortNameExist = _assetLocationManager.IsShortNameExist(assetLocationVm.ShortName, assetLocationVm.OrganizationId, assetLocationVm.BranchId);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This Location Short Name already Exist";
                        return View("LocationForm", assetLocationVmDropdown);
                    }
                    var location = new AssetLocation()
                    {
                        OrganizationId = assetLocationVm.OrganizationId,
                        BranchId = assetLocationVm.BranchId,
                        Name = assetLocationVm.Name,
                        ShortName = assetLocationVm.ShortName,
                        BranchCode = assetLocationVm.LocationCode
                    };
                    _assetLocationManager.Add(location);
                    ModelState.Clear();
                    return View("LocationForm", assetLocationVmDropdown);
                }

                var locationInDb = _assetLocationManager.Get(assetLocationVm.Id);
                locationInDb.Id = assetLocationVm.Id;
                locationInDb.Name = assetLocationVm.Name;
                locationInDb.ShortName = assetLocationVm.ShortName;
                locationInDb.BranchCode = assetLocationVm.LocationCode;
                locationInDb.OrganizationId = assetLocationVm.OrganizationId;
                locationInDb.BranchId = assetLocationVm.BranchId;

                _assetLocationManager.Update(locationInDb);
                ModelState.Clear();
                return View("LocationList");
            }
            return View("LocationForm", assetLocationVmDropdown);

        }
    }
}