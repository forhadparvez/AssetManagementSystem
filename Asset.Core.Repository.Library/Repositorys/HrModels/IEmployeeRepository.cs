using System.Collections.Generic;
using Asset.Models.Library.EntityModels.HrModels;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.HrModels
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee GetEmployeeByEmail(string email);
        IEnumerable<Employee> GetEmployeesWithOrganization();
    }
}
