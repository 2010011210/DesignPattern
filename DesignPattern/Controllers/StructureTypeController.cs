using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StructureTypeController : Controller
    {
		[HttpGet]
		[Route("index")]
		public string Index()
        {
            return "index";
        }

        [HttpPost]
        [Route("SingletonPattern")]
        public string SingletonPattern()
        {
            return "index";
        }

    }
}
