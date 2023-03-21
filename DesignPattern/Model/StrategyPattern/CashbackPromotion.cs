namespace DesignPattern.Model.StrategyPattern
{
	public class CashbackPromotion : IPromotion
	{
		public void DoPromotion()
		{
			Console.WriteLine("现金返现优惠"); 
		}
	}
}
