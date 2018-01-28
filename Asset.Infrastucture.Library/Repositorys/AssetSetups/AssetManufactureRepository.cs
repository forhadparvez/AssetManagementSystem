using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Collections.Generic;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetSetups
{
    public class AssetManufactureRepository : Repository<AssetManufacurer>, IAssetManufacurerRepository
    {
        public AssetManufactureRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }

        public IEnumerable<AssetManufacurer> GetAllManufacturerWithGroup()
        {
            return AssetDbContext.AssetManufacurers.Include(c => c.AssetGroup);
        }
    }
}
