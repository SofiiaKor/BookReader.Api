using BookReader.Infrastructure.Logging.AbstractionModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookReader.Infrastructure.Logging
{
	public class LoggingActionFilter : IActionFilter
	{
		private readonly ILogger<LoggingActionFilter> _logger;

		public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
		{
			_logger = logger;
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var descriptor = (ControllerActionDescriptor)filterContext.ActionDescriptor;

			var log = new LogRequest
			{
				LogType = "Request",
				Name = descriptor.ActionName,
				Method = descriptor.MethodInfo.Name,
				Message = "Started a request"
			};

			using (_logger.BeginScope(log.ToDictionary()))
			{
				_logger.LogInformation(log.Message);
			}
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var descriptor = (ControllerActionDescriptor)filterContext.ActionDescriptor;

			var log = new LogResponse
			{
				LogType = "Response",
				Name = descriptor.ActionName,
				Method = descriptor.MethodInfo.Name,
				Message = "Received a response",
				ResponseCode = filterContext.HttpContext.Response.StatusCode
			};

			using (_logger.BeginScope(log.ToDictionary()))
			{
				_logger.LogInformation(log.Message);
			}
		}
	}
}
