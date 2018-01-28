using Asset.DataAccess.Library.AssetOperation;
using Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetOperation
{
    public class CheckOutManager : IRepositoryManager<CheckOut>
    {
        private readonly CheckOutGetway _checkOutGetway;

        public CheckOutManager()
        {
            _checkOutGetway = new CheckOutGetway();
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
            return _checkOutGetway.Add(entity);
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
