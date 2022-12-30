using BookReader.Infrastructure;
using BookReader.Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BookReader.Api.Infrastructure.Extensions
{
	public static class EntityFrameworkExtensions
	{
		public static IServiceCollection WithEntityFramework(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

			return services;
		}

		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookReader.Api", Version = "v1" });
			});

			return services;
		}

		public static IServiceCollection AddCustomCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("default", policy =>
				{
					policy.WithOrigins("http://localhost:3000")
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			return services;
		}

		public static IServiceCollection AddCustomMvc(this IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add(typeof(LoggingActionFilter));
				options.Filters.Add(typeof(ExceptionHandlingFilter));
			}).AddNewtonsoftJson();

			//var serviceProvider = services.BuildServiceProvider();
			//var logger = serviceProvider.GetService<ILogger<Logger>>();
			//services.AddSingleton(typeof(ILogger), logger);

			return services;
		}


		public static IApplicationBuilder MigrateDb(this IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
			if (serviceScope == null)
				return app;

			var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();

			return app;
		}
	}
}
