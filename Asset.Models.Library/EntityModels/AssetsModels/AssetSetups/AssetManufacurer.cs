
namespace Asset.Models.Library.EntityModels.AssetsModels.AssetSetups
{
    public class AssetManufacurer
    {
        public int Id { get; set; }

        public int AssetGroupId { get; set; }
        public AssetGroup AssetGroup { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
