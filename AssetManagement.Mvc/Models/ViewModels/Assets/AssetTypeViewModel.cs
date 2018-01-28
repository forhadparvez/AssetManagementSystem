using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class AssetTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert Asset Type Name")]
        public string Name { get; set; }

        [Display(Name = "Short Name")]
        [Required(ErrorMessage = "Please Insert Asset Type Short Name")]
        public string ShortName { get; set; }

        public string Code { get; set; }
    }
}