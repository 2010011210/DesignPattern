namespace DesignPattern.Model.StrategyPattern
{
	public class CouponPromotion : IPromotion
	{
		public void DoPromotion()
		{
			Console.WriteLine("使用优惠券抵扣"); ;
		}
	}
}
