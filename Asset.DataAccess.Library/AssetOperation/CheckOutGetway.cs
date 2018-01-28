using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetOperation
{
    public class CheckOutGetway : IRepositoryGetway<CheckOut>
    {
        private readonly AssetOperationUnitOfWork _assetOperationUnitOfWork;

        public CheckOutGetway()
        {
            _assetOperationUnitOfWork = new AssetOperationUnitOfWork(new AssetDbContext());
        }

        public CheckOut Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckOut> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(CheckOut entity)
        {
            _assetOperationUnitOfWork.CheckOut.Add(entity);
            return _assetOperationUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<CheckOut> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(CheckOut entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(CheckOut entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<CheckOut> entities)
        {
            throw new NotImplementedException();
        }
    }
}
