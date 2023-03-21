using Microsoft.AspNetCore.Components.Routing;

namespace DesignPattern.Model.BridgePattern
{
	public class WeChatMessage : IMessage
	{
		public void SendMessage(string content, string toUser)
		{
			Console.WriteLine($"微信消息 {content},发送给{toUser}");
		}
	}
}
