using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels.AssetSetups
{
    public class AssetManufacturerViewModel
    {
        public IEnumerable<AssetGroup> AssetGroups { get; set; }

        public AssetManufacurer AssetManufacurer { get; set; }
    }
}