using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.HrModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.Hrs
{
    public class EmployeeGetway : IRepositoryGetway<Employee>
    {
        private readonly HrUnitOfWork _hrUnitOfWork;

        public EmployeeGetway()
        {
            _hrUnitOfWork = new HrUnitOfWork(new AssetDbContext());
        }
        public int Add(Employee entity)
        {
            _hrUnitOfWork.Employee.Add(entity);
            return _hrUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Employee> entities)
        {
            _hrUnitOfWork.Employee.AddRange(entities);
            return _hrUnitOfWork.Complete();
        }

        public Employee Get(int id)
        {
            return _hrUnitOfWork.Employee.Get(id);

        }

        public IEnumerable<Employee> GetAll()
        {
            return _hrUnitOfWork.Employee.GetAll();
        }

        public int Remove(Employee entity)
        {
            _hrUnitOfWork.Employee.Remove(entity);
            return _hrUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Employee> entities)
        {
            _hrUnitOfWork.Employee.RemoveRange(entities);
            return _hrUnitOfWork.Complete();
        }

        public int Update(Employee entity)
        {
            _hrUnitOfWork.Employee.Update(entity);
            return _hrUnitOfWork.Complete();
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _hrUnitOfWork.Employee.GetEmployeeByEmail(email);
        }

        public IEnumerable<Employee> Find(int id)
        {
            return _hrUnitOfWork.Employee.Find(c => c.Id == id);
        }

        public Employee SingleEmployee(int id)
        {
            return _hrUnitOfWork.Employee.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Employee> GetEmployeesWithOrganization()
        {
            return _hrUnitOfWork.Employee.GetEmployeesWithOrganization();
        }
    }
}
