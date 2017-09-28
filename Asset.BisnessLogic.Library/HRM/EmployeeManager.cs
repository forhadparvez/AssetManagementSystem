using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.DataAccess.Library.Hrs;
using Asset.Models.Library.EntityModels.HrModels;

namespace Asset.BisnessLogic.Library.HRM
{
    public class EmployeeManager:IRepositoryManager<Employee>
    {
        private EmployeeGetway _employeeGetway;

        public EmployeeManager()
        {
            _employeeGetway = new EmployeeGetway();
        }


        public Employee Get(int id)
        {
            return _employeeGetway.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeGetway.GetAll();
        }

        public IEnumerable<Employee> GetEmployeesWithOrganization()
        {
            return _employeeGetway.GetEmployeesWithOrganization();
        }
        public bool IsEmployeeEmailExist(string email)
        {
            bool isEmployeeEmail = false;
            var employee = GetEmployeeByEmail(email);
            if (employee != null)
            {
                isEmployeeEmail = true;
            }
            return isEmployeeEmail;
        }

        private Employee GetEmployeeByEmail(string email)
        {
            return _employeeGetway.GetEmployeeByEmail(email);
        }

        public IEnumerable<Employee> FindById(int id)
        {
            return _employeeGetway.Find(id);
        }

        public Employee SingleEmployee(int id)
        {
            return _employeeGetway.SingleEmployee(id);
        }

        public int Add(Employee entity)
        {
            return _employeeGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Employee> entities)
        {
            return _employeeGetway.AddRange(entities);
        }

        public int Update(Employee entity)
        {
            return _employeeGetway.Update(entity);
        }

        public int Remove(Employee entity)
        {
            return _employeeGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Employee> entities)
        {
            return _employeeGetway.RemoveRange(entities);
        }
    }
}
