using System;
using System.Text;
using EventConsumerService.Services.Data;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventConsumerService.Services
{
	public class EventConsumer:  IDisposable
	{
		private readonly IMessagesService messagesService;
		private IModel channel;
		private IConnection connection;
		private readonly string queueName;
		private EventingBasicConsumer consumer;

		public EventConsumer(IMessagesService messagesService)
		{
			this.messagesService = messagesService;
			this.queueName = "helloWorldQueue";
		}

		public void Start()
		{
			var factory = new ConnectionFactory() { HostName = "localhost" };
			this.connection = factory.CreateConnection();
			this.channel = connection.CreateModel();
			this.channel.QueueDeclare(queue: queueName,
				durable: false,
				exclusive: false,
				autoDelete: false,
				arguments: null);

			this.consumer = new EventingBasicConsumer(this.channel);
			consumer.Received += (model, ea) =>
			{
				var body = ea.Body;
				var message = Encoding.UTF8.GetString(body);

				messagesService.InsertMessage(message);
			};
			channel.BasicConsume(queue: this.queueName,
				noAck: true,
				consumer: consumer);
		}

		public void Dispose()
		{
			this.channel.Dispose();
			this.connection.Dispose();
		}
	}
}
