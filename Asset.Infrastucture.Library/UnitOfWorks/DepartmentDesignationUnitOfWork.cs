using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Core.Repository.Library.UnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.Organizations;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class DepartmentDesignationUnitOfWork : IDepartmentDesignationUnitOfWork
    {
        private readonly AssetDbContext _context;
        public DepartmentDesignationUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Department = new DepartmentRepository(_context);
        }
        public IDepartmentRepository Department { get; set; }

        public IDesignationRepository Designation { get; set; }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
