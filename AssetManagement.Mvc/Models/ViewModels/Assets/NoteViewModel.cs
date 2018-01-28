using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class NoteViewModel
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public AssetEntry AssetEntry { get; set; }

        [Required(ErrorMessage = "Please insert Note")]
        public string Notes { get; set; }
    }
}