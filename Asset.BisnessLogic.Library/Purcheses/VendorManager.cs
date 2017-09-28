using System;
using System.Collections.Generic;
using Asset.DataAccess.Library.Purchases;
using Asset.Models.Library.EntityModels.Purchases;

namespace Asset.BisnessLogic.Library.Purcheses
{
    public class VendorManager:IRepositoryManager<Vendor>
    {
        private readonly VendorGetway _vendorGetway;

        public VendorManager()
        {
            _vendorGetway = new VendorGetway();
        }


        public Vendor Get(int id)
        {
            return _vendorGetway.Get(id);
        }


        public IEnumerable<Vendor> GetAll()
        {
            return _vendorGetway.GetAll();
        }

        public int Add(Vendor entity)
        {
            return _vendorGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Vendor> entities)
        {
            return _vendorGetway.AddRange(entities);
        }

        public int Update(Vendor entity)
        {
            return _vendorGetway.Update(entity);
        }

        public int Remove(Vendor entity)
        {
            return _vendorGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Vendor> entities)
        {
            return _vendorGetway.RemoveRange(entities);
        }
    }
}
