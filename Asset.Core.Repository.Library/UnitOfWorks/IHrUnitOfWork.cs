using Asset.Core.Repository.Library.Repositorys.HrModels;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IHrUnitOfWork: IUnitOfWork
    {
        IEmployeeRepository Employee { get; set; }
    }
}
