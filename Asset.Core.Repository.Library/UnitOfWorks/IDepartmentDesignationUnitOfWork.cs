using Asset.Core.Repository.Library.Repositorys.Organizations;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IDepartmentDesignationUnitOfWork : IUnitOfWork
    {
        IDepartmentRepository Department { get; set; }
        IDesignationRepository Designation { get; set; }
    }
}
