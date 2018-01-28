using Asset.DataAccess.Library.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetEntrys
{
    public class AssetEntryManager : IRepositoryManager<AssetEntry>
    {
        private readonly AssetEntryGetway _assetEntryGetway;

        public AssetEntryManager()
        {
            _assetEntryGetway = new AssetEntryGetway();
        }

        public AssetEntry Get(int id)
        {
            return _assetEntryGetway.Get(id);
        }

        public IEnumerable<AssetEntry> Find(int id)
        {
            return _assetEntryGetway.Find(id);
        }

        public IEnumerable<AssetEntry> GetAll()
        {
            return _assetEntryGetway.GetAll();
        }

        public IEnumerable<AssetEntry> GetAllWithAll()
        {
            return _assetEntryGetway.GetAllWithAll();
        }

        public int Add(AssetEntry entity)
        {
            return _assetEntryGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetEntry> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetEntry entity)
        {
            return _assetEntryGetway.Update(entity);
        }

        public int Remove(AssetEntry entity)
        {
            return _assetEntryGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetEntry> entities)
        {
            throw new NotImplementedException();
        }
    }
}
