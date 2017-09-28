using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class AssetModelsController : Controller
    {
        // GET: AssetModels
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var assetModelVm = new AssetModelViewModel()
            {
                AssetManufacurers = new List<AssetManufacurer>()
                {

                },
                AssetGroups = new List<AssetGroup>()
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