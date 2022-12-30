using BookReader.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookReader.Infrastructure.Logging
{
	public class ExceptionHandlingFilter : IExceptionFilter
	{
		private readonly ILogger<ExceptionHandlingFilter> _errorLogger;

		public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
		{
			_errorLogger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			_errorLogger.LogError(context.ToString(), context.Exception);
		}
	}
}
