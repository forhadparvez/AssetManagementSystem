using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetEntrys
{
    public class FinanceGetway : IRepositoryGetway<Finance>
    {
        private readonly AssetEntryUnitOfWork _assetEntryUnitOfWork;

        public FinanceGetway()
        {
            _assetEntryUnitOfWork = new AssetEntryUnitOfWork(new AssetDbContext());
        }

        public Finance Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Finance> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Finance entity)
        {
            _assetEntryUnitOfWork.Finance.Add(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Finance> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(Finance entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(Finance entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<Finance> entities)
        {
            throw new NotImplementedException();
        }
    }
}
