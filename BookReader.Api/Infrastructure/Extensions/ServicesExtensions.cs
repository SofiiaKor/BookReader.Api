using BookReader.Application.Interfaces;
using BookReader.Application.Models;
using BookReader.Application.Services;
using BookReader.Domain.Interfaces;
using BookReader.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookReader.Api.Infrastructure.Extensions
{
	public static class ServicesExtensions
	{
		public static IServiceCollection WithServices(this IServiceCollection services)
		{
			services.AddTransient<IBookService, BookService>();
			services.AddTransient<IBookRepository, BookRepository>();
			services.AddValidatorsFromAssembly(typeof(AddBookRequestModel).Assembly).AddFluentValidationAutoValidation();

			return services;
		}
    }
}
