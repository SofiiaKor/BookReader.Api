using BookReader.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Infrastructure.Extensions
{
	public static class ApiResponseExtensions
	{
		public static ObjectResult ToObjectResult(this ApiResponse response)
		{
			return new ObjectResult(response)
			{
				StatusCode = (int)response.StatusCode
			};
		}
	}
}
