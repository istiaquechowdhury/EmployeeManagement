
using EmployeeManagement.Web.Identity;

namespace EmployeeManagement.Entities.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }   

        public string Department { get; set; }  

        public DateOnly JoiningDate { get; set; }

        public bool Status { get; set; }    


        public IList<Leave> Leaves { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
