using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class AssetGroupsController : Controller
    {
        // GET: AssetGroups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var assetGroupVm = new AssetGroupViewModels()
            {
                AssetTypes = new List<AssetType>()
                {

                }
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