using System.ComponentModel.DataAnnotations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace AssetManagementUI.ViewModels
{
    public class DesignationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select your department name")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required(ErrorMessage = "The designation name must be require!")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long!", MinimumLength = 5)]
        [Display(Name = "Designation Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The designation short name must be require!")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long!", MinimumLength = 3)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
    }
}