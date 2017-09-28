using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementUI.ViewModels
{
    public class OrganizationViewModel
    {
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