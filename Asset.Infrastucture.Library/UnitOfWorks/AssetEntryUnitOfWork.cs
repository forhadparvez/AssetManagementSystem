using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Core.Repository.Library.UnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class AssetEntryUnitOfWork : IAssetEntryUnitOfWork
    {
        private readonly AssetDbContext _context;

        public AssetEntryUnitOfWork(AssetDbContext context)
        {
            _context = context;

            AssetEntry = new AssetEntryRepository(_context);
            Finance = new FinanceRepository(_context);
            ServiceOrRepairing = new ServiceOrRepairingRepository(_context);
            Note = new NoteRepository(_context);
            Attchment = new AttachmentRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IAssetEntryRepository AssetEntry { get; set; }
        public IFinanceRepository Finance { get; set; }
        public IServiceOrRepairingRepository ServiceOrRepairing { get; set; }
        public INoteRepostiry Note { get; set; }
        public IAttchmentRepository Attchment { get; set; }
    }
}
