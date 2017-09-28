using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetSetups
{
    public class AssetGroupManager : IRepositoryManager<AssetGroup>
    {
        private readonly AssetGroupGetway _assetGroupGetway;

        public AssetGroupManager()
        {
            _assetGroupGetway = new AssetGroupGetway();
        }

        public AssetGroup Get(int id)
        {
            return _assetGroupGetway.Get(id);
        }

        public IEnumerable<AssetGroup> GetAll()
        {
            return _assetGroupGetway.GetAll();
        }

        public IEnumerable<AssetGroup> GetAssetGroupsWithType()
        {
            return _assetGroupGetway.GetAssetGroupsWithType();
        }


        public IEnumerable<AssetGroup> GetAssetGroupsByType(int assetTypeId)
        {
            return _assetGroupGetway.GetAssetGroupsByType(assetTypeId);
        }

        public int Add(AssetGroup entity)
        {
            return _assetGroupGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetGroup> entities)
        {
            return _assetGroupGetway.AddRange(entities);
        }

        public int Update(AssetGroup entity)
        {
            return _assetGroupGetway.Update(entity);
        }

        public int Remove(AssetGroup entity)
        {
            return _assetGroupGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetGroup> entities)
        {
            return _assetGroupGetway.RemoveRange(entities);
        }
    }
}
