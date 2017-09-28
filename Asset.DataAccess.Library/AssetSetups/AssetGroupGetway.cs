using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetSetups
{
    public class AssetGroupGetway : IRepositoryGetway<AssetGroup>
    {
        private readonly AssetSetupUnitOfWork _assetSetupUnitOfWork;

        public AssetGroupGetway()
        {
            _assetSetupUnitOfWork = new AssetSetupUnitOfWork(new AssetDbContext());
        }

        public AssetGroup Get(int id)
        {
            return _assetSetupUnitOfWork.AssetGroup.Get(id);
        }

        public IEnumerable<AssetGroup> GetAll()
        {
            return _assetSetupUnitOfWork.AssetGroup.GetAll();
        }


        public IEnumerable<AssetGroup> GetAssetGroupsWithType()
        {
            return _assetSetupUnitOfWork.AssetGroup.GetAssetGroupsWithType();
        }

        public IEnumerable<AssetGroup> GetAssetGroupsByType(int assetTypeId)
        {
            return _assetSetupUnitOfWork.AssetGroup.GetAssetGroupsByType(assetTypeId);
        }

        public int Add(AssetGroup entity)
        {
            _assetSetupUnitOfWork.AssetGroup.Add(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetGroup> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetGroup entity)
        {
            _assetSetupUnitOfWork.AssetGroup.Update(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int Remove(AssetGroup entity)
        {
            _assetSetupUnitOfWork.AssetGroup.Remove(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetGroup> entities)
        {
            throw new NotImplementedException();
        }
    }
}
