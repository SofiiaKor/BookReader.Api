using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Domain.Entities;
using BookReader.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookReader.Infrastructure.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public BookRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Book book)
		{
			await _dbContext.Books.AddAsync(book);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Book> GetAsync(string name)
		{
			var book = await _dbContext.Books.FirstOrDefaultAsync(o => o.Name == name);
			return book;
		}

		public async Task<List<Book>> GetAllAsync()
		{
			var books = await _dbContext.Books.ToListAsync();
			return books;
		}

		public async Task UpdateAsync(Book book)
		{
			var bookToUpdate = _dbContext.Books.FirstOrDefault(o => o.Name == book.Name);

			_dbContext.Books.Update(bookToUpdate!);
			await _dbContext.SaveChangesAsync();
		}

		public Task<bool> ExistsAsync(string name)
		{
			return _dbContext.Books.AnyAsync(n => n.Name == name);
		}

		public async Task DeleteAsync(string name)
		{
			_dbContext.Books.Remove(await _dbContext.Books.FirstOrDefaultAsync(book => book.Name == name));
			await _dbContext.SaveChangesAsync();
		}
	}
}