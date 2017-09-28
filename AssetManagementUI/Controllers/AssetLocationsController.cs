using System.Web.Mvc;
using Asset.BisnessLogic.Library.Organizations;

namespace AssetManagementUI.Controllers
{
    public class AssetLocationsController : Controller
    {
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;
        //private readonly assetloc
        // GET: AssetLocations
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("PartialView/AssetLocations/_CreatePartialView");
        }
    }
}