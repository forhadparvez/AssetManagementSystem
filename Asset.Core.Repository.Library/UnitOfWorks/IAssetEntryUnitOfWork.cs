using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IAssetEntryUnitOfWork : IUnitOfWork
    {
        IAssetEntryRepository AssetEntry { get; set; }
        IFinanceRepository Finance { get; set; }
        IServiceOrRepairingRepository ServiceOrRepairing { get; set; }
        INoteRepostiry Note { get; set; }
        IAttchmentRepository Attchment { get; set; }
    }
}
