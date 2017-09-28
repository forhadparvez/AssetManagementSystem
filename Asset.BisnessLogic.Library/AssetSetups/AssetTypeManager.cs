using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetSetups
{
    public class AssetTypeManager : IRepositoryManager<AssetType>
    {
        public readonly AssetTypeGetway AssetTypeGetway;

        public AssetTypeManager()
        {
            AssetTypeGetway = new AssetTypeGetway();
        }


        public AssetType Get(int id)
        {
            return AssetTypeGetway.Get(id);
        }

        public IEnumerable<AssetType> GetAll()
        {
            return AssetTypeGetway.GetAll();
        }

        public int Add(AssetType entity)
        {
            return AssetTypeGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetType entity)
        {
            return AssetTypeGetway.Update(entity);
        }

        public int Remove(AssetType entity)
        {
            return AssetTypeGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }
    }
}
