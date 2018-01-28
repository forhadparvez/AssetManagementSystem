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

        public IEnumerable<AssetModel> GetAllByGroupAndManufacturer()
        {
            return _assetSetupUnitOfWork.AssetModel.GetAllByGroupAndManufacturer();
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

        public AssetModel GetByShortName(string shortName, int groupId, int assetManufacurerId)
        {
            return
                _assetSetupUnitOfWork.AssetModel.SingleOrDefault(
                    c =>
                        c.ShortName == shortName && c.AssetGroupId == groupId &&
                        c.AssetManufacurerId == assetManufacurerId);
        }

        public IEnumerable<AssetModel> GetAllModelByManufacturerId(int manuId)
        {
            return _assetSetupUnitOfWork.AssetModel.Find(c => c.AssetManufacurerId == manuId);
        }
    }
}
