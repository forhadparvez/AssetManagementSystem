using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.AssetEntrys
{
    public class NoteGetway : IRepositoryGetway<Note>
    {
        private readonly AssetEntryUnitOfWork _assetEntryUnitOfWork;

        public NoteGetway()
        {
            _assetEntryUnitOfWork = new AssetEntryUnitOfWork(new AssetDbContext());
        }

        public Note Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Note entity)
        {
            _assetEntryUnitOfWork.Note.Add(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Note> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(Note entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(Note entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<Note> entities)
        {
            throw new NotImplementedException();
        }
    }
}
