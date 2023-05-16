using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Application.Exceptions;
using BookReader.Application.Interfaces;
using BookReader.Application.Models;
using BookReader.Domain.Entities;
using BookReader.Domain.Interfaces;
using Mapster;

namespace BookReader.Application.Services
{
	public class BookService : IBookService
	{
		// TODO: Remove all logs!!!!!
		private readonly IBookRepository _bookRepository;

		public BookService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task AddAsync(AddBookRequestModel request)
		{
			var exists = await _bookRepository.ExistsAsync(request.Name);
			if (exists)
				throw new BookAlreadyExistsException("Book with such name already exists.");

			var book = new Book(Guid.NewGuid(), request.Name, request.Author, request.Year, request.Publisher, request.NumberOfPages, request.ISBN);

			await _bookRepository.AddAsync(book);
		}

		public async Task<List<BookResponseModel>> GetAllAsync()
		{
			var books = await _bookRepository.GetAllAsync();
			var result = books.Adapt<List<BookResponseModel>>();

			return result;
		}

		public async Task UpdateAsync(string name, AddBookRequestModel request)
		{
			var book = await _bookRepository.GetAsync(name);
			if (book is null)
				throw new BookNotFoundException($"Book with name: {name} doesn't exists.");

			book.Update(request.Name, request.Author, request.Year, request.Publisher, request.NumberOfPages, request.ISBN);

			await _bookRepository.UpdateAsync(book);
		}

		public async Task DeleteAsync(string name)
		{
			var exists = await _bookRepository.ExistsAsync(name);
			if (!exists)
				throw new BookNotFoundException("Book with such name doesn't exists.");

			await _bookRepository.DeleteAsync(name);
		}
	}
}
