using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.Models.Library.EntityModels.AssetsModels.AssetSetups
{
    public class AssetLocation
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string BranchCode { get; set; }
    }
}
