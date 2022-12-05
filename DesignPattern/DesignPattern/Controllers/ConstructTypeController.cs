using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    public class ConstructTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
