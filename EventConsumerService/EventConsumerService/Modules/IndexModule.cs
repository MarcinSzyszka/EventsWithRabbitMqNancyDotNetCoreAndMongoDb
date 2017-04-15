using System.Globalization;
using System.Text;
using EventConsumerService.Services.Data;
using Nancy;

namespace EventConsumerService.Modules
{
	public class IndexModule : NancyModule
	{
		private readonly IMessagesService messagesService;

		public IndexModule(IMessagesService messagesService)
		{
			this.messagesService = messagesService;
			Get("/", args =>
			{
				var responseMessage = "Hello World, it's Event Consumer service. Since I've been created, I consume events from helloWorldQueue. Here are all messages dates:";

				var sb = new StringBuilder(responseMessage);
				sb.AppendLine();

				var messages = this.messagesService.GetAllMessages();
				foreach (var messageEntity in messages)
				{
					sb.AppendLine(messageEntity.MessagePublishDateTime.ToString(CultureInfo.InvariantCulture));
				}

				return sb.ToString();
			});
		}
	}
}
