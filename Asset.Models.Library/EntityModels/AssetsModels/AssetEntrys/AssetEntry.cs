using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys
{
    public class AssetEntry
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int AssetLocationId { get; set; }
        public AssetLocation AssetLocation { get; set; }

        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; }

        public int AssetGroupId { get; set; }
        public AssetGroup AssetGroup { get; set; }

        public int AssetManufacurerId { get; set; }
        public AssetManufacurer AssetManufacurer { get; set; }

        public int AssetModelId { get; set; }
        public AssetModel AssetModel { get; set; }

        public string AssetId { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Brand { get; set; }
        public bool Status { get; set; }
        public byte[] Attachment { get; set; }
    }
}
