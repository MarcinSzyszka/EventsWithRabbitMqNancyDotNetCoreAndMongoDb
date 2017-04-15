namespace EventProducerService.Services
{
	public interface IEventSender
	{
		void SendEvent(string message);
	}
}
