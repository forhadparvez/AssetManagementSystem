using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Web.Http;

namespace AssetManagementUI.Controllers.Api
{
    public class OrganizationsController : ApiController
    {
        private readonly OrganizationManager _organizationManager;

        public OrganizationsController()
        {
            _organizationManager = new OrganizationManager();
        }

        [HttpPost]
        public IHttpActionResult CreateNewOrganization(Organization organization)
        {
            var customer = _organizationManager.SingleOrganization(organization.Id);

            if (customer != null)
            {
                _organizationManager.Add(organization);
                return Ok();
            }
            _organizationManager.Update(organization);
            return Ok();
        }

        public IHttpActionResult GetOrganizations(string query = null)
        {
            var organizations = _organizationManager.GetAll();
            return Ok(organizations);
        }
    }
}
