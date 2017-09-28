using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Data.Entity;
using System.Linq;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(DbContext context)
            : base(context)
        {

        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }


        public Organization GetOrganizationByShortName(string shortName)
        {
            var organization = AssetDbContext.Organizations.SingleOrDefault(c => c.ShortName == shortName);
            return organization;
        }
    }
}
