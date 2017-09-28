using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IAssetSetupUnitOfWork : IUnitOfWork
    {
        IAssetTypeRepository AssetType { get; set; }

        IAssetGroupRepository AssetGroup { get; set; }

        IAssetManufacurerRepository AssetManufacurer { get; set; }

        IAssetModelRepository AssetModel { get; set; }
    }
}
