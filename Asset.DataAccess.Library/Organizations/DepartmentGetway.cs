using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.Organizations
{
    public class DepartmentGetway : IRepositoryGetway<Department>
    {
        private readonly DepartmentDesignationUnitOfWork _departmentUnitOfWork;

        public DepartmentGetway()
        {
            _departmentUnitOfWork = new DepartmentDesignationUnitOfWork(new AssetDbContext());
        }
        public int Add(Department entity)
        {
            _departmentUnitOfWork.Department.Add(entity);
            return _departmentUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Department> entities)
        {
            _departmentUnitOfWork.Department.AddRange(entities);
            return _departmentUnitOfWork.Complete();
        }

        public Department Get(int id)
        {
            return _departmentUnitOfWork.Department.Get(id);

        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentUnitOfWork.Department.GetAll();
        }

        public int Remove(Department entity)
        {
            _departmentUnitOfWork.Department.Remove(entity);
            return _departmentUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Department> entities)
        {
            _departmentUnitOfWork.Department.RemoveRange(entities);
            return _departmentUnitOfWork.Complete();
        }

        public int Update(Department entity)
        {
            _departmentUnitOfWork.Department.Update(entity);
            return _departmentUnitOfWork.Complete();
        }

        public Department GetDepartmentByShortName(string shortName)
        {
            return _departmentUnitOfWork.Department.GetDepartmentByShortName(shortName);
        }

        public IEnumerable<Department> Find(int id)
        {
            return _departmentUnitOfWork.Department.Find(c => c.Id == id);
        }

        public Department SingleDepartment(int id)
        {
            return _departmentUnitOfWork.Department.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Department> GetDepartmentWithOrganization()
        {
            return _departmentUnitOfWork.Department.GetDepartmentWithOrganization();
        }
    }
}
