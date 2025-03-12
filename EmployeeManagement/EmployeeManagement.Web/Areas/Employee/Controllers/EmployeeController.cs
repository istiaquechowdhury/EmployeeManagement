using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Areas.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
