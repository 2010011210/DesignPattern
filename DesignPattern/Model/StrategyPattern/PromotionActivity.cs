namespace DesignPattern.Model.StrategyPattern
{
	public class PromotionActivity
	{
		private IPromotion _promotion;

		public PromotionActivity(IPromotion promotion) 
		{
			this._promotion = promotion;
		}

		public void Execute() 
		{
			this._promotion.DoPromotion();
		}
	}
}
