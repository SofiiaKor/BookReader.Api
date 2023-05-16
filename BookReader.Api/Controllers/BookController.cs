using System.Threading.Tasks;
using BookReader.Api.Response;
using BookReader.Application.Interfaces;
using BookReader.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(AddBookRequestModel request)
		{
			await _bookService.AddAsync(request);

			return ApiResponse.Created();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var books = await _bookService.GetAllAsync();

			return ApiResponse.Success(books);
		}

		[HttpPut("{name}")]
		public async Task<IActionResult> UpdateAsync(string name, AddBookRequestModel request)
		{
			await _bookService.UpdateAsync(name, request);

			return ApiResponse.Success();
		}

		[HttpDelete("{name}")]
		public async Task<IActionResult> DeleteBook(string name)
		{
			await _bookService.DeleteAsync(name);

			return ApiResponse.Created();
		}
	}
}