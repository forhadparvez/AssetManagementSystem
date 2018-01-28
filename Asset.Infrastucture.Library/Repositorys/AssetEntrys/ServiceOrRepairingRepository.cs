using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetEntrys
{
    public class ServiceOrRepairingRepository : Repository<ServiceOrRepairing>, IServiceOrRepairingRepository
    {
        public ServiceOrRepairingRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }
    }
}
