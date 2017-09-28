using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System;
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
            throw new NotImplementedException();
        }

        public IEnumerable<AssetGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetGroup> GetAssetGroupsWithType()
        {
            return _assetGroupGetway.GetAssetGroupsWithType();
        }

        public int Add(AssetGroup entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<AssetGroup> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetGroup entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(AssetGroup entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<AssetGroup> entities)
        {
            throw new NotImplementedException();
        }
    }
}
