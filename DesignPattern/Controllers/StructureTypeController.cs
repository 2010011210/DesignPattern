using DesignPattern.Model.AdapterPattern;
using DesignPattern.Model.BridgePattern;
using DesignPattern.Model.SingletonPattern;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DesignPattern.Controllers
{
    /// <summary>
    /// 结构性，总共7种：  1.适配器 2.桥接 、
    /// 装饰器模式（就是包一层，把要装饰的对象包到装饰器类，触发方法的时候，先触发装饰对象类的，然后再加一些其他的装饰内容。感觉和代理好像）
    /// 代理模式、外观模式、组合模式、
    /// 享元模式（这个不就是缓存吗？对象缓存起来，再次用的时候直接从缓存取）
    /// 待实现  装饰器。
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

        // 3.装饰器  就是包一层，把要装饰的对象包到装饰器类，触发方法的时候，先触发装饰对象类的，然后再加一些其他的装饰内容。



    }
}
