using Asset.Models.Library.EntityModels.Purchases;
using System;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class Finance
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public AssetEntry AssetEntry { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public decimal ParchasePrice { get; set; }
        public string ParchaseOrderNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
