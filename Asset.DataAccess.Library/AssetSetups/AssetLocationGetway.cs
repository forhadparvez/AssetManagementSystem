using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetSetups
{
    public class AssetLocationGetway : IRepositoryGetway<AssetLocation>
    {
        private readonly AssetLocationUnitOfWork _assetLocationUnitOfWork;

        public AssetLocationGetway()
        {
            _assetLocationUnitOfWork = new AssetLocationUnitOfWork(new AssetDbContext());
        }


        public AssetLocation Get(int id)
        {
            return _assetLocationUnitOfWork.AssetLocation.Get(id);
        }

        public IEnumerable<AssetLocation> GetAll()
        {
            return _assetLocationUnitOfWork.AssetLocation.GetAll();
        }

        public int Add(AssetLocation entity)
        {
            _assetLocationUnitOfWork.AssetLocation.Add(entity);
            return _assetLocationUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetLocation> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetLocation entity)
        {
            _assetLocationUnitOfWork.AssetLocation.Update(entity);
            return _assetLocationUnitOfWork.Complete();
        }

        public int Remove(AssetLocation entity)
        {
            _assetLocationUnitOfWork.AssetLocation.Remove(entity);
            return _assetLocationUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetLocation> entities)
        {
            throw new NotImplementedException();
        }
    }
}
