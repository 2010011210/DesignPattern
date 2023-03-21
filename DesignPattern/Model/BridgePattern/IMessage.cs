namespace DesignPattern.Model.BridgePattern
{
	public interface IMessage
	{
		void SendMessage(string content, string to);
	}
}
