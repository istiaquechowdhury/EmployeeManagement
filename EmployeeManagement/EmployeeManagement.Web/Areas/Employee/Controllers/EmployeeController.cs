using EmployeeManagement.Web.Areas.Employee.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagement.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    [Area("Employee"),Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.employees.ToList();
            return View(employees);
        }


        public IActionResult Update(int id)
        {
            var employee = _context.employees
                .Include(e => e.User)  
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();  
            }

            var model = new EmployeeUpdateModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                JoiningDate = employee.JoiningDate,
                Status = employee.Status,
                UserId = employee.UserId 
            };

            ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });

            return View(model);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _context.employees
                    .Include(e => e.User) 
                    .FirstOrDefault(e => e.Id == model.Id);

                if (employee == null)
                {
                    return NotFound();
                }

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.JoiningDate = model.JoiningDate;
                employee.Status = model.Status;
                employee.UserId = model.UserId;  

                _context.Update(employee);

                _context.SaveChanges();

                return RedirectToAction("Index");  
            }

            ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });
            return View(model);
        }


        public IActionResult GetEmployeeDetails(Guid UserId)
        {
            var employeeDetails = _context.employees
                .Include(u => u.User)
                .Where(u => u.UserId == UserId)
                .Select(e => new
                {
                    name = e.Name,
                    email = e.Email,
                    phoneNumber = e.User.PhoneNumber,
                    department = e.Department,
                    joiningDate = e.JoiningDate,
                    emailConfirmed = e.User.EmailConfirmed
                })
                .FirstOrDefault();

                if (employeeDetails == null)
                {
                    return NotFound();
                }

            return Json(employeeDetails);  

        }   


        



    }
}
