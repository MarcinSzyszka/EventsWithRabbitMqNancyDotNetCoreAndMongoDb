using EventConsumerService.Data.Entities;
using MongoDB.Driver;

namespace EventConsumerService.Data.Contexts
{
	public interface IMessageContext
	{
		IMongoCollection<MessageEntity> Messages { get; }
	};
}
