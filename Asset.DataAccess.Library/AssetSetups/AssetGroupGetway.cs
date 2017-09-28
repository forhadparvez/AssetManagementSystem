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
            throw new NotImplementedException();
        }

        public IEnumerable<AssetGroup> GetAll()
        {
            return _assetSetupUnitOfWork.AssetGroup.GetAll();
        }

        public int Add(AssetGroup entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<AssetGroup> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetGroup entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(AssetGroup entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<AssetGroup> entities)
        {
            throw new NotImplementedException();
        }
    }
}
