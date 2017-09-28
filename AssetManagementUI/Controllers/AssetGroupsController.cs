using AssetManagementUI.ViewModels.AssetSetups;
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
            return View("AssetGroupForm");
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