using Asset.Core.Repository.Library.Repositorys.HrModels;
using Asset.Models.Library.EntityModels.HrModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Asset.Infrastucture.Library.Repositorys.Hrs
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }

        public Employee GetEmployeeByEmail(string email)
        {
            var employee = AssetDbContext.Employees.SingleOrDefault(c => c.Email == email);
            return employee;
        }

        public IEnumerable<Employee> GetEmployeesWithOrganization()
        {
            var employees = AssetDbContext.Employees.Include(c => c.Organization).Include(c => c.Branch);
            return employees;
        }
    }
}
