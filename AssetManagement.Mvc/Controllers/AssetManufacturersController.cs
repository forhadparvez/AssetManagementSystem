using Asset.BisnessLogic.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagement.Mvc.Models.ViewModels.Assets;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class AssetManufacturersController : Controller
    {
        private readonly AssetManufacturerManager _manufacturerManager;
        private readonly AssetGroupManager _assetGroupManager;


        public AssetManufacturersController()
        {
            _assetGroupManager = new AssetGroupManager();
            _manufacturerManager = new AssetManufacturerManager();
        }

        public JsonResult GetAllManufacturer()
        {
            var manufactuers = _manufacturerManager.GetAllManufacturerWithGroup();
            return Json(manufactuers, JsonRequestBehavior.AllowGet);
        }

        // GET: AssetManufacturers
        public ActionResult Index()
        {
            return View("ManufactuerList");
        }

        public ActionResult New()
        {
            var manufactureVm = new AssetManufacturerViewModel()
            {
                AssetGroups = _assetGroupManager.GetAll()
            };
            return View("ManufacturerForm", manufactureVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AssetManufacturerViewModel assetManufacturerVm)
        {
            var manufactureVmDropdown = new AssetManufacturerViewModel()
            {
                AssetGroups = _assetGroupManager.GetAll()
            };

            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (assetManufacturerVm.Id == 0)
                {
                    bool isShortNameExist =
                        _manufacturerManager.IsShortNameExist(assetManufacturerVm.ShortName,
                            assetManufacturerVm.AssetGroupId);
                    if (isShortNameExist)
                    {
                        ViewBag.Message = "This  Short Name already Exist";
                        return View("ManufacturerForm", manufactureVmDropdown);
                    }
                    var manufacturer = new AssetManufacurer()
                    {
                        Name = assetManufacturerVm.Name,
                        ShortName = assetManufacturerVm.ShortName,
                        AssetGroupId = assetManufacturerVm.AssetGroupId,
                        Code = assetManufacturerVm.Code,
                        Description = assetManufacturerVm.Description
                    };

                    _manufacturerManager.Add(manufacturer);
                    ModelState.Clear();
                    return View("ManufacturerForm", manufactureVmDropdown);
                }

                var manufacturerInDb = _manufacturerManager.Get(assetManufacturerVm.Id);
                manufacturerInDb.Id = assetManufacturerVm.Id;
                manufacturerInDb.Name = assetManufacturerVm.Name;
                manufacturerInDb.ShortName = assetManufacturerVm.ShortName;
                manufacturerInDb.Code = assetManufacturerVm.Code;
                manufacturerInDb.Description = assetManufacturerVm.Description;
                manufacturerInDb.AssetGroupId = assetManufacturerVm.AssetGroupId;

                _manufacturerManager.Update(manufacturerInDb);
                ModelState.Clear();
                return View("ManufactuerList");
            }
            return View("ManufacturerForm", manufactureVmDropdown);
        }

        public ActionResult Edit(int id)
        {
            var manufacturer = _manufacturerManager.Get(id);
            if (manufacturer == null)
                return HttpNotFound();
            var manufactuerVm = new AssetManufacturerViewModel()
            {
                Name = manufacturer.Name,
                ShortName = manufacturer.ShortName,
                AssetGroupId = manufacturer.AssetGroupId,
                Code = manufacturer.Code,
                Description = manufacturer.Description,
                AssetGroups = _assetGroupManager.GetAll()
            };
            return View("ManufacturerForm", manufactuerVm);
        }

        public ActionResult Delete(int id)
        {
            var manufacturer = _manufacturerManager.Get(id);
            if (manufacturer == null)
                return HttpNotFound();

            _manufacturerManager.Remove(manufacturer);
            return View("ManufactuerList");
        }
    }
}