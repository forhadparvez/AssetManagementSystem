
namespace Asset.Models.Library.EntityModels.AssetsModels.AssetSetups
{
    public class AssetGroup
    {
        public int Id { get; set; }

        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string GroupCode { get; set; }
    }
}
