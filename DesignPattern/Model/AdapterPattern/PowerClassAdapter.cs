namespace DesignPattern.Model.AdapterPattern
{
	public class PowerAdapter : AC220, IDC5
	{
		public int OutPut5V()
		{
			int adapterInput = base.OutPutAC220V();
			int adapterOutput = adapterInput / 44;
			Console.WriteLine($"使用Adapter，输入 {adapterInput}, 输出 {adapterOutput}");
			return adapterOutput;
		}
	}
}
