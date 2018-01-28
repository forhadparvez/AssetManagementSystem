using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetEntrys
{
    public class AttachmentGetway : IRepositoryGetway<Attchment>
    {
        private readonly AssetEntryUnitOfWork _assetEntryUnitOfWork;

        public AttachmentGetway()
        {
            _assetEntryUnitOfWork = new AssetEntryUnitOfWork(new AssetDbContext());
        }

        public Attchment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attchment> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Attchment entity)
        {
            _assetEntryUnitOfWork.Attchment.Add(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Attchment> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(Attchment entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(Attchment entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<Attchment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
