using System.Collections.Generic;
using Asset.Models.Library.EntityModels.OrganizationModels;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.Organizations
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Branch GetBranchByShortName(string shortName);

        IEnumerable<Branch> GetBranchWithOrganization();
    }
}
