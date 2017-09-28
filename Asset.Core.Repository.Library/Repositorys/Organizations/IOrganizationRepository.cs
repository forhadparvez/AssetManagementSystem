using Asset.Models.Library.EntityModels.OrganizationModels;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.Organizations
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Organization GetOrganizationByShortName(string shortName);
    }
}
