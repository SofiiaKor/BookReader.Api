using System;
using System.Net;
using BookReader.Api.Response;
using BookReader.Application.Exceptions;
using BookReader.Infrastructure.Logging.AbstractionModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookReader.Api
{
	public class ExceptionHandlingFilter : IExceptionFilter
	{
		private readonly ILogger<ExceptionHandlingFilter> _logger;

		public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
		{
			_logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;

			var responseCode = MapException(context.Exception);

			var log = new LogError
			{
				LogType = "Error",
				Name = descriptor.ActionName,
				Method = descriptor.MethodInfo.Name,
				Message = context.Exception.Message,
				Detail = context.Exception.StackTrace,
				ResponseCode = (int) responseCode
			};

			using (_logger.BeginScope(log.ToDictionary()))
			{
				_logger.LogError(log.Message);
			}

			context.Result = ApiResponse.ErrorResponse(responseCode, context.Exception);
		}

		private static HttpStatusCode MapException(Exception exception)
		{
			return exception switch
			{
				BookAlreadyExistsException => HttpStatusCode.BadRequest,
				Exception => HttpStatusCode.InternalServerError
			};
		}
	}
}
