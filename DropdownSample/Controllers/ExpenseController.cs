using Microsoft.AspNetCore.Mvc;

namespace DropdownSample.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
