using System;
using BookReader.Infrastructure.Logging.AbstractionModels;

namespace BookReader.Infrastructure.Interfaces
{
	public interface ILogger
	{
		void WriteToFile(string message);

		void LogRequest(LogBase log, object request = null);

		void LogResponse(LogBase log, object response = null, int? statusCode = null);

		void LogError(LogBase log, Exception exception, int? statusCode = null);
	}
}
