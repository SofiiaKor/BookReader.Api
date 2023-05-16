using System.Net;

namespace BookReader.Api.Response
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

	public class ErrorApiResponse : ApiResponse
	{
		public string Message { get; }

		public ErrorApiResponse(HttpStatusCode statusCode, string message) : base(statusCode)
		{
			Message = message;
		}
	}
}
