using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class AssetGroupViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Asset Type")]
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }
        public IEnumerable<AssetType> AssetTypes { get; set; }

        [Required(ErrorMessage = "Please Insert Asset Group Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Insert Asset Group Short Name")]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [Display(Name = "Code")]
        public string GroupCode { get; set; }
    }
}