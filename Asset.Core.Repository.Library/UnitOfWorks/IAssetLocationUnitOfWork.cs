using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IAssetLocationUnitOfWork : IUnitOfWork
    {
        IAssetLocationRepository AssetLocation { get; set; }
    }
}
