using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Core.Repository.Library.UnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.Organizations;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class OrganizationUnitOfWork : IOrganizationUnitOfWork
    {
        private readonly AssetDbContext _context;

        public OrganizationUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Orgnation = new OrganizationRepository(_context);
            Branch = new BranchRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IOrganizationRepository Orgnation { get; set; }
        public IBranchRepository Branch { get; set; }
    }
}
