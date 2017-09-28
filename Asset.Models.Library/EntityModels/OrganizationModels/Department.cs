
namespace Asset.Models.Library.EntityModels.OrganizationModels
{
    public class Department
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string DepartmentCode { get; set; }
    }
}
