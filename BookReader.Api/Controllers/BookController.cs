using System.Threading.Tasks;
using BookReader.Application.Interfaces;
using BookReader.Application.Models;
using Microsoft.AspNetCore.Http;
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

			return StatusCode(StatusCodes.Status201Created, request);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var books = await _bookService.GetAllAsync();

			return Ok(books);
		}

		[HttpPut("{name}")]
		public async Task<IActionResult> UpdateAsync(string name, AddBookRequestModel request)
		{
			await _bookService.UpdateAsync(name, request);

			return Ok("Updated Successfully");
		}

		[HttpDelete("{name}")]
		public async Task<IActionResult> DeleteBook(string name)
		{
			await _bookService.DeleteAsync(name);

			return StatusCode(StatusCodes.Status201Created, name);
		}
	}
}