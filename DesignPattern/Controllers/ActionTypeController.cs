using DesignPattern.Model.StrategyPattern;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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

		[HttpPost]
		[Route("Strategy")]
		public string Strategy(string promotionType)
		{
			// 使用策略模式前
			PromotionActivity promotionActivity;
			if ("无优惠".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new EmptyPromotion());
			}
			else if ("团购".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new GroupbuyPromotion());
			}
			else if ("优惠券".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new CouponPromotion());
			}
			else if ("返现".Equals(promotionType))
			{
				promotionActivity = new PromotionActivity(new CashbackPromotion());
			}
			else {
				promotionActivity = new PromotionActivity(new EmptyPromotion());
			}
			promotionActivity.Execute();


			// 使用策略模式后
			IPromotion promotionStrategy = PromotionStrategyFactory.GetPromotion(promotionType);
			promotionStrategy.DoPromotion();


			return "index";
		}
	}
}
