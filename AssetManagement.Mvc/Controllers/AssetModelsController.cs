using Asset.BisnessLogic.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagement.Mvc.Models.ViewModels.Assets;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class AssetModelsController : Controller
    {
        private readonly AssetGroupManager _assetGroupManager;
        private readonly AssetManufacturerManager _manufacturerManager;
        private readonly AssetModelManager _assetModelManager;

        public AssetModelsController()
        {
            _assetGroupManager = new AssetGroupManager();
            _assetModelManager = new AssetModelManager();
            _manufacturerManager = new AssetManufacturerManager();
        }


        public JsonResult GetAllModel()
        {
            var models = _assetModelManager.GetAllByGroupAndManufacturer();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManufacturerByGroupid(int groupId)
        {
            var managactuer = _manufacturerManager.GetManufacurersByGroupId(groupId);
            return Json(managactuer, JsonRequestBehavior.AllowGet);
        }


        // GET: AssetModels
        public ActionResult Index()
        {
            return View("AssetModelList");
        }

        public ActionResult New()
        {
            var assetModelVm = new AssetModelViewModel()
            {
                AssetGroups = _assetGroupManager.GetAll(),
                AssetManufacurers = new List<AssetManufacurer>()
                {

                }

            };
            return View("AssetModelForm", assetModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AssetModelViewModel assetModelVm)
        {
            var assetModelVmforDropdown = new AssetModelViewModel()
            {
                AssetGroups = _assetGroupManager.GetAll(),
                AssetManufacurers = new List<AssetManufacurer>() { }
            };

            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (assetModelVm.Id == 0)
                {
                    bool isShortNameExist = _assetModelManager.IsShortNameExist(assetModelVm.ShortName, assetModelVm.AssetGroupId, assetModelVm.AssetManufacurerId);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This Organization Short Name already Exist";
                        return View("AssetModelForm", assetModelVmforDropdown);
                    }


                    var assetModel = new AssetModel()
                    {
                        Name = assetModelVm.Name,
                        ShortName = assetModelVm.ShortName,
                        Code = assetModelVm.Code,
                        Description = assetModelVm.Description,
                        AssetGroupId = assetModelVm.AssetGroupId,
                        AssetManufacurerId = assetModelVm.AssetManufacurerId
                    };

                    _assetModelManager.Add(assetModel);

                    ModelState.Clear();
                    return View("AssetModelForm", assetModelVmforDropdown);
                }

                var modelInDb = _assetModelManager.Get(assetModelVm.Id);
                modelInDb.Id = assetModelVm.Id;
                modelInDb.Name = assetModelVm.Name;
                modelInDb.ShortName = assetModelVm.ShortName;
                modelInDb.Code = assetModelVm.Code;
                modelInDb.Description = assetModelVm.Description;
                modelInDb.AssetGroupId = assetModelVm.AssetGroupId;
                modelInDb.AssetManufacurerId = assetModelVm.AssetManufacurerId;

                _assetModelManager.Update(modelInDb);
                ModelState.Clear();
                return View("AssetModelList");
            }
            return View("AssetModelForm", assetModelVmforDropdown);
        }


        public ActionResult Edit(int id)
        {
            var model = _assetModelManager.Get(id);
            if (model == null)
                return HttpNotFound();

            var viewModel = new AssetModelViewModel()
            {
                Name = model.Name,
                ShortName = model.ShortName,
                Code = model.Code,
                Description = model.Description,
                AssetGroupId = model.AssetGroupId,
                AssetManufacurerId = model.AssetManufacurerId,
                AssetGroups = _assetGroupManager.GetAll(),
                AssetManufacurers = _manufacturerManager.GetManufacurersByGroupId(model.AssetGroupId)
            };
            return View("AssetModelForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var model = _assetModelManager.Get(id);
            if (model == null)
                return HttpNotFound();

            _assetModelManager.Remove(model);
            return View("AssetModelList");
        }
    }
}