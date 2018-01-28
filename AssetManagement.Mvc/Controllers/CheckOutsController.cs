using Asset.BisnessLogic.Library.AssetEntrys;
using Asset.BisnessLogic.Library.AssetOperation;
using Asset.BisnessLogic.Library.AssetSetups;
using Asset.BisnessLogic.Library.HRM;
using Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation;
using AssetManagement.Mvc.Dtos;
using AssetManagement.Mvc.Models.ViewModels.Assets;
using System;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class CheckOutsController : Controller
    {
        private readonly EmployeeManager _employeeManager;

        private readonly AssetLocationManager _assetLocationManager;

        private readonly AssetEntryManager _assetEntryManager;

        private readonly CheckOutManager _checkOutManager;

        public CheckOutsController()
        {
            _employeeManager = new EmployeeManager();
            _assetLocationManager = new AssetLocationManager();
            _assetEntryManager = new AssetEntryManager();
            _checkOutManager = new CheckOutManager();
        }

        // GET: CheckOuts/CheckOutForm
        public ActionResult Index()
        {
            var checkoutVm = new CheckOutViewModel
            {
                Employees = _employeeManager.GetAll(),
                AssetLocations = _assetLocationManager.GetAll(),
                AssetEntries = _assetEntryManager.GetAll(),
            };
            return View("CheckOutForm", checkoutVm);
        }

        [HttpPost]
        public JsonResult Save(CheckOutDto checkOutDto)
        {
            if (ModelState.IsValid)
            {

                var count = 0;
                foreach (var assetEntry in checkOutDto.AssetIds)
                {
                    var checkOut = new CheckOut
                    {
                        Employee = checkOutDto.EmployeeId,
                        AssetLocation = checkOutDto.AssetLocationId,
                        EntryDate = checkOutDto.EntryDate,
                        ReturnDate = checkOutDto.ReturnDate,
                        Commants = checkOutDto.Commants,
                        AssetEntry = assetEntry
                    };

                    count = _checkOutManager.Add(checkOut);
                }
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}