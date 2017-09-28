using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels.AssetSetups
{
    public class AssetModelViewModel
    {
        public IEnumerable<AssetManufacurer> AssetManufacurers { get; set; }

        public IEnumerable<AssetGroup> AssetGroups { get; set; }
        public AssetModel AssetModel { get; set; }
    }
}