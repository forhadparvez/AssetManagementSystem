using Asset.DataAccess.Library.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetEntrys
{
    public class ServiceOrRepairingManager : IRepositoryManager<ServiceOrRepairing>
    {
        private readonly ServiceOrRepairingGetway _serviceOrRepairingGetway;

        public ServiceOrRepairingManager()
        {
            _serviceOrRepairingGetway = new ServiceOrRepairingGetway();
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
            return _serviceOrRepairingGetway.Add(entity);
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
