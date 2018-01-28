using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Purchase
{
    public class VendorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please insert Short Name")]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Please insert Contact No")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
    }
}