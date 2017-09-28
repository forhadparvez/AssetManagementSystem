using Asset.BisnessLogic.Library.AssetSetups;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
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

        // GET: AssetManufacturers
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            var manufactureVm = new AssetManufacturerViewModel()
            {
                AssetGroups = _assetGroupManager.GetAll()
            };
            return View("AssetManufacturerForm", manufactureVm);
        }

        [HttpPost]
        public ActionResult Save(AssetManufacturerViewModel assetManufacturerVm)
        {
            return View("AssetManufacturerForm");
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