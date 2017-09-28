using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class AssetSetupUnitOfWork : IAssetSetupUnitOfWork
    {

        private readonly AssetDbContext _context;

        public AssetSetupUnitOfWork(AssetDbContext context)
        {
            _context = context;

            AssetType = new AssetTypeRepository(_context);

            AssetGroup = new AssetGroupRepository(_context);

            AssetManufacurer = new AssetManufactureRepository(_context);

            AssetModel = new AssetModelRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IAssetTypeRepository AssetType { get; set; }
        public IAssetGroupRepository AssetGroup { get; set; }
        public IAssetManufacurerRepository AssetManufacurer { get; set; }
        public IAssetModelRepository AssetModel { get; set; }
    }
}
