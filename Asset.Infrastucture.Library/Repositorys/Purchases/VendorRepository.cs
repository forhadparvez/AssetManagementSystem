using Asset.Core.Repository.Library.Repositorys.Purchases;
using Asset.Models.Library.EntityModels.Purchases;
using Core.Repository.Library.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.Repositorys.Purchases
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(DbContext context) : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }
    }
}
