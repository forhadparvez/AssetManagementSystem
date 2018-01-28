using Asset.BisnessLogic.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagement.Mvc.Models.ViewModels.Assets;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class AssetTypesController : Controller
    {
        private readonly AssetTypeManager _assetTypeManager;

        public AssetTypesController()
        {
            _assetTypeManager = new AssetTypeManager();
        }

        // GET: AssetTypes
        public ActionResult Index()
        {
            return View("AssetTypeList");
        }

        public JsonResult GetAllAssetType()
        {
            var assetTypes = _assetTypeManager.GetAll();
            return Json(assetTypes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            return View("AssetTypeForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AssetTypeViewModel assetTypeVm)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (assetTypeVm.Id == 0)
                {
                    bool isShortNameExist = _assetTypeManager.IsShortNameExsit(assetTypeVm.ShortName);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This Type Short Name already Exist";
                        return View("AssetTypeForm");
                    }
                    var assetType = new AssetType()
                    {
                        Id = assetTypeVm.Id,
                        Name = assetTypeVm.Name,
                        ShortName = assetTypeVm.ShortName,
                        Code = assetTypeVm.Code
                    };
                    _assetTypeManager.Add(assetType);
                    ModelState.Clear();
                    return View("AssetTypeForm");
                }

                var assetTypeInDb = _assetTypeManager.Get(assetTypeVm.Id);
                assetTypeInDb.Id = assetTypeVm.Id;
                assetTypeInDb.Name = assetTypeVm.Name;
                assetTypeInDb.ShortName = assetTypeVm.ShortName;
                assetTypeInDb.Code = assetTypeVm.Code;

                _assetTypeManager.Update(assetTypeInDb);
                ModelState.Clear();
                return View("AssetTypeList");
            }
            return View("AssetTypeForm", assetTypeVm);

        }


        // GET: AssetType/Edit/1
        public ActionResult Edit(int id)
        {
            var assetType = _assetTypeManager.Get(id);
            if (assetType == null)
            {
                return HttpNotFound();
            }

            var assetTypeVm = new AssetTypeViewModel()
            {
                Id = assetType.Id,
                Name = assetType.Name,
                ShortName = assetType.ShortName,
                Code = assetType.Code
            };
            return View("AssetTypeForm", assetTypeVm);
        }


        // GET: AssetType/Delete/1
        public ActionResult Delete(int id)
        {
            var assetType = _assetTypeManager.Get(id);
            if (assetType == null)
            {
                return HttpNotFound();
            }
            _assetTypeManager.Remove(assetType);
            return View("AssetTypeList");
        }
    }
}