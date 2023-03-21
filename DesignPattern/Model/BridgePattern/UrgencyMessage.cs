namespace DesignPattern.Model.BridgePattern
{
	public class UrgencyMessage : AbstractMessage
	{
		public UrgencyMessage(IMessage message) : base(message)
		{
			
		}

		public override void SendMessage(string content, string to)
		{
			content = $"【加急】{content}{DateTime.Now.ToString("yyyy-MM--dd HH:mm:ss")}";
			base.message.SendMessage(content, to);
		}
	}
}
