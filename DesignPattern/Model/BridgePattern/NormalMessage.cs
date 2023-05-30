namespace DesignPattern.Model.BridgePattern
{
	public class NormalMessage : AbstractMessage
	{
		public NormalMessage(IMessage message): base(message) 
		{
		
		}

		public override void SendMessage(string content, string to)
		{
			content = $"【普通】{content} {DateTime.Now.ToString("yyyy-MM--dd HH:mm:ss")}";  // 1.消息紧急情况维度。 是紧急还是普通
			base.message.SendMessage(content, to);                                           // 2.消息类型维度， 是qq还是微信
		}
	}
}
