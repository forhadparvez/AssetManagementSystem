using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels.AssetSetups
{
    public class AssetLocationViewModel
    {
        public AssetLocation AssetLocation { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
    }
}