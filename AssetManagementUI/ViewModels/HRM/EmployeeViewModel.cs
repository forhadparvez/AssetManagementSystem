using Asset.Models.Library.EntityModels.HrModels;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels.HRM
{
    public class EmployeeViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Designation> Designations { get; set; }
        public Employee Employee { get; set; }

    }
}