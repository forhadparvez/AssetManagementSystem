using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetSetups
{
    public class AssetTypeManager : IRepositoryManager<AssetType>
    {
        private readonly AssetTypeGetway _assetTypeGetway;

        public AssetTypeManager()
        {
            _assetTypeGetway = new AssetTypeGetway();
        }


        public AssetType Get(int id)
        {
            return _assetTypeGetway.Get(id);
        }

        public IEnumerable<AssetType> GetAll()
        {
            return _assetTypeGetway.GetAll();
        }

        public int Add(AssetType entity)
        {
            return _assetTypeGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetType entity)
        {
            return _assetTypeGetway.Update(entity);
        }

        public int Remove(AssetType entity)
        {
            return _assetTypeGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }

        public bool IsShortNameExsit(string shortName)
        {
            bool isShortNameExist = false;
            var assetType = _assetTypeGetway.GetByShortName(shortName);
            if (assetType != null)
                return isShortNameExist = true;

            return isShortNameExist;
        }
    }
}
