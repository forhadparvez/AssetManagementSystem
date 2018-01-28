using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Collections.Generic;
using System.Data.Entity;

namespace Asset.Infrastucture.Library.Repositorys.AssetEntrys
{
    public class AssetEntryRepository : Repository<AssetEntry>, IAssetEntryRepository
    {
        public AssetEntryRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }

        public IEnumerable<AssetEntry> GetAllWithAll()
        {
            return AssetDbContext.AssetEntries
                .Include(c => c.Organization)
                .Include(c => c.Branch)
                .Include(c => c.AssetLocation)
                .Include(c => c.AssetType)
                .Include(c => c.AssetGroup)
                .Include(c => c.AssetManufacurer)
                .Include(c => c.AssetModel);
        }
    }
}
