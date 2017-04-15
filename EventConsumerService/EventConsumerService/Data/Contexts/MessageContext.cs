using EventConsumerService.Data.Entities;
using EventConsumerService.Data.Models;
using MongoDB.Driver;

namespace EventConsumerService.Data.Contexts
{
	public class MessageContext : IMessageContext
	{
		private readonly IMongoDatabase database;

		public MessageContext(AppSettings settings)
		{
			var client = new MongoClient(settings.GetConnectionString());

			if (client != null)
				database = client.GetDatabase(settings.GetDatabaseName());
		}

		public IMongoCollection<MessageEntity> Messages => database.GetCollection<MessageEntity>("MessageEntity");
	}
}
