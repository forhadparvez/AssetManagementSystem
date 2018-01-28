using Asset.DataAccess.Library.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetEntrys
{
    public class FinanceManager : IRepositoryManager<Finance>
    {
        private readonly FinanceGetway _financeGetway;

        public FinanceManager()
        {
            _financeGetway = new FinanceGetway();
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
            return _financeGetway.Add(entity);
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
