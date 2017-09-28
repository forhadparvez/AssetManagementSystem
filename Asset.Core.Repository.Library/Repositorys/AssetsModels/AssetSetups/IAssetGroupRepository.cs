using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Core.Repository.Library.Core;
using System.Collections.Generic;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups
{
    public interface IAssetGroupRepository : IRepository<AssetGroup>
    {
        IEnumerable<AssetGroup> GetAssetGroupsWithType();

        IEnumerable<AssetGroup> GetAssetGroupsByType(int assetTypeId);
    }
}
