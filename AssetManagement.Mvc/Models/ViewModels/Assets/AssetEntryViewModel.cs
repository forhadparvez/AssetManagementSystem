using Asset.Models.Library.EntityModels;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class AssetEntryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Organization")]
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        public IEnumerable<Organization> Organizations { get; set; }

        [Required(ErrorMessage = "Please Select Branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        public IEnumerable<Branch> Branchs { get; set; }

        [Required(ErrorMessage = "Please Select Asset Location")]
        [Display(Name = "Location")]
        public int AssetLocationId { get; set; }

        public IEnumerable<AssetLocation> AssetLocations { get; set; }

        [Required(ErrorMessage = "Please Select Asset type")]
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }

        public IEnumerable<AssetType> AssetTypes { get; set; }

        [Required(ErrorMessage = "Please Select Asset Group")]
        [Display(Name = "Asset Group")]
        public int AssetGroupId { get; set; }

        public IEnumerable<AssetGroup> AssetGroups { get; set; }

        [Required(ErrorMessage = "Please Select Asset Manufacturer")]
        [Display(Name = "Asset Manufacurer")]
        public int AssetManufacurerId { get; set; }

        public IEnumerable<AssetManufacurer> AssetManufacurers { get; set; }

        [Required(ErrorMessage = "Please Select Asset Model")]
        [Display(Name = "Asset Model")]
        public int AssetModelId { get; set; }

        public IEnumerable<AssetModel> AssetModels { get; set; }

        [Display(Name = "Asset Id")]
        public string AssetId { get; set; }

        [Required(ErrorMessage = "Please Insert Asset Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please insert Asset Serial No")]
        [Display(Name = "Serial No")]
        public string SerialNo { get; set; }

        public string Brand { get; set; }
        public bool Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}