using System.Collections.Generic;
using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using Core.Repository.Library.Infrastucture;
using System.Linq;
using System.Data.Entity;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }

        public AssetDbContext AssetDbContext { get { return Context as AssetDbContext; } }

        public Department GetDepartmentByShortName(string shortName)
        { 
            var department = AssetDbContext.Departments.SingleOrDefault(c => c.ShortName == shortName);
            return department;
        }

        public Designation GetDesignationByShortName(string shortNme)
        {
            var designation = AssetDbContext.Designations.SingleOrDefault(c => c.ShortName == shortNme);
            return designation;
        }

        public IEnumerable<Department> GetDepartmentWithOrganization()
        {
            var departments = AssetDbContext.Departments.Include(c => c.Organization);
            return departments;
        }

        public IEnumerable<Designation> GetDesignationsWithOrganization()
        {
            var designations = AssetDbContext.Designations.Include(c => c.Department);
            return designations;
        }
    }
}
