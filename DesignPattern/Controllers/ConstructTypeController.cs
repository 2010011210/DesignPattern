using DesignPattern.Model.AdapterPattern;
using DesignPattern.Model.BridgePattern;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConstructTypeController : Controller
    {
        public string Index()
        {
            return "adapter";
        }

        /// <summary>
        /// 适配器
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
		/// 桥接
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("bridge")]
		public string BridgePattern()
		{
			IMessage message = new QQMessage();
			AbstractMessage abstractMessage = new NormalMessage(message);
			abstractMessage.SendMessage("你在哪？","李雷");

			message = new WeChatMessage();
			abstractMessage = new UrgencyMessage(message);
			abstractMessage.SendMessage("你在哪？", "李雷");
			return "ok";
		}
	}
}
