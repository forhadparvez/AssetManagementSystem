using AssetManagementUI.ViewModels.AssetSetups;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class AssetTypesController : Controller
    {
        // GET: AssetTypes
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            return View("AssetTypeForm");
        }

        [HttpPost]
        public ActionResult Save(AssetTypeViewModels assetTypeVm)
        {
            return View("AssetTypeForm");
        }


        // GET: AssetType/Edit/1
        public ActionResult Edit(int id)
        {
            return View("AssetTypeForm");
        }


        // GET: AssetType/Delete/1
        public ActionResult Delete(int id)
        {
            return View("Index");
        }

    }
}