using Asset.Models.Library.EntityModels;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagementUI.ViewModels.AssetEntrys;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagementUI.Controllers
{
    public class AssetEntrysController : Controller
    {
        // GET: AssetEntrys
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var assetEntryVm = new AssetEntryViewModel()
            {
                Organizations = new List<Organization>() { },
                Branches = new List<Branch>() { },
                AssetLocations = new List<AssetLocation>() { },
                AssetTypes = new List<AssetType>() { },
                AssetGroups = new List<AssetGroup>() { },
                AssetManufacurers = new List<AssetManufacurer>() { },
                AssetModels = new List<AssetModel>() { },
                Status = new List<Status>() { }
            };
            return View("AssetEntryForm", assetEntryVm);
        }

        [HttpPost]
        public ActionResult Save(AssetEntryViewModel assetEntryVm)
        {
            return View("AssetEntryForm");
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