using Asset.DataAccess.Library.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetEntrys
{
    public class NoteManager : IRepositoryManager<Note>
    {
        private readonly NoteGetway _noteGetway;

        public NoteManager()
        {
            _noteGetway = new NoteGetway();
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
            return _noteGetway.Add(entity);
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
