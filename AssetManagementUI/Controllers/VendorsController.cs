using AssetManagementUI.ViewModels.Purchases;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class VendorsController : Controller
    {
        // GET: Vendors
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            return View("VendorForm");
        }

        [HttpPost]
        public ActionResult Save(VendorViewModel vendorVm)
        {
            return View("VendorForm");
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