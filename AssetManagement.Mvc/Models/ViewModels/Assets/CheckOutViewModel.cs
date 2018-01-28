using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.HrModels;
using System;
using System.Collections.Generic;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class CheckOutViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public int AssetLocationId { get; set; }
        public IEnumerable<AssetLocation> AssetLocations { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime? ReturnDate { get; set; }


        public string Commants { get; set; }

        public int AssetEntryId { get; set; }
        public IEnumerable<AssetEntry> AssetEntries { get; set; }
    }
}