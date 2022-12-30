using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Domain.Entities;

namespace BookReader.Domain.Interface
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);

        Task<Book> GetAsync(string name);

        Task<List<Book>> GetAllAsync();

        Task UpdateAsync(Book book);

        Task<bool> ExistsAsync(string name);

        Task DeleteAsync(string name);
    }
}
