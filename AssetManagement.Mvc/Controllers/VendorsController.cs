using Asset.BisnessLogic.Library.Purcheses;
using Asset.Models.Library.EntityModels.Purchases;
using AssetManagement.Mvc.Models.ViewModels.Purchase;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class VendorsController : Controller
    {
        private readonly VendorManager _vendorManager;

        public VendorsController()
        {
            _vendorManager = new VendorManager();
        }


        public JsonResult GetAllVendor()
        {
            var vendors = _vendorManager.GetAll();
            return Json(vendors, JsonRequestBehavior.AllowGet);
        }


        // GET: Vendors
        public ActionResult Index()
        {
            return View("VendorList");
        }

        public ActionResult New()
        {
            return View("VendorForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VendorViewModel vendorVm)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (vendorVm.Id == 0)
                {
                    var vendor = new Vendor()
                    {
                        Name = vendorVm.Name,
                        ShortName = vendorVm.ShortName,
                        Email = vendorVm.Email,
                        ContactNo = vendorVm.ContactNo,
                        Address = vendorVm.Address,
                        Comments = vendorVm.Comments
                    };

                    _vendorManager.Add(vendor);
                    ModelState.Clear();
                    return View("VendorForm");
                }
                var vendorInDb = _vendorManager.Get(vendorVm.Id);
                vendorInDb.Id = vendorVm.Id;
                vendorInDb.Name = vendorVm.Name;
                vendorInDb.ShortName = vendorVm.ShortName;
                vendorInDb.Comments = vendorVm.Comments;
                vendorInDb.ContactNo = vendorVm.ContactNo;
                vendorInDb.Email = vendorVm.Email;
                vendorInDb.Address = vendorVm.Address;

                _vendorManager.Update(vendorInDb);
                ModelState.Clear();
                return View("VendorList");
            }
            return View("VendorForm", vendorVm);

        }

        public ActionResult Edit(int id)
        {
            var vendor = _vendorManager.Get(id);
            if (vendor == null)
                return HttpNotFound();

            var vendorVm = new VendorViewModel()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                ShortName = vendor.ShortName,
                Email = vendor.Email,
                ContactNo = vendor.ContactNo,
                Address = vendor.Address,
                Comments = vendor.Comments
            };
            return View("VendorForm", vendorVm);
        }

        public ActionResult Delete(int id)
        {
            var vendor = _vendorManager.Get(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            _vendorManager.Remove(vendor);
            return View("VendorList");
        }
    }
}