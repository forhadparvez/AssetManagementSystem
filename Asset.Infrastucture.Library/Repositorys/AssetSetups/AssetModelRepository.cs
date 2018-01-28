using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Collections.Generic;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetSetups
{
    public class AssetModelRepository : Repository<AssetModel>, IAssetModelRepository
    {
        public AssetModelRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }
        public IEnumerable<AssetModel> GetAllByGroupAndManufacturer()
        {
            return AssetDbContext.AssetModels.Include(c => c.AssetGroup).Include(c => c.AssetManufacurer);
        }
    }
}
