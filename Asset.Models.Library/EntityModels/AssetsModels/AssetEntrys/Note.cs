
namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class Note
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public AssetEntry AssetEntry { get; set; }

        public string Notes { get; set; }
    }
}
