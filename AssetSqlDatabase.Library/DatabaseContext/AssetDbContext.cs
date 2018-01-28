using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.HrModels;
using Asset.Models.Library.EntityModels.OrganizationModels;
using Asset.Models.Library.EntityModels.Purchases;
using System.Data.Entity;

namespace AssetSqlDatabase.Library.DatabaseContext
{
    public class AssetDbContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetGroup> AssetGroups { get; set; }
        public DbSet<AssetManufacurer> AssetManufacurers { get; set; }
        public DbSet<AssetModel> AssetModels { get; set; }

        public DbSet<AssetEntry> AssetEntries { get; set; }


        public DbSet<Finance> Finances { get; set; }
        public DbSet<ServiceOrRepairing> ServiceOrRepairings { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Attchment> Attchments { get; set; }


        public DbSet<CheckOut> CheckOuts { get; set; }
    }
}
