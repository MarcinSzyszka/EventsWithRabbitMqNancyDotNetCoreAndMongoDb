using System;
using System.Text;
using RabbitMQ.Client;

namespace EventProducerService.Services
{
	public class EventSender : IEventSender, IDisposable
	{
		private readonly IModel channel;
		private readonly IConnection connection;
		private readonly string queueName;

		public EventSender()
		{
			queueName = "helloWorldQueue";
			var factory = new ConnectionFactory() { HostName = "localhost" };
			this.connection = factory.CreateConnection();
			this.channel = connection.CreateModel();
			this.channel.QueueDeclare(queue: queueName,
				durable: false,
				exclusive: false,
				autoDelete: false,
				arguments: null);
		}

		public void SendEvent(string message)
		{
			var body = Encoding.UTF8.GetBytes(message);

			this.channel.BasicPublish(exchange: "",
				routingKey: queueName,
				basicProperties: null,
				body: body);
		}

		public void Dispose()
		{
			this.channel.Dispose();
			this.connection.Dispose();
		}
	}
}
