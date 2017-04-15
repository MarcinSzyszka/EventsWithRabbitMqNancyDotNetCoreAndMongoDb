using EventProducerService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy.Owin;

namespace EventProducerService
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IEventSender, EventSender>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseOwin(x => x.UseNancy());
		}
	}
}
