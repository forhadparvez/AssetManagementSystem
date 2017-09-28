using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class AssetManufacturersController : Controller
    {
        // GET: AssetManufacturers
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            var manufactureVm = new AssetManufacturerViewModel()
            {
                AssetGroups = new List<AssetGroup>()
                {

                }
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