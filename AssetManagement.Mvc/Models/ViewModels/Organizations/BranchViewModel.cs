using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Organizations
{
    public class BranchViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Organization")]
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        public IEnumerable<Organization> Organizations { get; set; }

        [Required(ErrorMessage = "Please Insert Branch Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Insert Branch Short Name")]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
    }
}