using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels
{
    public class DepartmentViewModel
    {
        public Department Department { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
    }
}