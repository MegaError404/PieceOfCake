namespace Alaiala_API.Interfaces
{
	public interface IMessenger
	{
		void SendMessage<RecipientType>(RecipientType recipient, IMessage message);
		void SendGroupMessage<RecipientType>(List<RecipientType> recipients, IMessage message);
		void SendBroadcastMessage(IMessage message);
	}
}
