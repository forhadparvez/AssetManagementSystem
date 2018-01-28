using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AssetManagement.Mvc.Models.ViewModels.Assets
{
    public class AttchmentViewModel
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public AssetEntry AssetEntry { get; set; }

        //[Required(ErrorMessage = "Please Choose File")]
        //public HttpPostedFileBase File { get; set; }
        public string File { get; set; }
    }
}