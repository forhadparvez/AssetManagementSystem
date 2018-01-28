using Asset.DataAccess.Library.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetEntrys
{
    public class AttachmentManager : IRepositoryManager<Attchment>
    {
        private readonly AttachmentGetway _attachmentGetway;

        public AttachmentManager()
        {
            _attachmentGetway = new AttachmentGetway();
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
            return _attachmentGetway.Add(entity);
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
