using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels.AssetSetups;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class AssetLocationsController : Controller
    {
        // GET: AssetLocations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var assetLocationVm = new AssetLocationViewModel()
            {
                Organizations = new List<Organization>()
                {

                },
                Branches = new List<Branch>()
                {

                }
            };
            return View("AssetLocationForm", assetLocationVm);
        }

        [HttpPost]
        public ActionResult Save(AssetLocationViewModel assetLocationVm)
        {
            return View("AssetLocationForm");
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