namespace DesignPattern.Model.BridgePattern
{
	public abstract class AbstractMessage : IMessage
	{
	    protected IMessage message;
		public AbstractMessage(IMessage message) 
		{
			this.message = message;
		}
		public abstract void SendMessage(string content, string to);
	}
}
