using DesignPattern.Model.AdapterPattern;
using DesignPattern.Model.BridgePattern;
using DesignPattern.Model.SingletonPattern;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace DesignPattern.Controllers
{
	/// <summary>
	/// 创建型
	/// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConstructTypeController : Controller
    {
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "adapter";
        }

        [HttpPost]
        [Route("SingletonPattern")]
        public string SingletonPattern()
        {
            SingletonPerson singletonPerson = null;
            List<Task> allTasks= new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                int j = i;
                allTasks.Add(Task.Run(() =>
                {
                    singletonPerson = SingletonPerson.GetInstance();
                    singletonPerson.GrowOneYear();
                    Console.WriteLine($"第{j}个:{Thread.CurrentThread.ManagedThreadId.ToString()}");
                }));
            }
            Task.WaitAll(allTasks.ToArray(),1000);
            return singletonPerson.Age.ToString();
        }
    }
}
