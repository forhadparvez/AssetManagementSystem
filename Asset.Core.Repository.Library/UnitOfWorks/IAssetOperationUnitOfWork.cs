using Asset.Core.Repository.Library.Repositorys.AssetsModels.Operation;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IAssetOperationUnitOfWork : IUnitOfWork
    {
        ICheckOutRepository CheckOut { get; set; }

        ICheckInRepository CheckIn { get; set; }
    }
}
