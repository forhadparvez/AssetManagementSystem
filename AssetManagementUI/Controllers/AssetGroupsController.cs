using Asset.BisnessLogic.Library.AssetSetups;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
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

        // GET: AssetGroups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var assetGroupVm = new AssetGroupViewModels()
            {
                AssetTypes = _assetTypeManager.GetAll()
            };
            return View("AssetGroupForm", assetGroupVm);
        }

        [HttpPost]
        public ActionResult Save(AssetGroupViewModels assetGroupVm)
        {
            return View("AssetGroupForm");
        }


        public ActionResult Edit(int id)
        {
            return View("AssetGroupForm");
        }

        public ActionResult Delete(int id)
        {
            return View("Index");
        }

    }
}