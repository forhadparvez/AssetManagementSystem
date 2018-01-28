using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.Purchases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class FinanceViewModel
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public AssetEntry AssetEntry { get; set; }

        [Required(ErrorMessage = "Please Select Vendor")]
        [Display(Name = "Vendor")]
        public int VendorId { get; set; }

        public IEnumerable<Vendor> Vendor { get; set; }

        [Required(ErrorMessage = "Please Insert Perchase Price")]
        [Display(Name = "Parchase Price")]
        public decimal ParchasePrice { get; set; }

        [Required(ErrorMessage = "Please Insert Parchase Order No")]
        [Display(Name = "Purchase Order No")]
        public string ParchaseOrderNo { get; set; }

        [Required(ErrorMessage = "Please Insert Purchase Date")]
        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }
    }
}