namespace DesignPattern.Model.StrategyPattern
{
	public class GroupbuyPromotion : IPromotion
	{
		public void DoPromotion() 
		{
			Console.WriteLine("团购优惠");
		}
	}
}
