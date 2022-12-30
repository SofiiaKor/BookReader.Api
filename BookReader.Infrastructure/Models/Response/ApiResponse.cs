using System.Net;

namespace BookReader.Infrastructure.Models.Response
{
	public partial class ApiResponse
	{
		public HttpStatusCode StatusCode { get; }

		public ApiResponse(HttpStatusCode statusCode)
		{
			StatusCode = statusCode;
		}
    }

	public class ApiResponse<T> : ApiResponse
	{
		public T Response { get; }

		public ApiResponse(HttpStatusCode statusCode, T response) : base(statusCode)
		{
			Response = response;
		}
	}

	public class ExceptionApiResponse<T> : ApiResponse<T>
	{
		public long TotalCount { get; } // ??

		public ExceptionApiResponse(HttpStatusCode statusCode, T response, long totalCount) : base(statusCode, response)
		{
			TotalCount = totalCount;
		}
	}
}
