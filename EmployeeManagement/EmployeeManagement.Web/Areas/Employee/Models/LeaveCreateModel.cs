namespace EmployeeManagement.Web.Areas.Employee.Models
{
    public class LeaveCreateModel
    {
        public string? Reason { get; set; }

        public string? LeaveType { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

       
    }
}
