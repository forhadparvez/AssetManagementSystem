using System.Collections.Generic;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups
{
    public interface IAssetLocationRepository : IRepository<AssetLocation>
    {
        IEnumerable<AssetLocation> GetAllByOrgAndBroanc();
    }
}
