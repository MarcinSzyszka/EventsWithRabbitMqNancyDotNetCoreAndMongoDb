using EventConsumerService.Data.Contexts;
using EventConsumerService.Data.Models;
using EventConsumerService.Services;
using EventConsumerService.Services.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy.Owin;
using Nancy.TinyIoc;

namespace EventConsumerService
{
    public class Startup
    {
	    public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

		    builder.AddEnvironmentVariables();
		    Configuration = builder.Build();
		}
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddSingleton<AppSettings>(new AppSettings(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value, Configuration.GetSection("Database:Name").Value));

	        services.AddSingleton<EventConsumer>();
	        services.AddScoped<IMessageContext, MessageContext>();
	        services.AddTransient<IMessagesService, MessagesService>();	
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, EventConsumer eventConsumer)
        {
	        eventConsumer.Start();

			app.UseOwin(o => o.UseNancy());
        }
    }
}
