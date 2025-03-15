using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Areas.Employee.Models
{
    public class EmployeeUpdateModel
    {
        public int Id { get; set; }     
        public string? Name { get; set; }

        public string? Email { get; set; }

        [Required]
        public string? Department { get; set; }

        [Required]
        public DateOnly? JoiningDate { get; set; }

        public bool Status { get; set; }




        public Guid? UserId { get; set; }

    }
}
