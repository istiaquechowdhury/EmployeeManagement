using EmployeeManagement.Web.Areas.Employee.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagement.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
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





        //public IActionResult Update(int id)
        //{
        //    var employee = _context.employees
        //    .Include(e => e.User)  // ✅ Include User entity
        //    .FirstOrDefault(e => e.Id == id);

        //    var model = new EmployeeUpdateModel()
        //    {
        //        Id = employee.Id,
        //        Name = employee.Name,
        //        Email = employee.Email,
        //        Department = employee.Department,
        //        JoiningDate = employee.JoiningDate,
        //        Status = employee.Status,
        //        UserId = employee.UserId,


        //    };

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });
        //    return View(model);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public IActionResult Update(EmployeeUpdateModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var employee = _context.employees
        //      .Include(e => e.User)  // ✅ Include User entity
        //      .FirstOrDefault(e => e.Id == model.Id);

        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        var emp = new EmployeeManagement.Web.Entities.Employee();
        //        {
        //            emp.Id = model.Id;
        //            emp.Name = model.Name;
        //            emp.Email = model.Email;    
        //            emp.Department = model.Department;
        //            emp.JoiningDate = model.JoiningDate;  
        //            emp.Status = model.Status;  
        //            emp.UserId = model.UserId;

        //        };


        //        _context.employees.Update(emp);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });
        //    return View(model);
        //}

        public IActionResult Update(int id)
        {
            var employee = _context.employees
                .Include(e => e.User)  // Include User entity to get UserId and other related data
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();  // If employee is not found, return NotFound error
            }

            var model = new EmployeeUpdateModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                JoiningDate = employee.JoiningDate,
                Status = employee.Status,
                UserId = employee.UserId // Make sure this is correctly populated
            };

            // Populate the department options for the dropdown
            ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });

            return View(model);  // Pass the model to the view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the employee from the database
                var employee = _context.employees
                    .Include(e => e.User) // Ensure User entity is included if you need it
                    .FirstOrDefault(e => e.Id == model.Id);

                // If the employee doesn't exist, return NotFound error
                if (employee == null)
                {
                    return NotFound();
                }

                // Update the employee properties with values from the form
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.JoiningDate = model.JoiningDate;
                employee.Status = model.Status;
                employee.UserId = model.UserId;  // Ensure UserId is updated properly

                // Update the employee in the context
                _context.Update(employee);

                // Save changes to the database
                _context.SaveChanges();

                // After successful update, redirect to the list of employees or any other page
                return RedirectToAction("Index");  // Replace "Index" with the desired action
            }

            // If the model is not valid, repopulate the department options and return the view
            ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });
            return View(model);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(EmployeeUpdateModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var employee = _context.employees
        //            .FirstOrDefault(e => e.Id == model.Id);

        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        // ✅ Update the existing entity
        //        employee.Name = model.Name;
        //        employee.Email = model.Email;
        //        employee.Department = model.Department;
        //        employee.JoiningDate = model.JoiningDate;
        //        employee.Status = model.Status;
        //        employee.UserId = model.UserId;

        //        _context.SaveChanges(); // ✅ No need for _context.employees.Update(employee)

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Department = new SelectList(new[] { "Account", "HR", "Software" });

        //    return View(model);
        //}





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
