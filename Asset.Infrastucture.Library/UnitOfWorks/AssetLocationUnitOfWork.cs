using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class AssetLocationUnitOfWork : IAssetLocationUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetLocationUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetLocation = new AssetLocationRepository(_context);
        }
        public IAssetLocationRepository AssetLocation { get; set; }




        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
