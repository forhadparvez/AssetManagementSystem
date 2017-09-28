using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetSetups
{
    public class AssetModelGetway : IRepositoryGetway<AssetModel>
    {
        private readonly AssetSetupUnitOfWork _assetSetupUnitOfWork;

        public AssetModelGetway()
        {
            _assetSetupUnitOfWork = new AssetSetupUnitOfWork(new AssetDbContext());
        }
        public AssetModel Get(int id)
        {
            return _assetSetupUnitOfWork.AssetModel.Get(id);
        }

        public IEnumerable<AssetModel> GetAll()
        {
            return _assetSetupUnitOfWork.AssetModel.GetAll();

        }

        public int Add(AssetModel entity)
        {
            _assetSetupUnitOfWork.AssetModel.Add(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetModel> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetModel entity)
        {
            _assetSetupUnitOfWork.AssetModel.Update(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int Remove(AssetModel entity)
        {
            _assetSetupUnitOfWork.AssetModel.Remove(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
