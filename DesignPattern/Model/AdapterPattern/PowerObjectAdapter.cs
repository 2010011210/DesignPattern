namespace DesignPattern.Model.AdapterPattern
{
	/// <summary>
	/// 对象适配器
	/// </summary>
	public class PowerObjectAdapter : IDC5
	{
		private AC220 ac220;
		public PowerObjectAdapter(AC220 ac220) 
		{
			this.ac220 = ac220;
		}

		public int OutPut5V()
		{
			int adapterInput = ac220.OutPutAC220V();
			int adapterOutput = adapterInput / 44;
			Console.WriteLine($"使用Adapter，输入 {adapterInput}, 输出 {adapterOutput}");
			return adapterOutput;
		}
	}
}
