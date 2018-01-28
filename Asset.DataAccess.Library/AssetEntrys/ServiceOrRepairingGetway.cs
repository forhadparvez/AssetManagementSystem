using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetEntrys
{
    public class ServiceOrRepairingGetway : IRepositoryGetway<ServiceOrRepairing>
    {
        private readonly AssetEntryUnitOfWork _assetEntryUnitOfWork;

        public ServiceOrRepairingGetway()
        {
            _assetEntryUnitOfWork = new AssetEntryUnitOfWork(new AssetDbContext());
        }

        public ServiceOrRepairing Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceOrRepairing> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(ServiceOrRepairing entity)
        {
            _assetEntryUnitOfWork.ServiceOrRepairing.Add(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<ServiceOrRepairing> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(ServiceOrRepairing entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(ServiceOrRepairing entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<ServiceOrRepairing> entities)
        {
            throw new NotImplementedException();
        }
    }
}
