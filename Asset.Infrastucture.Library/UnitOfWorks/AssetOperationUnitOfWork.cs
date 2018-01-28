using Asset.Core.Repository.Library.Repositorys.AssetsModels.Operation;
using Asset.Core.Repository.Library.UnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetOperation;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class AssetOperationUnitOfWork : IAssetOperationUnitOfWork
    {
        private readonly AssetDbContext _context;

        public AssetOperationUnitOfWork(AssetDbContext context)
        {
            _context = context;

            CheckOut = new CheckOutRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public ICheckOutRepository CheckOut { get; set; }
        public ICheckInRepository CheckIn { get; set; }
    }
}
