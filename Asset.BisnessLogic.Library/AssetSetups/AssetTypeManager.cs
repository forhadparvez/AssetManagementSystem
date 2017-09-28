using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetSetups
{
    public class AssetTypeManager : IRepositoryManager<AssetType>
    {
        public readonly AssetTypeGetway _assetTypeGetway;

        public AssetTypeManager()
        {
            _assetTypeGetway = new AssetTypeGetway();
        }


        public AssetType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetType> GetAll()
        {
            return _assetTypeGetway.GetAll();
        }

        public int Add(AssetType entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetType entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(AssetType entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }
    }
}
