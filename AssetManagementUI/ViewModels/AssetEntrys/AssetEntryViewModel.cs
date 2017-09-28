using Asset.Models.Library.EntityModels;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels.AssetEntrys
{
    public class AssetEntryViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<AssetLocation> AssetLocations { get; set; }

        public IEnumerable<AssetType> AssetTypes { get; set; }
        public IEnumerable<AssetGroup> AssetGroups { get; set; }
        public IEnumerable<AssetManufacurer> AssetManufacurers { get; set; }
        public IEnumerable<AssetModel> AssetModels { get; set; }
        public IEnumerable<Status> Status { get; set; }

        public AssetEntry AssetEntry { get; set; }
    }
}