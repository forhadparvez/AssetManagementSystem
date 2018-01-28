using Asset.Core.Repository.Library.Repositorys.AssetsModels.Operation;
using Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetOperation
{
    public class CheckOutRepository : Repository<CheckOut>, ICheckOutRepository
    {
        public CheckOutRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }

    }
}
