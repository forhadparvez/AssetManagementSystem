using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels.AssetSetups
{
    public class AssetGroupViewModels
    {
        public IEnumerable<AssetType> AssetTypes { get; set; }
        public AssetGroup AssetGroup { get; set; }
    }
}