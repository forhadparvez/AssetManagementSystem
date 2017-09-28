using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.HrModels;
using System;
using System.Collections.Generic;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation
{
    public class CheckOut
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public DateTime EntryDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int AssetLocationId { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }

        public string Commants { get; set; }

        public int AssetEntrysId { get; set; }
        public virtual IEnumerable<AssetEntrys.AssetEntry> AssetEntries { get; set; }
    }
}
