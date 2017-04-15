using System;
using System.Globalization;
using EventProducerService.Services;
using Nancy;

namespace EventProducerService.Modules
{
	public class IndexModule : NancyModule
	{
		public IndexModule(IEventSender eventSender)
		{
			Get("/", args =>
			{
				eventSender.SendEvent(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
				return "Hello World, it's Event Producer service. Every request here will produce event with messege contains current date time.";
			});
		}
	}
}
