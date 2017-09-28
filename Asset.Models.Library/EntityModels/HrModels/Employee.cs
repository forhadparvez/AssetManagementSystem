using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.Models.Library.EntityModels.HrModels
{
    public class Employee
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int DesignationId { get; set; }
        public Designation Designation { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public string Code { get; set; }
    }
}
