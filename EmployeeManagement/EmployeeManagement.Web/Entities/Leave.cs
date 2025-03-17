using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EmployeeManagement.Web.Entities
{
    public class Leave
    {
        public int Id { get; set; }

        public string? Status { get; set; } = "Pending";

        public string? Reason { get; set; }

        public string? LeaveType { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string? ApprovedBy { get; set; } 





    }
}
