using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetSetups
{
    public class AssetTypeGetway : IRepositoryGetway<AssetType>
    {
        private readonly AssetSetupUnitOfWork _assetSetupUnitOfWork;

        public AssetTypeGetway()
        {
            _assetSetupUnitOfWork = new AssetSetupUnitOfWork(new AssetDbContext());

        }


        public AssetType Get(int id)
        {
            return _assetSetupUnitOfWork.AssetType.Get(id);
        }

        public IEnumerable<AssetType> GetAll()
        {
            return _assetSetupUnitOfWork.AssetType.GetAll();
        }

        public int Add(AssetType entity)
        {
            _assetSetupUnitOfWork.AssetType.Add(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetType entity)
        {
            _assetSetupUnitOfWork.AssetType.Update(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int Remove(AssetType entity)
        {
            _assetSetupUnitOfWork.AssetType.Remove(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetType> entities)
        {
            throw new NotImplementedException();
        }

        public AssetType GetByShortName(string shortName)
        {
            return _assetSetupUnitOfWork.AssetType.SingleOrDefault(c => c.ShortName == shortName);
        }
    }
}
