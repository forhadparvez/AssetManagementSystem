using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Core.Repository.Library.Core;
using System.Collections.Generic;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups
{
    public interface IAssetManufacurerRepository : IRepository<AssetManufacurer>
    {
        IEnumerable<AssetManufacurer> GetAllManufacturerWithGroup();
    }
}
