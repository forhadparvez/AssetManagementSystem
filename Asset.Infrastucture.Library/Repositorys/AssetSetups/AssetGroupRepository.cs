using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetSetups
{
    public class AssetGroupRepository : Repository<AssetGroup>, IAssetGroupRepository
    {
        public AssetGroupRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }
    }
}
