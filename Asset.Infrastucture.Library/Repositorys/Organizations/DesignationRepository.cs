using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Collections.Generic;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        public DesignationRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }

        public IEnumerable<Designation> GetDesignationsWithDepartment()
        {
            return AssetDbContext.Designations.Include(c => c.Department);
        }
    }
}
