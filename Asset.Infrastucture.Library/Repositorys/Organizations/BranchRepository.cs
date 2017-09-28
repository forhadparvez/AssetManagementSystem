using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(AssetDbContext context)
            : base(context)
        {

        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }


        public Branch GetBranchByShortName(string shortName)
        {
            var branch = AssetDbContext.Branches.SingleOrDefault(c => c.ShortName == shortName);
            return branch;
        }


        public IEnumerable<Branch> GetBranchWithOrganization()
        {
            var branchs = AssetDbContext.Branches.Include(c => c.Organization);
            return branchs;
        }
    }
}
