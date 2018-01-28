using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Core.Repository.Library.Core;
using System.Collections.Generic;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys
{
    public interface IAssetEntryRepository : IRepository<AssetEntry>
    {
        IEnumerable<AssetEntry> GetAllWithAll();
    }
}
