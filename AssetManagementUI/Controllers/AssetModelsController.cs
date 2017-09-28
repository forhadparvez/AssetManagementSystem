using Asset.BisnessLogic.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
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



        // GET: AssetModels
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Save(AssetModelViewModel assetModelVm)
        {
            return View("AssetModelForm");
        }

        public ActionResult Edit(int id)
        {
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            return View("Index");
        }
    }
}