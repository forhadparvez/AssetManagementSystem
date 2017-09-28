using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Core.Repository.Library.Infrastucture;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetSetups
{
    public class AssetLocationRepository : Repository<AssetLocation>, IAssetLocationRepository
    {
        public AssetLocationRepository(DbContext context)
            : base(context)
        {
        }
    }
}
