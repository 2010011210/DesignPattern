namespace DesignPattern.Model.BridgePattern
{
	public class NormalMessage : AbstractMessage
	{
		public NormalMessage(IMessage message): base(message) 
		{
		
		}

		public override void SendMessage(string content, string to)
		{
			content = $"【普通】{content} {DateTime.Now.ToString("yyyy-MM--dd HH:mm:ss")}";
			base.message.SendMessage(content, to);
		}
	}
}
