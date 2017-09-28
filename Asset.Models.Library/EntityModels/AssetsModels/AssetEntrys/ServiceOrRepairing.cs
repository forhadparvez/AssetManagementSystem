using System;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class ServiceOrRepairing
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public virtual AssetEntry AssetEntry { get; set; }

        public string Description { get; set; }
        public DateTime? ServiceDate { get; set; }
        public decimal ServiceingCostDecimal { get; set; }
        public decimal PartsCostDecimal { get; set; }
        public decimal TaxDecimal { get; set; }
        public string ServiceBy { get; set; }
    }
}
