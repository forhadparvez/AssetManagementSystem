using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.Purchases;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.Purchases
{
    public class VendorGetway : IRepositoryGetway<Vendor>
    {
        private readonly PurchaseUnitOfWork _purchaseUnitOfWork;

        public VendorGetway()
        {
            _purchaseUnitOfWork = new PurchaseUnitOfWork(new AssetDbContext());
        }

        public int Add(Vendor entity)
        {
            _purchaseUnitOfWork.Vendors.Add(entity);
            return _purchaseUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Vendor> entities)
        {
            _purchaseUnitOfWork.Vendors.AddRange(entities);
            return _purchaseUnitOfWork.Complete();
        }

        public Vendor Get(int id)
        {
            return _purchaseUnitOfWork.Vendors.Get(id);
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _purchaseUnitOfWork.Vendors.GetAll();
        }

        public int Remove(Vendor entity)
        {
            _purchaseUnitOfWork.Vendors.Remove(entity);
            return _purchaseUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Vendor> entities)
        {
            _purchaseUnitOfWork.Vendors.RemoveRange(entities);
            return _purchaseUnitOfWork.Complete();
        }

        public int Update(Vendor entity)
        {
            _purchaseUnitOfWork.Vendors.Update(entity);
            return _purchaseUnitOfWork.Complete();
        }
    }
}
