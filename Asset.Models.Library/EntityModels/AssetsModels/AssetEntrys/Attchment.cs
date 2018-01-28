

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class Attchment
    {
        public int Id { get; set; }

        public int AssetEntryId { get; set; }
        public AssetEntry AssetEntry { get; set; }

        public byte[] File { get; set; }
    }
}
