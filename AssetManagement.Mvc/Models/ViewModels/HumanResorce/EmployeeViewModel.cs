using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.HumanResorce
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select Organization")]
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        public IEnumerable<Organization> Organizations { get; set; }

        [Required(ErrorMessage = "Please select Branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        public IEnumerable<Branch> Branchs { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }


        [Required(ErrorMessage = "Please Insert First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Insert Contact No")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Insert Email")]
        public string Email { get; set; }

        public string Address { get; set; }
        public string Code { get; set; }
    }
}