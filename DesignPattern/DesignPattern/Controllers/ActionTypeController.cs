using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    public class ActionTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
