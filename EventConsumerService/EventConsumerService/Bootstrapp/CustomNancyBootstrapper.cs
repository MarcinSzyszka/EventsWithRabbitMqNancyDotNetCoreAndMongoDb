using EventConsumerService.Data.Contexts;
using EventConsumerService.Data.Models;
using EventConsumerService.Services.Data;
using Nancy;
using Nancy.TinyIoc;

namespace EventConsumerService.Bootstrapper
{
	public class CustomNancyBootstrapper : DefaultNancyBootstrapper
    {
	    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
	    {
			container.Register<AppSettings>();
			container.Register<IMessageContext, MessageContext>();
			container.Register<IMessagesService, MessagesService>();

			base.ConfigureApplicationContainer(container);
	    }
	}
}
