using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ActionTypeController : Controller
    {
		[HttpGet]
		[Route("index")]
		public string Index()
		{
			return "index";
		}
	}
}
