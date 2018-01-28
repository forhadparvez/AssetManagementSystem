using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Organizations
{
    public class AssetLocationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Organization")]
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }

        [Required(ErrorMessage = "Please Select Branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        public IEnumerable<Branch> Branches { get; set; }

        [Required(ErrorMessage = "Please Insert Location Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Insert Short Name")]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [Display(Name = "Code")]
        public string LocationCode { get; set; }
    }
}