using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetEntrys
{
    public class AssetEntryGetway : IRepositoryGetway<AssetEntry>
    {
        private readonly AssetEntryUnitOfWork _assetEntryUnitOfWork;

        public AssetEntryGetway()
        {
            _assetEntryUnitOfWork = new AssetEntryUnitOfWork(new AssetDbContext());
        }

        public AssetEntry Get(int id)
        {
            return _assetEntryUnitOfWork.AssetEntry.Get(id);
        }

        public IEnumerable<AssetEntry> GetAll()
        {
            return _assetEntryUnitOfWork.AssetEntry.GetAll();
        }

        public IEnumerable<AssetEntry> GetAllWithAll()
        {
            return _assetEntryUnitOfWork.AssetEntry.GetAllWithAll();
        }

        public int Add(AssetEntry entity)
        {
            _assetEntryUnitOfWork.AssetEntry.Add(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetEntry> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetEntry entity)
        {
            _assetEntryUnitOfWork.AssetEntry.Update(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int Remove(AssetEntry entity)
        {
            _assetEntryUnitOfWork.AssetEntry.Remove(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetEntry> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetEntry> Find(int id)
        {
            return _assetEntryUnitOfWork.AssetEntry.Find(c => c.Id == id);
        }
    }
}
