using System.ComponentModel.DataAnnotations;

namespace AssetManagementUI.ViewModels.Purchases
{
    public class VendorViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Vendor name is require!")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} charact", MinimumLength = 3)]
        [Display(Name = "Vendor Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Short Name must be require!")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
        
        [Required(ErrorMessage = "Email address must be require!")]
        [StringLength(320, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The contact number must be require!")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 14)]
        [Display(Name = "Phone Number")]
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
    }
}