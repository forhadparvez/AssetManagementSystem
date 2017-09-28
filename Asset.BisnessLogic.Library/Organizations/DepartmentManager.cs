using System.Collections.Generic;
using Asset.DataAccess.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.BisnessLogic.Library.Organizations
{
    public class DepartmentManager:IRepositoryManager<Department>
    {
        private readonly DepartmentGetway _departmentGetway;

        public DepartmentManager()
        {
            _departmentGetway=new DepartmentGetway();
        }


        public Department Get(int id)
        {
            return _departmentGetway.Get(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentGetway.GetAll();
        }

        public IEnumerable<Department> GetDepartmentWithOrganization()
        {
            return _departmentGetway.GetDepartmentWithOrganization();
        }

        public int Add(Department entity)
        {
            return _departmentGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Department> entities)
        {
            return _departmentGetway.AddRange(entities);
        }

        public bool IsDepartmentShortNameExist(string shortName)
        {
            bool isDepartmentShortName = false;
            var department = GetDepartmentByShortName(shortName);
            if (department != null)
            {
                isDepartmentShortName = true;
            }
            return isDepartmentShortName;
        }

        private Department GetDepartmentByShortName(string shortName)
        {
            return _departmentGetway.GetDepartmentByShortName(shortName);
        }

        public IEnumerable<Department> FindById(int id)
        {
            return _departmentGetway.Find(id);
        }

        public Department SingleDepartment(int id)
        {
            return _departmentGetway.SingleDepartment(id);
        }

        public int Update(Department entity)
        {
            return _departmentGetway.Update(entity);
        }

        public int Remove(Department entity)
        {
            return _departmentGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Department> entities)
        {
            return _departmentGetway.RemoveRange(entities);
        }
    }
}
