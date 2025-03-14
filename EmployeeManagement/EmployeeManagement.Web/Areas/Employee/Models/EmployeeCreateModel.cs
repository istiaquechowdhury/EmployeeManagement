using EmployeeManagement.Web.Entities;
using EmployeeManagement.Web.Identity;

namespace EmployeeManagement.Web.Areas.Employee.Models
{
    public class EmployeeCreateModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public DateOnly? JoiningDate { get; set; }

        public bool Status { get; set; }


      

        public Guid? UserId { get; set; }

       
    }
}
