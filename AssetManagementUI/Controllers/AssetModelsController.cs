using AssetManagementUI.ViewModels.AssetSetups;
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
            return View("AssetModelForm");
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