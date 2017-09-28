using Asset.Core.Repository.Library.Repositorys.Organizations;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IOrganizationUnitOfWork : IUnitOfWork
    {
        IOrganizationRepository Orgnation { get; set; }
        IBranchRepository Branch { get; set; }
    }
}
