namespace DesignPattern.Model.StrategyPattern
{
	public class PromotionStrategyFactory
	{
		private static Dictionary<string, IPromotion> promotionDic = new Dictionary<string, IPromotion>()
			{
				{"现金", new CashbackPromotion() },
				{"团购", new GroupbuyPromotion() },
				{"优惠券", new CouponPromotion() },
				{"无优惠", new EmptyPromotion() }
			};

		/// <summary>
		/// 把优惠种类返回给前端，有策略增加或者变动，前端可以动态修改
		/// </summary>
		/// <returns></returns>
		public static HashSet<string> GetPromotionKeys() 
		{
			return promotionDic.Keys.ToHashSet();
		}

		public static IPromotion GetPromotion(string promotionType) 
		{
			if (promotionDic.ContainsKey(promotionType)) 
			{
				return promotionDic[promotionType];
			}

			return promotionDic["无优惠"];
		} 


	}
}
