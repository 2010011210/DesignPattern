namespace DesignPattern.Model.StrategyPattern
{
	public class EmptyPromotion : IPromotion
	{
		public void DoPromotion()
		{
			Console.WriteLine("没有优惠"); 
		}
	}
}
