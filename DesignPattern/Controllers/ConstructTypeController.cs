using DesignPattern.Model.AdapterPattern;
using DesignPattern.Model.BridgePattern;
using DesignPattern.Model.BuilderPattern;
using DesignPattern.Model.PrototypePattern;
using DesignPattern.Model.SingletonPattern;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace DesignPattern.Controllers
{
    /// <summary>
    /// 创建型,总共（）种
    /// </summary>
    [ApiExplorerSettings(GroupName = "V1")]
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

        /// <summary>
        /// 单例
        /// </summary>
        /// <param name="id">测试使用的id号码</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SingletonPattern")]
        public string SingletonPattern(string id)
        {
            SingletonPerson singletonPerson = null;
            //var singletonObject = SingletonPerson.instanceCreateInStaticConstruction;

            Console.WriteLine("************** static静态构造函数 ******************");
            List<Task> allTasks= new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                int j = i;
                allTasks.Add(Task.Run(() =>
                {
                    singletonPerson = SingletonPerson.instance;
                    singletonPerson.GrowOneYear();
                    Console.WriteLine($"第{j}个:Age{singletonPerson.Age},ThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");
                }));
            }
            Task.WaitAll(allTasks.ToArray(), 1000);
            allTasks.Clear();

            Console.WriteLine("************** 获取单例 ******************");
            for (int i = 0; i < 100; i++)
            {
                int j = i;
                allTasks.Add(Task.Run(() =>
                {
                    singletonPerson = SingletonPerson.GetInstance();
                    singletonPerson.GrowOneYear();
                    Console.WriteLine($"static第{j}个:Age{singletonPerson.Age},ThreadId:{Thread.CurrentThread.ManagedThreadId.ToString()}");
                }));
            }
            Task.WaitAll(allTasks.ToArray(), 1000);

            return singletonPerson.Age.ToString();
        }

        /// <summary>
        /// 建造者
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("BuilderPattern")]
        public string BuilderPattern()
        {
            var computer = new Computer();
            var name1 = computer.Name;
            var name2 = computer.Name;
            var computerBuilder = new ComputerBuilder().SetBrand("ThinkBook")
                .SetCPU("AMD_R7_5600")
                .SetMemory(32)
                .SetHardDisk(500)
                .SetScreen(14.0m);
            Computer computerInstance = computerBuilder.Build();

            return JsonConvert.SerializeObject(computerInstance);
        }

        /// <summary>
        /// 原型模式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("PrototypePattern")]
        public string PrototypePattern()
        {
            Order order = new Order();
            order.SetName("BasketBall");
            order.Items.Add(new Item() { Name = "电视机"});
            Order cloneOrder = order.Clone();

            var orderName = order.Print();
            var cloneOrderName = cloneOrder.Print();

            order.SetName("Football");
            order.Items.Add(new Item() { Name = "空调"});  //Items也需要Clone，订单的拷贝是浅拷贝。

            orderName = order.Print();
            cloneOrderName = cloneOrder.Print();

            bool itemEuqals = cloneOrder.Items.Count == 2;  //Items也需要Clone，订单的拷贝是浅拷贝。

            return JsonConvert.SerializeObject(cloneOrder);
        }



    }
}
