
using EmployeeManagement.Web.Identity;

namespace EmployeeManagement.Web.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public DateOnly? JoiningDate { get; set; }

        public bool Status { get; set; }


        public IList<Leave>? Leaves { get; set; }

        public Guid? UserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
