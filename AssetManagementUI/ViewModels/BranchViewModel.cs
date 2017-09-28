using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;

namespace AssetManagementUI.ViewModels
{
    public class BranchViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
        public Branch Branch { get; set; }

    }
}