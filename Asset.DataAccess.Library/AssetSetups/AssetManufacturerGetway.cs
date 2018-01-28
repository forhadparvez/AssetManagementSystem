using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetSetups
{
    public class AssetManufacturerGetway : IRepositoryGetway<AssetManufacurer>
    {
        private readonly AssetSetupUnitOfWork _assetSetupUnitOfWork;

        public AssetManufacturerGetway()
        {
            _assetSetupUnitOfWork = new AssetSetupUnitOfWork(new AssetDbContext());
        }

        public AssetManufacurer Get(int id)
        {
            return _assetSetupUnitOfWork.AssetManufacurer.Get(id);
        }

        public IEnumerable<AssetManufacurer> GetAll()
        {
            return _assetSetupUnitOfWork.AssetManufacurer.GetAll();
        }

        public IEnumerable<AssetManufacurer> GetManufacurersByGroupId(int groupId)
        {
            return _assetSetupUnitOfWork.AssetManufacurer.Find(c => c.AssetGroupId == groupId);
        }


        public int Add(AssetManufacurer entity)
        {
            _assetSetupUnitOfWork.AssetManufacurer.Add(entity);

            return _assetSetupUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetManufacurer> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetManufacurer entity)
        {
            _assetSetupUnitOfWork.AssetManufacurer.Update(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int Remove(AssetManufacurer entity)
        {
            _assetSetupUnitOfWork.AssetManufacurer.Remove(entity);
            return _assetSetupUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetManufacurer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetManufacurer> GetAllManufacturerWithGroup()
        {
            return _assetSetupUnitOfWork.AssetManufacurer.GetAllManufacturerWithGroup();
        }

        public AssetManufacurer GetByGroupIdAndShortName(string shortName, int groupId)
        {
            return
                _assetSetupUnitOfWork.AssetManufacurer.SingleOrDefault(
                    c => c.ShortName == shortName && c.AssetGroupId == groupId);
        }
    }
}
