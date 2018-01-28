using System;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetOpetation
{
    public class CheckOut
    {
        public int Id { get; set; }

        public int Employee { get; set; }

        public int AssetLocation { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime? ReturnDate { get; set; }


        public string Commants { get; set; }

        public int AssetEntry { get; set; }
    }
}
