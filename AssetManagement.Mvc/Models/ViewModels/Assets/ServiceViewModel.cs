using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public virtual AssetEntry AssetEntry { get; set; }

        [Required(ErrorMessage = "Please Insert Servece Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Plaese insert Service Date")]
        [Display(Name = "Service Date")]
        public DateTime? ServiceDate { get; set; }

        [Display(Name = "Service Cost")]
        public decimal ServiceingCostDecimal { get; set; }

        [Display(Name = "Parts Cost")]
        public decimal PartsCostDecimal { get; set; }

        [Display(Name = "Tax")]
        public decimal TaxDecimal { get; set; }

        [Display(Name = "Service By")]
        public string ServiceBy { get; set; }

    }
}