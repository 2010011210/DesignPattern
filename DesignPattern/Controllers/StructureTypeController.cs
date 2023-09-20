using DesignPattern.Model.AdapterPattern;
using DesignPattern.Model.BridgePattern;
using DesignPattern.Model.SingletonPattern;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DesignPattern.Controllers
{
    /// <summary>
    /// 结构性
    /// </summary>
    [ApiExplorerSettings(GroupName = "V1")]
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

        

        /// <summary>
        /// 1.适配器
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("adapter")]
        public int AdapterPattern()
        {
            // 1.类适配器
            var adapter = new PowerClassAdapter();
            var outPut = adapter.OutPut5V();        //adapter也可以调用父类中的方法，违背最少知道原则。

            //2.对象适配器
            var adapterObj = new PowerObjectAdapter(new AC220());
            outPut = adapterObj.OutPut5V();         // 只能调用OutPut5V方法。
            return outPut;
        }

        /// <summary>
        /// 2.桥接
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("bridge")]
        public string BridgePattern()
        {
            IMessage message = new QQMessage();
            AbstractMessage abstractMessage = new NormalMessage(message);
            abstractMessage.SendMessage("你在哪？", "李雷");

            message = new WeChatMessage();
            abstractMessage = new UrgencyMessage(message);
            abstractMessage.SendMessage("你在哪？", "李雷");
            return "ok";
        }

        // 3.装饰器

    }
}
