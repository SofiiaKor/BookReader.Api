using BookReader.Application.Interfaces;
using BookReader.Application.Services;
using BookReader.Domain.Interface;
using BookReader.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookReader.Api.Infrastructure.Extensions
{
	public static class ServicesExtensions
	{
		public static IServiceCollection WithServices(this IServiceCollection services)
		{
			services.AddTransient<IBookService, BookService>();
			services.AddTransient<IBookRepository, BookRepository>();

			return services;
		}
    }
}
