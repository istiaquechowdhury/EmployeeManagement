using EmployeeManagement.Web.Areas.Employee.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create ()
        {
            var model = new EmployeeCreateModel ();
            ViewBag.Department = new SelectList(new[] { "HR", "Account", "Software"});

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCreateModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeManagement.Web.Entities.Employee emp = new EmployeeManagement.Web.Entities.Employee()
                {
                   
                    Department = model.Department,
                    JoiningDate = model.JoiningDate,
                    Status = model.Status,
                };


                return RedirectToAction("Index");
            }
            return View(model);
        }




    }
}
