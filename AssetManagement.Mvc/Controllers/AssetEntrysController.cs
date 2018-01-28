using Asset.BisnessLogic.Library.AssetEntrys;
using Asset.BisnessLogic.Library.AssetSetups;
using Asset.BisnessLogic.Library.Organizations;
using Asset.BisnessLogic.Library.Purcheses;
using Asset.Models.Library.EntityModels;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetManagement.Mvc.Models.ViewModels.Assets;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetManagement.Mvc.Controllers
{
    public class AssetEntrysController : Controller
    {
        public int AssetTableId { get; set; }

        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;
        private readonly AssetLocationManager _assetLocationManager;

        private readonly AssetTypeManager _assetTypeManager;
        private readonly AssetGroupManager _assetGroupManager;
        private readonly AssetManufacturerManager _assetManufacturerManager;
        private readonly AssetModelManager _assetModelManager;

        private readonly AssetEntryManager _assetEntryManager;

        private readonly FinanceManager _financeManager;
        private readonly ServiceOrRepairingManager _serviceOrRepairingManager;
        private readonly NoteManager _noteManager;
        private readonly AttachmentManager _attachmentManager;

        private readonly VendorManager _vendorManager;



        public AssetEntrysController()
        {
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
            _assetLocationManager = new AssetLocationManager();

            _assetTypeManager = new AssetTypeManager();
            _assetGroupManager = new AssetGroupManager();
            _assetManufacturerManager = new AssetManufacturerManager();
            _assetModelManager = new AssetModelManager();

            _assetEntryManager = new AssetEntryManager();
            _financeManager = new FinanceManager();
            _serviceOrRepairingManager = new ServiceOrRepairingManager();
            _noteManager = new NoteManager();
            _attachmentManager = new AttachmentManager();

            _vendorManager = new VendorManager();
        }

        // ******************** dropdown value ***************
        public JsonResult GetBranchByOrgId(int orgId)
        {
            var branchs = _branchManager.GetBranchByOrgId(orgId);
            return Json(branchs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAssetLocationByBranchId(int branchId)
        {
            var locations = _assetLocationManager.GetAssetLocationByBranchId(branchId);
            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGroupByTypeId(int typeId)
        {
            var groups = _assetGroupManager.GetAssetGroupsByType(typeId);
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManufacturerByGroupId(int groupId)
        {
            var manufacturer = _assetManufacturerManager.GetManufacurersByGroupId(groupId);
            return Json(manufacturer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllModelByManufacturerId(int manuId)
        {
            var models = _assetModelManager.GetAllModelByManufacturerId(manuId);
            return Json(models, JsonRequestBehavior.AllowGet);
        }
        // *******************************

        public JsonResult GetAll()
        {
            var assets = _assetEntryManager.GetAll();
            return Json(assets, JsonRequestBehavior.AllowGet);
        }




        // GET: AssetEntrys
        public ActionResult Index()
        {
            return View("AssetList");
        }

        public ActionResult New()
        {
            var assetEntryVm = new AssetEntryViewModel()
            {
                Organizations = _organizationManager.GetAll(),
                Branchs = new List<Branch>() { },
                AssetLocations = new List<AssetLocation>() { },

                AssetTypes = _assetTypeManager.GetAll(),
                AssetGroups = new List<AssetGroup>() { },
                AssetManufacurers = new List<AssetManufacurer>() { },
                AssetModels = new List<AssetModel>() { },
                Statuses = new List<Status>()
                {
                    new Status(){Id = true, Name = "Active"},
                    new Status(){Id = false, Name = "Inactive"}
                }
            };
            return View("AssetEntryForm", assetEntryVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AssetEntryViewModel assetEntyVm)
        {
            var assetEntryVmDropdown = new AssetEntryViewModel()
            {
                Organizations = _organizationManager.GetAll(),
                Branchs = _branchManager.GetBranchByOrgId(assetEntyVm.OrganizationId),
                AssetLocations = _assetLocationManager.GetAssetLocationByBranchId(assetEntyVm.BranchId),

                AssetTypes = _assetTypeManager.GetAll(),
                AssetGroups = _assetGroupManager.GetAssetGroupsByType(assetEntyVm.AssetTypeId),
                AssetManufacurers = _assetManufacturerManager.GetManufacurersByGroupId(assetEntyVm.AssetGroupId),
                AssetModels = _assetModelManager.GetAllModelByManufacturerId(assetEntyVm.AssetManufacurerId),
                Statuses = new List<Status>()
                {
                    new Status(){Id = true, Name = "Active"},
                    new Status(){Id = false, Name = "Inactive"}
                }
            };

            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (assetEntyVm.Id == 0)
                {
                    var assetEntry = new AssetEntry()
                    {
                        OrganizationId = assetEntyVm.OrganizationId,
                        BranchId = assetEntyVm.BranchId,
                        AssetLocationId = assetEntyVm.AssetLocationId,
                        AssetTypeId = assetEntyVm.AssetTypeId,
                        AssetGroupId = assetEntyVm.AssetGroupId,
                        AssetManufacurerId = assetEntyVm.AssetManufacurerId,
                        AssetModelId = assetEntyVm.AssetModelId,
                        AssetId = assetEntyVm.AssetId,
                        Name = assetEntyVm.Name,
                        SerialNo = assetEntyVm.SerialNo,
                        Brand = assetEntyVm.Brand,
                        Status = assetEntyVm.Status
                    };
                    _assetEntryManager.Add(assetEntry);

                    ModelState.Clear();

                    // Edit Page
                    assetEntryVmDropdown.OrganizationId = assetEntyVm.OrganizationId;
                    assetEntryVmDropdown.BranchId = assetEntyVm.BranchId;
                    assetEntryVmDropdown.AssetLocationId = assetEntyVm.AssetLocationId;
                    assetEntryVmDropdown.AssetTypeId = assetEntyVm.AssetTypeId;
                    assetEntryVmDropdown.AssetGroupId = assetEntyVm.AssetGroupId;
                    assetEntryVmDropdown.AssetManufacurerId = assetEntyVm.AssetManufacurerId;
                    assetEntryVmDropdown.AssetModelId = assetEntyVm.AssetModelId;
                    assetEntryVmDropdown.AssetId = assetEntyVm.AssetId;
                    assetEntryVmDropdown.Name = assetEntyVm.Name;
                    assetEntryVmDropdown.SerialNo = assetEntyVm.SerialNo;
                    assetEntryVmDropdown.Brand = assetEntyVm.Brand;
                    assetEntryVmDropdown.Status = assetEntyVm.Status;

                    return View("AssetEditForm", assetEntryVmDropdown);
                }
            }

            return View("AssetEntryForm", assetEntryVmDropdown);

        }


        // GET: /Organizations/Edit/1
        public ActionResult Edit(int id)
        {
            var asset = _assetEntryManager.Get(id);
            if (asset == null)
                return HttpNotFound();

            var assetEntryVm = new AssetEntryViewModel()
            {
                Id = asset.Id,
                OrganizationId = asset.OrganizationId,
                BranchId = asset.BranchId,
                AssetLocationId = asset.AssetLocationId,
                AssetTypeId = asset.AssetTypeId,
                AssetGroupId = asset.AssetGroupId,
                AssetManufacurerId = asset.AssetManufacurerId,
                AssetModelId = asset.AssetModelId,
                AssetId = asset.AssetId,
                Name = asset.Name,
                SerialNo = asset.SerialNo,
                Brand = asset.Brand,
                Status = asset.Status,

                // dropdown

                Organizations = _organizationManager.GetAll(),
                Branchs = _branchManager.GetBranchByOrgId(asset.OrganizationId),
                AssetLocations = _assetLocationManager.GetAssetLocationByBranchId(asset.BranchId),

                AssetTypes = _assetTypeManager.GetAll(),
                AssetGroups = _assetGroupManager.GetAssetGroupsByType(asset.AssetTypeId),
                AssetManufacurers = _assetManufacturerManager.GetManufacurersByGroupId(asset.AssetGroupId),
                AssetModels = _assetModelManager.GetAllModelByManufacturerId(asset.AssetManufacurerId),
                Statuses = new List<Status>()
                {
                    new Status(){Id = true, Name = "Active"},
                    new Status(){Id = false, Name = "Inactive"}
                }


            };

            AssetTableId = asset.Id;
            return View("AssetEditForm", assetEntryVm);
        }

        // GET: /Organizations/Delete/1
        public ActionResult Delete(int id)
        {
            var asset = _assetEntryManager.Get(id);
            if (asset == null)
            {
                return HttpNotFound();
            }

            _assetEntryManager.Remove(asset);
            return View("AssetList");
        }


        // *************** Finance ****************************
        public ActionResult NewFinance(int id)
        {
            var financeVm = new FinanceViewModel()
            {
                Vendor = _vendorManager.GetAll(),
                AssetEntryId = id
            };
            return PartialView("PartialViews/AssetEntrys/_FinancePartialPage", financeVm);
        }

        public JsonResult SaveFinanceApi(FinanceViewModel financeVm)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                var finance = new Finance()
                {
                    AssetEntryId = financeVm.AssetEntryId,
                    VendorId = financeVm.VendorId,
                    PurchaseDate = financeVm.PurchaseDate,
                    ParchaseOrderNo = financeVm.ParchaseOrderNo,
                    ParchasePrice = financeVm.ParchasePrice
                };
                int count = _financeManager.Add(finance);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        // ************* Service **************

        public ActionResult NewService(int id)
        {
            var serviceVm = new ServiceViewModel()
            {
                AssetEntryId = id
            };
            return PartialView("PartialViews/AssetEntrys/_servicePartialPage", serviceVm);
        }

        public JsonResult SaveServicApi(ServiceViewModel serviceVm)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                var servie = new ServiceOrRepairing()
                {
                    AssetEntryId = serviceVm.AssetEntryId,
                    Description = serviceVm.Description,
                    ServiceBy = serviceVm.ServiceBy,
                    ServiceDate = serviceVm.ServiceDate,
                    ServiceingCostDecimal = serviceVm.ServiceingCostDecimal,
                    PartsCostDecimal = serviceVm.PartsCostDecimal,
                    TaxDecimal = serviceVm.TaxDecimal
                };

                int count = _serviceOrRepairingManager.Add(servie);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        // *********** Note *******************
        public ActionResult NewNote(int id)
        {
            var noteVm = new NoteViewModel()
            {
                AssetEntryId = id
            };
            return PartialView("PartialViews/AssetEntrys/_NotePartialPage", noteVm);
        }

        public JsonResult SaveNoteApi(NoteViewModel noteVm)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                var note = new Note()
                {
                    AssetEntryId = noteVm.AssetEntryId,
                    Notes = noteVm.Notes
                };

                int count = _noteManager.Add(note);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        // *********** Attchment *******************
        public ActionResult NewAttechment(int id)
        {
            var attechmentVm = new AttchmentViewModel()
            {
                AssetEntryId = id
            };
            return PartialView("PartialViews/AssetEntrys/_attchmentPartialPage");
        }

        public JsonResult AttechmentSaveApi(AttchmentViewModel attchmentVm)
        {
            byte[] file = System.IO.File.ReadAllBytes(attchmentVm.File);
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                //byte[] uploadedFile = new byte[attchmentVm.File.InputStream.Length];
                //attchmentVm.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                var attchment = new Attchment()
                {
                    AssetEntryId = attchmentVm.AssetEntryId,
                    File = file
                };


                int count = _attachmentManager.Add(attchment);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}