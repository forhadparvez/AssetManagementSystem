using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetSetups
{
    public class AssetModelManager : IRepositoryManager<AssetModel>
    {
        private readonly AssetModelGetway _assetModelGetway;

        public AssetModelManager()
        {
            _assetModelGetway = new AssetModelGetway();
        }


        public AssetModel Get(int id)
        {
            return _assetModelGetway.Get(id);
        }

        public IEnumerable<AssetModel> GetAll()
        {
            return _assetModelGetway.GetAll();
        }

        public int Add(AssetModel entity)
        {
            return _assetModelGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetModel> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetModel entity)
        {
            return _assetModelGetway.Update(entity);
        }

        public int Remove(AssetModel entity)
        {
            return _assetModelGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
