using Asset.BisnessLogic.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagement.Mvc.Models.ViewModels.Assets;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class AssetGroupsController : Controller
    {
        private readonly AssetTypeManager _assetTypeManager;

        private readonly AssetGroupManager _assetGroupManager;

        public AssetGroupsController()
        {
            _assetGroupManager = new AssetGroupManager();
            _assetTypeManager = new AssetTypeManager();
        }


        public JsonResult GetAllGroup()
        {
            var group = _assetGroupManager.GetAssetGroupsWithType();
            return Json(group, JsonRequestBehavior.AllowGet);
        }


        // GET: AssetGroups
        public ActionResult Index()
        {
            return View("AssetGroupList");
        }

        public ActionResult New()
        {
            var assetGroupVm = new AssetGroupViewModel()
            {
                AssetTypes = _assetTypeManager.GetAll()
            };
            return View("AssetGroupForm", assetGroupVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AssetGroupViewModel assetGroupVm)
        {
            var assetGroupVmDropdown = new AssetGroupViewModel()
            {
                AssetTypes = _assetTypeManager.GetAll()
            };

            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (assetGroupVm.Id == 0)
                {
                    bool isShortNameExist = _assetGroupManager.IsShortNameExist(assetGroupVm.ShortName, assetGroupVm.AssetTypeId);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This Group Short Name already Exist";
                        return View("AssetGroupForm", assetGroupVmDropdown);
                    }

                    var assetGroup = new AssetGroup()
                    {
                        Name = assetGroupVm.Name,
                        ShortName = assetGroupVm.ShortName,
                        AssetTypeId = assetGroupVm.AssetTypeId,
                        GroupCode = assetGroupVm.GroupCode
                    };

                    _assetGroupManager.Add(assetGroup);
                    ModelState.Clear();
                    return View("AssetGroupForm", assetGroupVmDropdown);
                }

                var assetGroupInDb = _assetGroupManager.Get(assetGroupVm.Id);

                if (assetGroupInDb == null)
                    return HttpNotFound();

                assetGroupInDb.Id = assetGroupVm.Id;
                assetGroupInDb.Name = assetGroupVm.Name;
                assetGroupInDb.ShortName = assetGroupVm.ShortName;
                assetGroupInDb.GroupCode = assetGroupVm.GroupCode;
                assetGroupInDb.AssetTypeId = assetGroupVm.AssetTypeId;

                _assetGroupManager.Update(assetGroupInDb);
                ModelState.Clear();
                return View("AssetGroupList");
            }
            return View("AssetGroupForm", assetGroupVmDropdown);

        }

        public ActionResult Edit(int id)
        {
            var assetGroup = _assetGroupManager.Get(id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }

            var assetGroupVm = new AssetGroupViewModel()
            {
                Name = assetGroup.Name,
                ShortName = assetGroup.ShortName,
                AssetTypeId = assetGroup.AssetTypeId,
                GroupCode = assetGroup.GroupCode,

                AssetTypes = _assetTypeManager.GetAll()
            };
            return View("AssetGroupForm", assetGroupVm);
        }

        public ActionResult Delete(int id)
        {
            var assetGroup = _assetGroupManager.Get(id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            _assetGroupManager.Remove(assetGroup);
            return View("AssetGroupList");
        }
    }
}