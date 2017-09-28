
namespace Asset.Models.Library.EntityModels.OrganizationModels
{
    public class Designation
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
