using System;
using System.Net;
using BookReader.Api.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Response
{
	public partial class ApiResponse
	{
		public static ObjectResult Success()
		{
			var response = new ApiResponse(HttpStatusCode.OK);
			return response.ToObjectResult();
		}

		public static ObjectResult Success<T>(T value)
		{
			var response = new ApiResponse<T>(HttpStatusCode.OK, value);
			return response.ToObjectResult();
		}

		public static ObjectResult Created()
		{
			var response = new ApiResponse(HttpStatusCode.Created);
			return response.ToObjectResult();
		}

		public static ObjectResult Accepted()
		{
			var response = new ApiResponse(HttpStatusCode.Accepted);
			return response.ToObjectResult();
		}

		public static ObjectResult NoContent()
		{
			var response = new ApiResponse(HttpStatusCode.NoContent);
			return response.ToObjectResult();
		}

		public static ObjectResult ErrorResponse(HttpStatusCode statusCode, Exception exception)
		{
			var response = new ErrorApiResponse(statusCode, exception.Message);
			return response.ToObjectResult();
		}
	}
}
