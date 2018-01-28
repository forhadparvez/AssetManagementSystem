using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Organizations
{
    public class OrganizationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Organization Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Organization Short Name")]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }
    }
}