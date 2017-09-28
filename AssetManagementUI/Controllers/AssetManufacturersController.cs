using AssetManagementUI.ViewModels.AssetSetups;
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
            return View("AssetManufacturerForm");
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