using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Application.Models;

namespace BookReader.Application.Interfaces
{
    public interface IBookService
    {
        Task AddAsync(AddBookRequestModel request);

        Task<List<BookResponseModel>> GetAllAsync();

        Task UpdateAsync(string name, AddBookRequestModel request);

        Task DeleteAsync(string name);
    }
}