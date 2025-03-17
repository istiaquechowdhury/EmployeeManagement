using EmployeeManagement.Web.Areas.Employee.Models;
using EmployeeManagement.Web.Data;
using EmployeeManagement.Web.Entities;
using EmployeeManagement.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LeaveController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult LeaveList()
        {
            var leaves = _context.Leaves.ToList();
            return View(leaves);  
        }

        public IActionResult RequestLeave()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestLeave(LeaveCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized(); // No logged-in user
                }

                var employee = await _context.employees.FirstOrDefaultAsync(e => e.UserId == user.Id);
                if (employee == null)
                {
                    return BadRequest("Employee record not found");
                }

                var leave = new Leave
                {
                    Reason = model.Reason,
                    LeaveType = model.LeaveType,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    EmployeeId = employee.Id,  // 🔥 Assigned automatically
                    Status = "Pending",
                    ApprovedBy = null
                };

                _context.Leaves.Add(leave);
                _context.SaveChanges(); 

                return RedirectToAction("LeaveList");
                

                
              
            }

            return View(model);
        }

        // GET: Leave Requests List
        public async Task<IActionResult> LeaveRequests()
        {
            var leaves = await _context.Leaves.Include(l => l.Employee).ToListAsync();
            return View(leaves);
        }

        // Approve/Reject Leave Request
        [HttpPost]
        public async Task<IActionResult> ApproveLeave(int id, string action)
        {
            var leave = await _context.Leaves.FindAsync(id);

            if (leave == null) return NotFound();

            if (action == "Approve")
                leave.Status = "Approved";
            else
                leave.Status = "Rejected";

            leave.ApprovedBy = User.Identity.Name;
            _context.Update(leave);
            await _context.SaveChangesAsync();

            return RedirectToAction("LeaveRequests");
        }
    }
}

