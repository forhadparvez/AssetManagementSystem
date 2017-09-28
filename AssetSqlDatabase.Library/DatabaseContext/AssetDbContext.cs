using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.HrModels;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Data.Entity;

namespace AssetSqlDatabase.Library.DatabaseContext
{
    public class AssetDbContext : DbContext
    {
        /// <summary>
        /// ===============================================
        /// ***********************************************
        /// --- Creator: Md. Sumon Miah.
        /// --- Date: 24-09-2017
        /// --- Description: Set all organization related value into database.
        /// ***********************************************
        /// ===============================================
        /// </summary>
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }

        public DbSet<Employee> Employees { get; set; }


        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetGroup> AssetGroups { get; set; }


    }
}
