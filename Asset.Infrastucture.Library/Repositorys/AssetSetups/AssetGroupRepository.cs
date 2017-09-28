using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Asset.Infrastucture.Library.Repositorys.AssetSetups
{
    public class AssetGroupRepository : Repository<AssetGroup>, IAssetGroupRepository
    {
        public AssetGroupRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }



        public IEnumerable<AssetGroup> GetAssetGroupsWithType()
        {
            return AssetDbContext.AssetGroups.Include(c => c.AssetType);
        }

        public IEnumerable<AssetGroup> GetAssetGroupsByType(int assetTypeId)
        {
            return AssetDbContext.AssetGroups.Include(c => c.AssetType).Where(c => c.AssetTypeId == assetTypeId);
        }
    }
}
