using EmployeeManagement.Web.Areas.Employee.Models;
using EmployeeManagement.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    [Area("Employee"),Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DashBoardViewModel model = new DashBoardViewModel();
            model.EmployeeCount = _context.employees.Count();
            model.LeavelistCount = _context.Leaves.Count();
            return View(model);
        }
    }
}
