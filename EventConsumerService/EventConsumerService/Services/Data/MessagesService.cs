using System;
using System.Collections.Generic;
using EventConsumerService.Data.Contexts;
using EventConsumerService.Data.Entities;
using MongoDB.Driver;

namespace EventConsumerService.Services.Data
{
	public class MessagesService : IMessagesService
	{
		private readonly IMessageContext context;

		public MessagesService(IMessageContext context)
		{
			this.context = context;
		}

		public IEnumerable<MessageEntity> GetAllMessages()
		{
			return this.context.Messages.Find(_ => true).ToList();
		}

		public MessageEntity InsertMessage(string message)
		{
			var date = DateTime.Parse(message);
			var messageEntity = new MessageEntity { Id = Guid.NewGuid(), MessagePublishDateTime = date };

			this.context.Messages.InsertOne(messageEntity);

			return messageEntity;
		}
	}
}
