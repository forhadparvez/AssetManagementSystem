
namespace Asset.Models.Library.EntityModels.AssetsModels.AssetSetups
{
    public class AssetModel
    {
        public int Id { get; set; }

        public int AssetGroupId { get; set; }
        public AssetGroup AssetGroup { get; set; }

        public int AssetManufacurerId { get; set; }
        public AssetManufacurer AssetManufacurer { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
