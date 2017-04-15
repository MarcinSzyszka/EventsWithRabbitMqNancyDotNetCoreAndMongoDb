using System;
using MongoDB.Bson.Serialization.Attributes;

namespace EventConsumerService.Data.Entities
{
    public class MessageEntity
    {
		[BsonId]
		public Guid Id { get; set; }

	    public DateTime MessagePublishDateTime { get; set; }
	}
}
