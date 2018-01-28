using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class AssetManufacturerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Asset Group")]
        [Display(Name = "Asset Group")]
        public int AssetGroupId { get; set; }

        public IEnumerable<AssetGroup> AssetGroups { get; set; }

        [Required(ErrorMessage = "PLease Insert Manufacturer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "PLease Insert Manufacturer Short Name")]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

    }
}