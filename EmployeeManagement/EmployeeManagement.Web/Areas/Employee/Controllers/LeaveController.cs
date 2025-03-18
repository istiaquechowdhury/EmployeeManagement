using EmployeeManagement.Web.Areas.Employee.Models;
using EmployeeManagement.Web.Data;
using EmployeeManagement.Web.Entities;
using EmployeeManagement.Web.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    [Area("Employee"),Authorize]
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
                    return Unauthorized();
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
                    EmployeeId = employee.Id,  
                    Status = "Pending",
                    ApprovedBy = null
                };

                _context.Leaves.Add(leave);
                _context.SaveChanges(); 

                return RedirectToAction("LeaveList");
                

                
              
            }

            return View(model);
        }

        public async Task<IActionResult> LeaveRequests()
        {
            var leaves = await _context.Leaves.Include(l => l.Employee).ToListAsync();
            return View(leaves);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            leave.Status = "Approved";  
            leave.ApprovedBy = user.UserName; 

            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();

            return RedirectToAction("LeaveList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            leave.Status = "Rejected";
            leave.ApprovedBy = User.Identity.Name;

            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();

            return RedirectToAction("LeaveList");
        }


    }
}

