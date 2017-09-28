using Asset.Core.Repository.Library.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Core.Repository.Library.Repositorys.HrModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Asset.Infrastucture.Library.Repositorys.Hrs;

namespace Asset.Infrastucture.Library.UnitOfWorks
{
    public class HrUnitOfWork : IHrUnitOfWork
    {
        private readonly AssetDbContext _context;


        public HrUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(_context);
        }
        public IEmployeeRepository Employee
        {
            get;set;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
