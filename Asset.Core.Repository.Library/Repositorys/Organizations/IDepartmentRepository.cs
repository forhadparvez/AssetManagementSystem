using System.Collections.Generic;
using Asset.Models.Library.EntityModels.OrganizationModels;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.Organizations
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department GetDepartmentByShortName(string shortName);
        Designation GetDesignationByShortName(string shortNme);
        IEnumerable<Department> GetDepartmentWithOrganization();
        IEnumerable<Designation> GetDesignationsWithOrganization();
    }
}
