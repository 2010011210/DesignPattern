namespace DesignPattern.Model.BridgePattern
{
	public class QQMessage : IMessage
	{
		public void SendMessage(string content, string toUser)
		{
			Console.WriteLine($"QQ消息 {content},发送给{toUser}") ;
		}
	}
}
